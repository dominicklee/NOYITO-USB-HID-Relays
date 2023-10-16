Imports NoyitoRelay

Public Class Form1
    Dim relays As New RelayController

    Private Sub btnOn1_Click(sender As Object, e As EventArgs) Handles btnOn1.Click
        relays.SendRelay(1, RelayState.ENABLED)
    End Sub

    Private Sub btnOff1_Click(sender As Object, e As EventArgs) Handles btnOff1.Click
        relays.SendRelay(1, RelayState.DISABLED)
    End Sub

    Private Sub btnOnAll_Click(sender As Object, e As EventArgs) Handles btnOnAll.Click
        relays.SendRelays(RelayState.ENABLED)
    End Sub

    Private Sub btnOffAll_Click(sender As Object, e As EventArgs) Handles btnOffAll.Click
        relays.SendRelays(RelayState.DISABLED)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        relays.OpenDevice()
    End Sub

    Private Sub btnOn2_Click(sender As Object, e As EventArgs) Handles btnOn2.Click
        relays.SendRelay(2, RelayState.ENABLED)
    End Sub

    Private Sub btnOff2_Click(sender As Object, e As EventArgs) Handles btnOff2.Click
        relays.SendRelay(2, RelayState.DISABLED)
    End Sub

    Private Sub btnOn3_Click(sender As Object, e As EventArgs) Handles btnOn3.Click
        relays.SendRelay(3, RelayState.ENABLED)
    End Sub

    Private Sub btnOff3_Click(sender As Object, e As EventArgs) Handles btnOff3.Click
        relays.SendRelay(3, RelayState.DISABLED)
    End Sub

    Private Sub btnOn4_Click(sender As Object, e As EventArgs) Handles btnOn4.Click
        relays.SendRelay(4, RelayState.ENABLED)
    End Sub

    Private Sub btnOff4_Click(sender As Object, e As EventArgs) Handles btnOff4.Click
        relays.SendRelay(4, RelayState.DISABLED)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        relays.CloseDevice()
    End Sub
End Class
