Imports XApps
Imports System.Numerics
Public Class ShapeRenderer
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

        Dim W2 As Integer = g.VisibleClipBounds.Width / 4
        Dim H2 As Integer = (g.VisibleClipBounds.Height / 3) * 2

        Dim CState As List(Of Vector3) = Me.ShapePtr.CallState

        For Each Vertex As Vector3 In CState
            For Each OtherVertex As Vector3 In CState
                If Not Vertex.Equals(OtherVertex) Then
                    g.DrawLine(Pens.Black, W2 - Vertex.X, H2 - Vertex.Y, W2 - OtherVertex.X, H2 - OtherVertex.Y)
                End If
            Next
        Next
    End Sub
End Class
