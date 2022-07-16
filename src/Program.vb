Imports XApps
Imports System.Numerics
Public Class Program
    Inherits XApp

    Private CurrentShape As Shape

    Private Camera As PerspectiveShadowCamera

    Private Light As Vector3
    Private WallZ As Integer

    Sub New(FormIn As Form)
        MyBase.New(FormIn)
        FormIn.Text = "3D Convex Polyhedron Shadow"

        Me.Light = New Vector3(0, 0, -600)

        Me.WallZ = 300

        'Rays hit wall when Z Component of ray is == x

        Me.CurrentShape = New Shape

        Me.CurrentShape.GetTransform.Position = New Vector3(0, 0, 0)

        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(-75, -75, -75))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(-75, -75, 75))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(-75, 75, 75))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(75, 75, 75))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(75, -75, -75))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(75, 75, -75))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(75, -75, 75))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(-75, 75, -75))

        Me.Camera = New PerspectiveShadowCamera(Me.CurrentShape, Me.Light, Me.WallZ)

        Me.Session.AddObj(New ShapeRotationController(Me.CurrentShape, Me.Session.Window))

        Me.Session.AddObj(New ShapeRenderer(Me.CurrentShape))
        Me.Session.AddObj(New ShadowRenderer(Me.Camera))

    End Sub

    Public Overrides Sub UpdateOccured()

        Me.Camera.SetWallZ(WallZ)
        Me.Camera.SetLight(Me.Light)
        Me.CurrentShape.GetTransform.Rotation.LetClampAll()

    End Sub
End Class
