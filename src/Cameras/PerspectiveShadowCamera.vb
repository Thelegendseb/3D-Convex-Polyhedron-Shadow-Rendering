﻿Imports System.Numerics
Public Class PerspectiveShadowCamera
    Inherits ShadowCamera
    Protected LightSource As LightSource
    Protected Wall As Wall
    Sub New(ShapePtr As Shape, LightSourcePtr As LightSource, WallIn As Wall)
        MyBase.New(ShapePtr)
        Me.LightSource = LightSourcePtr
        Me.Wall = WallIn
    End Sub
    Public Overrides Function GetShadowHull() As List(Of Point)

        Dim CState As List(Of Vector3) = Me.ShapePtr.CallState()

        Dim MappedCState As List(Of Vector3) = FormulateRays(CState)

        Dim Mapped2DState As List(Of Point) = ShapeMath.RemoveZComponent(MappedCState)

        Dim Hull As List(Of Point) = GrahamScan.GetCovexHull(Mapped2DState)

        Return Hull

    End Function
    Private Function FormulateRays(CState As List(Of Vector3)) As List(Of Vector3)

        Dim Rays As New List(Of Ray3D)

        For Each Vertex As Vector3 In CState
            Dim Ray As New Ray3D
            Ray.Position = Me.LightSource.GetPosition
            Ray.Direction = New Vector3(Me.ShapePtr.GetTransform.Position.X + Vertex.X - Ray.Position.X,
                                        Me.ShapePtr.GetTransform.Position.Y + Vertex.Y - Ray.Position.Y,
                                        Me.ShapePtr.GetTransform.Position.Z + Vertex.Z - Ray.Position.Z)
            Rays.Add(Ray)
        Next

        ' // Extend each Direction vertex to a given z value

        Dim DiffZ As Double = Math.Abs(Me.Wall.GetZ - Me.LightSource.GetPosition.Z)
        For Each Ray As Ray3D In Rays
            Dim Multiplier As Double = DiffZ / Ray.Direction.Z

            Ray.Direction.X *= Multiplier
            Ray.Direction.Y *= Multiplier
            Ray.Direction.Z *= Multiplier

            Ray.Direction.X -= Me.ShapePtr.GetTransform.Position.X
            Ray.Direction.Y -= Me.ShapePtr.GetTransform.Position.Y
            Ray.Direction.Z -= Me.ShapePtr.GetTransform.Position.Z
        Next

        ' // Change into correct return type

        Dim R As New List(Of Vector3)
        For Each Ray As Ray3D In Rays
            R.Add(Ray.Direction)
        Next
        Return R
    End Function
End Class
