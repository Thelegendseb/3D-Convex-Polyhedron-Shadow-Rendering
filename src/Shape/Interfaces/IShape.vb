Imports System.Numerics
Public Interface IShape
    Property Transform As Transform
    ' // Object reprenting the position, rotation and scale of a shape

    Property Verticies As List(Of Vector3)
    ' // All Verticies of the shape

    Property Faces As List(Of Face)
    ' // All Faces constructed off of index values of verticies

    Sub InitializeAttributes()
    ' // Self - Explained

    Function CallState() As List(Of Vector3)
    ' // Returns a list of verticies based off the transforms rotation component and the base verticies of the shape

End Interface
