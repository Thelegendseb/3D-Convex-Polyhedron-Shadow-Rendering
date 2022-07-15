Imports System.Numerics
Imports _3DConvexPolyhedronShadowTest.ShapeMath
Public Class Shape
    Implements IShape
    Protected Property Transform As Transform Implements IShape.Transform
    Protected Property Verticies As List(Of Vector3) Implements IShape.Verticies
    Protected Property Faces As List(Of Face) Implements IShape.Faces
    Sub New()
        Me.InitializeAttributes()
    End Sub
    Private Sub InitializeAttributes() Implements IShape.InitializeAttributes
        Me.Transform = New Transform
        Me.Verticies = New List(Of Vector3)
        Me.Faces = New List(Of Face)
    End Sub
    Public Function CallState() As List(Of Vector3) Implements IShape.CallState
        Dim CurrentState As New List(Of Vector3)

        ' // Rotate each vertex by the transform and return the new list of points

        For Each Vertex As Vector3 In Me.Verticies
            Dim StateVertex As New Vector3(Vertex.X, Vertex.Y, Vertex.Z)

            ' Rotation Matrix Multiplication

            StateVertex = Matrix.Multiply(MatrixType("X", Me.Transform.Rotation.Pitch), StateVertex)
            StateVertex = Matrix.Multiply(MatrixType("Y", Me.Transform.Rotation.Yaw), StateVertex)
            StateVertex = Matrix.Multiply(MatrixType("Z", Me.Transform.Rotation.Roll), StateVertex)

            ' Projection Matrix Multiplication

            Dim ProjZ As Single = 900 / (700 + StateVertex.Z - (Me.Transform.Position.Z * 3))

            Dim ProjMatrix(,) As Single = {{ProjZ, 0, 0},
                                           {0, ProjZ, 0}}

            StateVertex = Matrix.Multiply(ProjMatrix, StateVertex)

            ' // Add to CurrentState List

            CurrentState.Add(StateVertex)
        Next

        Return CurrentState
    End Function
    '=============================
    Public Function GetTransform() As Transform
        Return Me.Transform
    End Function
    Public Function GetVerticies() As List(Of Vector3)
        Return Me.Verticies
    End Function
    Public Function GetFaces() As List(Of Face)
        Return Me.Faces
    End Function
End Class
