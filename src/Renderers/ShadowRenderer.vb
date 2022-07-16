Imports XApps
Public Class ShadowRenderer
    Inherits XBase
    Private Camera As ShadowCamera
    Sub New(CamIn As ShadowCamera)
        Me.Camera = CamIn
        Me.SetDrawStatus(True)
    End Sub
    Public Sub ChangeCamera(NewCamera As ShadowCamera)
        Me.Camera = NewCamera
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)

        Dim W2 As Integer = (g.VisibleClipBounds.Width / 4) * 3
        Dim H2 As Integer = (g.VisibleClipBounds.Height / 3) * 2

        Dim Hull() As Point = Me.Camera.GetShadowHull.ToArray

        For i = 0 To Hull.Length - 1
            Hull(i).X = W2 - Hull(i).X
            Hull(i).Y = H2 - Hull(i).Y
        Next

        g.FillPolygon(Brushes.DarkGray, Hull)

        For i = 0 To Hull.Length - 1
            g.FillEllipse(Brushes.Red, Hull(i).X - 5, Hull(i).Y - 5, 10, 10)
        Next
    End Sub
End Class
