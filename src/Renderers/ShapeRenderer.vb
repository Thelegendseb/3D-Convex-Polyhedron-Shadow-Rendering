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
                    Dim AvrZ As Integer = (Vertex.Z + OtherVertex.Z) / 2
                    Dim Mapped As Integer = XMath.Map(AvrZ, -150, 150, 0, 255)
                    Dim C As Color = Color.FromArgb(Mapped, Mapped, Mapped)
                    Dim P As New Pen(C, 3)
                    g.DrawLine(P, W2 - Vertex.X, H2 - Vertex.Y, W2 - OtherVertex.X, H2 - OtherVertex.Y)
                    P.Dispose()
                End If
            Next
        Next
    End Sub
End Class
