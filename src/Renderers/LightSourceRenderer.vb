Imports XApps
Public Class LightSourceRenderer
    Inherits XBase
    Private LightSourcePtr As LightSource
    Sub New(Ptr As LightSource)
        Me.LightSourcePtr = Ptr
        Me.SetDrawStatus(True)
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)

        Dim W2 As Integer = g.VisibleClipBounds.Width / 2
        Dim H2 As Integer = g.VisibleClipBounds.Height / 2

        Dim LightPos As Numerics.Vector3 = Me.LightSourcePtr.GetPosition

        Dim ZAbs As Integer = Math.Abs(LightPos.Z) / 30
        Dim ZAbsInverse As Integer = 1 / ZAbs
        Dim ZAbs2 As Integer = ZAbsInverse * 10
        g.FillEllipse(Brushes.Beige, W2 - LightPos.X - ZAbs2, H2 - LightPos.Y - ZAbs2, ZAbs, ZAbs)


    End Sub
End Class
