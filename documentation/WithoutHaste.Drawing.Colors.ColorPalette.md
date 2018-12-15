# [WithoutHaste.Drawing.Colors](TableOfContents.WithoutHaste.Drawing.Colors.md).ColorPalette

**Inheritance:** object  

An ordered list of colors.  

# Properties

## Colors

**[System.Drawing.Color[]](https://docs.microsoft.com/en-us/dotnet/api/system.array) { public get; }**  

Colors in palette.  

## Count

**int { public get; }**  

Length of palette.  

# Constructors

## ColorPalette()

Initialize empty palette.  

## ColorPalette([System.Drawing.Color[]](https://docs.microsoft.com/en-us/dotnet/api/system.array) colors)

Initialize palette with _colors_.  

## ColorPalette([List&lt;System.Drawing.Color&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1) colors)

Initialize palette with _colors_.  

# Methods

## Add([System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) color)

**int**  

Add color to end of palette.  

**Returns:**  
Index of added color.  

## Clear()

**void**  

Remove all colors from palette.  

## Equals(object b)

**virtual bool**  

Palettes are equal if they contain the same colors in the same order.  
Colors are compared by Alpha/Red/Blue/Green, not by Name.  

## GetHashCode()

**virtual int**  

## Insert([System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) color, int index)

**void**  

Insert color at a position in the palette.  

## Remove([System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) color)

**void**  

Remove all instances of color from the palette.  

## RemoveAt(int index)

**void**  

Remove the color at a specific position in the palette.  

**Exceptions:**  
* **[IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception)**: Index is too low or too high for palette.  

## Replace([System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) oldColor, [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) newColor)

**void**  

Replace all instances of one color with another color.  

## ReplaceAt(int index, [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) newColor)

**void**  

Replace the color at a specific position with another color.  

**Exceptions:**  
* **[IndexOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception)**: Index is too low or too high for palette.  

## Save(string fullFilename)

**void**  

Save a color palette to file. Supported file formats: .aco, .gpl, .pal.  

**Exceptions:**  
* **[NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/system.notimplementedexception)**: Palette format not supported.  

# Static Methods

## ColorsMatch([System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) a, [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) b)

**static bool**  

Returns true if both colors have the same Alpha/Red/Green/Blue values,   
or if both colors are null.  

## Load(string fullFilename)

**static ColorPalette**  

Load a color palette from file. Supported file formats: .aco, .gpl, .pal.  

**Exceptions:**  
* **[NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/system.notimplementedexception)**: Palette format not supported.  

# Operators

## bool = ColorPalette a == ColorPalette b

Palettes are equal if they contain the same colors in the same order.  
Colors are compared by Alpha/Red/Blue/Green, not by Name.  

## bool = ColorPalette a != ColorPalette b

Palettes are equal if they contain the same colors in the same order.  
Colors are compared by Alpha/Red/Blue/Green, not by Name.  

