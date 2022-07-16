Imports System.Numerics
Public Interface IShape
    Property Transform As Transform
    ' // Object reprenting the position, rotation and scale of a shape

    Property Vertices As List(Of Vector3)
    ' // All Vertices of the shape

    Property Faces As List(Of Face)
    ' // All Faces constructed off of index values of Vertices

    Sub InitializeAttributes()
    ' // Self - Explained

    Function CallState() As List(Of Vector3)
    ' // Returns a list of Vertices based off the transforms rotation component and the base Vertices of the shape

End Interface
