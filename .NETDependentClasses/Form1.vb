Imports XApps
Public Class Form1
    Private App As XApp
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.App = New Program(Me)
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.App.Run()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Me.App.Halt()
    End Sub
End Class
