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
        Me.Session.Window.SetClearColor(Color.FromArgb(10, 20, 30))

        Me.Light = New Vector3(0, 0, -600)

        Me.WallZ = 300

        ConstructShape()

        ' // Initialize Attributes

        Me.Camera = New PerspectiveShadowCamera(Me.CurrentShape, Me.Light, Me.WallZ)

        ' // Add Controllers

        Me.Session.AddObj(New ShapeRotationController(Me.CurrentShape, Me.Session.Window))

        ' // Add Renderers

        Me.Session.AddObj(New ShadowRenderer(Me.Camera))
        Me.Session.AddObj(New ShapeRenderer(Me.CurrentShape))
        Me.Session.AddObj(New RuleRenderer(Me.CurrentShape))


        ' ===== !!!!!!!!! ========

        ' ADD LIGHT SOURCE VISUALIZER

        ' ===== !!!!!!!!! ========

    End Sub
    Public Overrides Sub UpdateOccured()

        InputChecks()

        Me.Camera.SetWallZ(WallZ)
        Me.Camera.SetLight(Me.Light)
        Me.CurrentShape.GetTransform.Rotation.LetClampAll()

    End Sub

    Private Sub InputChecks()
        If Me.Session.KeyManager.IsDown(Keys.A) Then
            Me.Light.X -= 5
        End If
        If Me.Session.KeyManager.IsDown(Keys.D) Then
            Me.Light.X += 5
        End If
        If Me.Session.KeyManager.IsDown(Keys.W) Then
            Me.Light.Y -= 5
        End If
        If Me.Session.KeyManager.IsDown(Keys.S) Then
            Me.Light.Y += 5
        End If
        If Me.Session.KeyManager.IsDown(Keys.Up) Then
            Me.Light.Z += 5
        End If
        If Me.Session.KeyManager.IsDown(Keys.Down) Then
            Me.Light.Z -= 5
        End If
    End Sub

    Private Sub ConstructShape()
        Me.CurrentShape = New Shape

        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(-1, -1, -1))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(-1, -1, 1))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(-1, 1, 1))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(1, 1, 1))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(1, -1, -1))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(1, 1, -1))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(1, -1, 1))
        Me.CurrentShape.GetVertices.Add(New Numerics.Vector3(-1, 1, -1))

        Me.CurrentShape.GetTransform.Scale.SetAll(75)


    End Sub
End Class
