Imports System.Numerics
Public Class ShapeMath
    Public Shared Function DegreesToRadians(val As Double) As Double
        Return val * (Math.PI / 180)
    End Function
    Public Shared Function MatrixType(type As Char, angle As Double) As Single(,)
        type = UCase(type)
        If type = "Z" Then
            Return {
        {CSng(Math.Cos(angle)), CSng(-Math.Sin(angle)), 0},
        {CSng(Math.Sin(angle)), CSng(Math.Cos(angle)), 0},
        {0, 0, 1}
        }
        ElseIf type = "X" Then
            Return {
                {1, 0, 0},
        {0, CSng(Math.Cos(angle)), CSng(-Math.Sin(angle))},
        {0, CSng(Math.Sin(angle)), CSng(Math.Cos(angle))}
        }
        ElseIf type = "Y" Then
            Return {
        {CSng(Math.Cos(angle)), 0, CSng(-Math.Sin(angle))},
        {0, 1, 0},
        {CSng(Math.Sin(angle)), 0, CSng(Math.Cos(angle))}
        }
        Else : Return {
                {CSng(0), 0, 0},
                {0, 0, 0},
                {0, 0, 0}
                }
        End If
    End Function

    Public Class Matrix

        'FIX THIS
        Public Shared Function Multiply(matrix(,) As Single, V As Vector3) As Vector3

            If matrix.GetLength(0) = 2 Then


                Return New Vector3(matrix(0, 0) * V.X +
                                     matrix(0, 1) * V.Y +
                                     matrix(0, 2) * V.Z,
                                     matrix(1, 0) * V.X +
                                     matrix(1, 1) * V.Y +
                                     matrix(1, 2) * V.Z,
                                     V.Z)

            ElseIf matrix.GetLength(0) = 3 Then

                Return New Vector3(matrix(0, 0) * V.X +
                                     matrix(0, 1) * V.Y +
                                     matrix(0, 2) * V.Z,
                                     matrix(1, 0) * V.X +
                                     matrix(1, 1) * V.Y +
                                     matrix(1, 2) * V.Z,
                                     matrix(2, 0) * V.X +
                                     matrix(2, 1) * V.Y +
                                     matrix(2, 2) * V.Z)
            End If

            Return V
        End Function

    End Class
End Class
