Imports XApps
Public Class Program
    Inherits XApp

    Private TestCube As Shape
    Sub New(FormIn As Form)
        MyBase.New(FormIn)

        Me.TestCube = New Shape

        Me.TestCube.GetVerticies.Add(New Numerics.Vector3(-50, -50, -50))
        Me.TestCube.GetVerticies.Add(New Numerics.Vector3(-50, -50, 50))
        Me.TestCube.GetVerticies.Add(New Numerics.Vector3(-50, 50, 50))
        Me.TestCube.GetVerticies.Add(New Numerics.Vector3(50, 50, 50))
        Me.TestCube.GetVerticies.Add(New Numerics.Vector3(50, -50, -50))
        Me.TestCube.GetVerticies.Add(New Numerics.Vector3(50, 50, -50))
        Me.TestCube.GetVerticies.Add(New Numerics.Vector3(50, -50, 50))
        Me.TestCube.GetVerticies.Add(New Numerics.Vector3(-50, 50, -50))

        Me.Session.AddObj(New TempShapeRenderer(Me.TestCube))

    End Sub

    Public Overrides Sub UpdateOccured()

        Me.TestCube.GetTransform.Rotation.Roll += ShapeMath.DegreesToRadians(1) ' Works
        Me.TestCube.GetTransform.Rotation.Yaw += ShapeMath.DegreesToRadians(1) ' Works
        Me.TestCube.GetTransform.Rotation.Pitch += ShapeMath.DegreesToRadians(1) ' Works
        Me.TestCube.GetTransform.Rotation.LetClampAll()

    End Sub
End Class
