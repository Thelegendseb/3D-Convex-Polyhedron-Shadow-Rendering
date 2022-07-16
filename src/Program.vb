Imports XApps
Imports System.Numerics
Public Class Program
    Inherits XApp

    Private CurrentShape As Shape

    Private Camera As ShadowCamera

    Private Light As Vector3
    Sub New(FormIn As Form)
        MyBase.New(FormIn)

        Me.Light = New Vector3(0, 0, -200)

        'Rays hit wall when Z Component of ray is == x

        Me.CurrentShape = New Shape

        Me.CurrentShape.GetVerticies.Add(New Numerics.Vector3(-100, -100, -100))
        Me.CurrentShape.GetVerticies.Add(New Numerics.Vector3(-100, -100, 100))
        Me.CurrentShape.GetVerticies.Add(New Numerics.Vector3(-100, 100, 100))
        Me.CurrentShape.GetVerticies.Add(New Numerics.Vector3(100, 100, 100))
        Me.CurrentShape.GetVerticies.Add(New Numerics.Vector3(100, -100, -100))
        Me.CurrentShape.GetVerticies.Add(New Numerics.Vector3(100, 100, -100))
        Me.CurrentShape.GetVerticies.Add(New Numerics.Vector3(100, -100, 100))
        Me.CurrentShape.GetVerticies.Add(New Numerics.Vector3(-100, 100, -100))

        Me.Camera = New OrthographicShadowCamera(Me.CurrentShape)

        Me.Session.AddObj(New ShapeRenderer(Me.CurrentShape))
        Me.Session.AddObj(New ShadowRenderer(Me.Camera))

    End Sub

    Public Overrides Sub UpdateOccured()

        Me.CurrentShape.GetTransform.Rotation.Roll += ShapeMath.DegreesToRadians(-1) ' Works
        Me.CurrentShape.GetTransform.Rotation.Yaw += ShapeMath.DegreesToRadians(1) ' Works
        Me.CurrentShape.GetTransform.Rotation.Pitch += ShapeMath.DegreesToRadians(-1) ' Works
        Me.CurrentShape.GetTransform.Rotation.LetClampAll()

    End Sub
End Class
