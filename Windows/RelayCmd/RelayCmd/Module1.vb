Imports System.Threading.Tasks
Imports NoyitoRelay

Module Module1

    Sub Main(args As String())
        Dim relayNumber As Integer = 0
        Dim relayState As Integer = 0
        Dim isAll As Boolean = False
        Dim needsHelp As Boolean = False

        If args.Length = 0 Then
            Console.WriteLine("NOYITO USB HID Relay Command Line")
            Console.WriteLine("For help, enter: relaycmd.exe -h")
            Return
        End If

        ' Parsing arguments
        For i = 0 To args.Length - 1 Step 2
            Select Case args(i).ToLower()
                Case "-r"
                    If args(i + 1).ToLower() = "all" Then
                        isAll = True
                    Else
                        relayNumber = Integer.Parse(args(i + 1))
                    End If
                Case "-s"
                    relayState = Integer.Parse(args(i + 1))
                Case "-h"
                    needsHelp = True
                Case Else
                    Console.WriteLine("Unknown argument: " & args(i))
                    Return
            End Select
        Next

        If needsHelp Then
            Console.WriteLine("NOYITO USB HID Relay Command Line" & vbNewLine)
            Console.WriteLine("Usage: relaycmd.exe -r [relay_number|all] -s [state]")
            Console.WriteLine("  relay_number: The number of the relay to control 1~8.")
            Console.WriteLine("  Use 'all' to control all relays.")
            Console.WriteLine("  state: 0 for off, 1 for on.")
            Return
        End If

        ' Initialize NoyitoRelay device
        Dim relayDevice As New RelayController
        relayDevice.OpenDevice()

        ' Perform Relay Operations
        If isAll Then
            relayDevice.SendRelays(relayState)
        Else
            relayDevice.SendRelay(relayNumber, relayState)
        End If

        relayDevice.CloseDevice()
    End Sub
End Module
