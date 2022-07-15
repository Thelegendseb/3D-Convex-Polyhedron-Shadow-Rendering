Imports XApps
Imports System.Numerics
Public Class TempShapeRenderer
    Inherits XBase
    Private ShapePtr As Shape
    Sub New(Ptr As Shape)
        Me.ShapePtr = Ptr
        Me.SetDrawStatus(True)
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)

        Dim W2 As Integer = g.VisibleClipBounds.Width / 2
        Dim H2 As Integer = g.VisibleClipBounds.Height / 2

        For Each Vertex As Vector3 In Me.ShapePtr.CallState
            g.FillEllipse(Brushes.Black, CSng(W2 - Vertex.X) - 2, CSng(H2 - Vertex.Y) - 2, 4, 4)
        Next
    End Sub
End Class
