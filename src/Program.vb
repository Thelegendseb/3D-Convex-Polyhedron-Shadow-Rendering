Imports XApps
Imports System.Numerics
Public Class Program
    Inherits XApp

    Private Shape As Shape

    Private Camera As PerspectiveShadowCamera

    Private Light As OmniDirectionalLightSource

    Private Wall As Wall

    Sub New(FormIn As Form)
        MyBase.New(FormIn)
        FormIn.Text = "3D Convex Polyhedron Shadow"
        Me.Session.Window.SetClearColor(Color.FromArgb(10, 20, 30))


        ' // Initialize Attributes

        Me.Light = New OmniDirectionalLightSource(New Vector3(0, 0, -600))
        Me.Wall = New Wall(300)
        Me.Shape = DefualtCube()
        Me.Camera = New PerspectiveShadowCamera(Me.Shape, Me.Light, Me.Wall)

        ' // Add Controllers

        Me.Session.AddObj(New ShapeRotationController(Me.Shape, Me.Session.Window))

        ' // Add Renderers

        Me.Session.AddObj(New ShadowRenderer(Me.Camera))
        Me.Session.AddObj(New ShapeRenderer(Me.Shape))
        Me.Session.AddObj(New LightSourceRenderer(Me.Light))
        Me.Session.AddObj(New RuleRenderer(Me.Shape))

    End Sub
    Public Overrides Sub UpdateOccured()

        InputChecks()

        Me.Shape.GetTransform.Rotation.LetClampAll()

    End Sub

    Private Sub InputChecks()
        If Me.Session.KeyManager.IsDown(Keys.A) Then
            Me.Light.MoveLeftBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.D) Then
            Me.Light.MoveRightBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.W) Then
            Me.Light.MoveUpBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.S) Then
            Me.Light.MoveDownBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.Up) Then
            Me.Light.MoveForwardBy(-5)
        End If
        If Me.Session.KeyManager.IsDown(Keys.Down) Then
            Me.Light.MoveBackwardBy(-5)
        End If
    End Sub

    Private Function DefualtCube() As Shape

        Dim Cube As New Shape

        Cube.GetVertices.Add(New Numerics.Vector3(-1, -1, -1))
        Cube.GetVertices.Add(New Numerics.Vector3(-1, -1, 1))
        Cube.GetVertices.Add(New Numerics.Vector3(-1, 1, 1))
        Cube.GetVertices.Add(New Numerics.Vector3(1, 1, 1))
        Cube.GetVertices.Add(New Numerics.Vector3(1, -1, -1))
        Cube.GetVertices.Add(New Numerics.Vector3(1, 1, -1))
        Cube.GetVertices.Add(New Numerics.Vector3(1, -1, 1))
        Cube.GetVertices.Add(New Numerics.Vector3(-1, 1, -1))

        Cube.GetTransform.Scale.SetAll(75)

        Return Cube

    End Function
End Class
