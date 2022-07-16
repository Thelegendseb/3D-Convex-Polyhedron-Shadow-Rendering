Imports XApps
Public Class RuleRenderer
    Inherits XBase
    Private ShapePtr As Shape
    Sub New(Ptr As Shape)
        Me.SetDrawStatus(True)
        Me.ShapePtr = Ptr
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        Dim F As New Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold)
        g.DrawString("A: Increase light source X", F, Brushes.IndianRed, 20, 20)
        g.DrawString("D: Decrease light source X", F, Brushes.IndianRed, 20, 50)
        g.DrawString("W: Decrease light source Y", F, Brushes.IndianRed, 20, 80)
        g.DrawString("S: Increase light source Y", F, Brushes.IndianRed, 20, 110)
        g.DrawString("UP ARROW KEY: Decrease light source Z", F, Brushes.IndianRed, 20, 140)
        g.DrawString("DOWN ARROW KEY: Increase light source Z", F, Brushes.IndianRed, 20, 170)
        g.DrawString("LEFT MOUSE DOWN: Rotate Shape", F, Brushes.IndianRed, 20, 200)

        ' ================================================================

        g.DrawString("Shape Rotation => Yaw: " & Math.Round(Me.ShapePtr.GetTransform.Rotation.YawToDegrees), F, Brushes.IndianRed, 20, 300)
        ' g.DrawString("Shape Rotation => Roll: " & Math.Round(Me.ShapePtr.GetTransform.Rotation.RollToDegrees), F, Brushes.IndianRed, 20, 330)
        g.DrawString("Shape Rotation => Roll: " & "NULL", F, Brushes.IndianRed, 20, 330)
        g.DrawString("Shape Rotation => Pitch: " & Math.Round(Me.ShapePtr.GetTransform.Rotation.PitchToDegrees), F, Brushes.IndianRed, 20, 360)


        F.Dispose()
    End Sub
End Class
