Public MustInherit Class ShadowCamera
    Protected ShapePtr As Shape
    Protected Hull As List(Of Point)

    Sub New(ShapePtr As Shape)
        Me.ShapePtr = ShapePtr
        Me.Hull = New List(Of Point)
    End Sub
    Public MustOverride Function GetShadowHull() As List(Of Point)

End Class
