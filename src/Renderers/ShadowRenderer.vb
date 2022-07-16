﻿Imports XApps
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

        Dim W2 As Integer = g.VisibleClipBounds.Width / 2
        Dim H2 As Integer = g.VisibleClipBounds.Height / 2

        Dim Hull() As Point = Me.Camera.GetShadowHull.ToArray

        For i = 0 To Hull.Length - 1
            Hull(i).X = W2 - Hull(i).X
            Hull(i).Y = H2 - Hull(i).Y
        Next


        g.FillPolygon(Brushes.Black, Hull)
        Dim P As New Pen(Brushes.Red, 3)
        g.DrawPolygon(P, Hull)
        P.Dispose()

    End Sub
End Class
