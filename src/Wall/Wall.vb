Public Class Wall
    Private Z As Double
    Sub New(SetZ As Double)
        Me.Z = SetZ
    End Sub
    Public Sub SetZ(Val As Double)
        Me.Z = Val
    End Sub
    Public Function GetZ() As Double
        Return Me.Z
    End Function
End Class
