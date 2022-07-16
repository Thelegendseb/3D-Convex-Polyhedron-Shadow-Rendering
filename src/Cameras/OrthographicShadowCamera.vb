Imports System.Numerics
Public Class OrthographicShadowCamera
    Inherits ShadowCamera
    Sub New(ShapePtr As Shape)
        MyBase.New(ShapePtr)
    End Sub
    Public Overrides Function GetShadowHull() As List(Of Point)

        Dim CState As List(Of Vector3) = Me.ShapePtr.CallState()

        Dim CState2D As List(Of Point) = ShapeMath.RemoveZComponent(CState)

        Dim Hull As List(Of Point) = GrahamScan.GetCovexHull(CState2D)

        Return Hull

    End Function
End Class
