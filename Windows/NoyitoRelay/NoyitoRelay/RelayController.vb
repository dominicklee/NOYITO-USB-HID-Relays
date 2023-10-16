Imports System.Reflection
Imports HidLibrary

''' <summary>
''' State of the relay.
''' </summary>
Public Enum RelayState As Integer
    DISABLED = 0
    ENABLED = 1
End Enum

Public Class RelayController
    Dim device As HidDevice


    Private Function CurrentDomain_AssemblyResolve(sender As Object, args As ResolveEventArgs) As Assembly
        Dim resourceName = "NoyitoRelay.HidLibrary.dll"  ' Adjust the namespace and resource name
        Using stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
            Dim assemblyData(CInt(stream.Length) - 1) As Byte
            stream.Read(assemblyData, 0, assemblyData.Length)
            Return Assembly.Load(assemblyData)
        End Using
    End Function

    Public Sub New()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CurrentDomain_AssemblyResolve

        OpenDevice()
    End Sub

    ''' <summary>
    ''' Connects to the relay device. Returns True if successful, False if no device found.
    ''' </summary>
    Public Function OpenDevice() As Boolean
        Dim devices = HidDevices.Enumerate(&H5131, &H2007)
        If devices.Count > 0 Then
            device = devices.First()
            device.OpenDevice()
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Closes the current connected relay device.
    ''' </summary>
    Public Sub CloseDevice()
        device.CloseDevice()
    End Sub

    ''' <summary>
    ''' Set the state of a specific relay.
    ''' </summary>
    Public Sub SendRelay(ByVal relayNumber As Integer, ByVal relayState As Integer)
        If device IsNot Nothing Then
            If device.IsConnected Then
                Dim command As Byte = If(relayState = 1, &HA1, &HA0) + relayNumber
                Dim data() As Byte = {0, &HA0, Convert.ToByte(relayNumber), Convert.ToByte(relayState), command}
                device.Write(data)
            Else
                ' Handle device not connected scenario
                MsgBox("Device not connected.")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Set the state of all relays.
    ''' </summary>
    Public Sub SendRelays(ByVal relayState As Integer)
        Parallel.Invoke(
            Sub() SendRelay(1, relayState),
            Sub() SendRelay(2, relayState),
            Sub() SendRelay(3, relayState),
            Sub() SendRelay(4, relayState),
            Sub() SendRelay(5, relayState),
            Sub() SendRelay(6, relayState),
            Sub() SendRelay(7, relayState),
            Sub() SendRelay(8, relayState)
        )
    End Sub
End Class
