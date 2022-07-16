Imports XApps
Public Class ShapeRotationController
    Inherits XBase
    Private MouseDown As Boolean

    Private ShapePtr As Shape

    Private MousePosition As Vector
    Private MouseDelta As Vector
    Private ShapeChange As Vector



    Sub New(Shape As Shape, Window As XWindow)
        Me.SetUpdateStatus(True)

        Me.MouseDelta = Vector.Zero
        Me.ShapeChange = Vector.Zero
        Me.MousePosition = Vector.Zero

        Me.ShapePtr = Shape

        AddHandler Window.MouseDown, AddressOf Me.MouseDownHandle
        AddHandler Window.MouseUp, AddressOf Me.MouseUpHandle
        AddHandler Window.MouseMove, AddressOf Me.MouseMoveHandle
    End Sub
    Private Sub MouseDownHandle(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Me.MouseDown = True
        End If
        Me.MouseDelta.X = e.X
        Me.MouseDelta.Y = e.Y
    End Sub
    Private Sub MouseUpHandle(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Me.MouseDown = False
        End If
    End Sub
    Private Sub MouseMoveHandle(sender As Object, e As MouseEventArgs)
        Me.MousePosition.X = e.X
        Me.MousePosition.Y = e.Y
    End Sub
    Public Overrides Sub Update(Session As XSession)
        If Me.MouseDown Then

            Me.ShapeChange = Me.MouseDelta - Me.MousePosition

            If Me.ShapeChange.Magnitude > 20 Then
                Me.ShapeChange.SetMag(20)
            End If

            Rotate()

            Me.MouseDelta.X = Me.MousePosition.X
            Me.MouseDelta.Y = Me.MousePosition.Y

        Else

            Rotate()
            Me.ShapeChange *= 0.9

        End If
    End Sub
    Private Sub Rotate()
        Me.ShapePtr.GetTransform.Rotation.Yaw += ShapeMath.DegreesToRadians(Me.ShapeChange.X)
        Me.ShapePtr.GetTransform.Rotation.Pitch += ShapeMath.DegreesToRadians(Me.ShapeChange.Y)
        ' Me.ShapePtr.GetTransform.Rotation.Roll += ShapeMath.DegreesToRadians()
    End Sub
    Public Overrides Sub Draw(ByRef g As Graphics)
        Throw New NotImplementedException()
    End Sub
End Class
