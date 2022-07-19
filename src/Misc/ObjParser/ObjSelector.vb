Public Class ObjSelector
    Public Shared Function SelectFromFileExplorer() As String
        Dim FD As New OpenFileDialog
        FD.Filter = "obj files (*.obj)|*.obj"
        If FD.ShowDialog = DialogResult.OK Then
            MsgBox(FD.FileName)
        Else
            MsgBox("No File Selected. Loading Defualt Shape")
            Return "NULL"
        End If
        Return FD.FileName
    End Function
End Class
