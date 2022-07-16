Imports System.Numerics
Public Class PerspectiveShadowCamera
    Inherits ShadowCamera
    Protected LightSource As Vector3
    Sub New(ShapePtr As Shape, LightSourcePtr As Vector3)
        MyBase.New(ShapePtr)
        Me.LightSource = LightSourcePtr
    End Sub
    Public Overrides Function GetShadowHull() As List(Of Point)
        Throw New NotImplementedException()
    End Function
End Class
