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

        Dim W2 As Integer = g.VisibleClipBounds.Width / 2
        Dim H2 As Integer = g.VisibleClipBounds.Height / 2

        Dim CState As List(Of Vector3) = Me.ShapePtr.CallState

        Dim CStateDisplaced As New List(Of Vector3)

        For Each Vertex As Vector3 In CState
            CStateDisplaced.Add(New Vector3(W2 - Vertex.X, H2 - Vertex.Y, Vertex.Z))
        Next
        CState.Clear()

        Dim CState2D As List(Of Point) = ShapeMath.RemoveZComponent(CStateDisplaced)

        Dim Hull As List(Of Point) = GrahamScan.GetCovexHull(CState2D)

        Dim HullArr() As Point = Hull.ToArray()

        g.FillPolygon(Brushes.IndianRed, HullArr)

        Dim P As New Pen(Brushes.AntiqueWhite, 8)
        g.DrawPolygon(P, HullArr)

        CStateDisplaced = CStateDisplaced.OrderBy(Function(V) V.Z).Reverse.ToList

        For Each Vertex As Vector3 In CStateDisplaced
            For Each OtherVertex As Vector3 In CStateDisplaced
                If Not Vertex.Equals(OtherVertex) Then
                    Dim C As Integer = XMath.Map((Vertex.Z + OtherVertex.Z) / 2, -150, 150, 0, 255)
                    P.Color = Color.FromArgb(0, C, 255)
                    g.DrawLine(P, Vertex.X, Vertex.Y, OtherVertex.X, OtherVertex.Y)
                End If
            Next
        Next

        P.Dispose()

    End Sub
End Class
