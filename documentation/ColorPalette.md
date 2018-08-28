# ColorPalette object

An ordered list of colors.

## Properties

Colors: list of System.Drawing.Color objects which make up the palette

Count: number of colors in the palette

## Constructor

Parameterless constructor: `new ColorPalette()`

## Static Methods

### Load

Load a color palette file. File format is determined by the extension of the `filename`. Include full path in `filename`.

`ColorPalette palette = ColorPalette.Load(filename);`

Possible exceptions:  
`NotImplementedException`: file format is not yet supported

[Full list of supported formats on main page.](../README.md)

## Methods

### Save

Save a color palette to file. File format is determined by the extension of the `filename`. Include full path in `filename`.

`palette.Save(filename);`

Possible exceptions:  
`NotImplementedException`: file format is not yet supported

[Full list of supported formats on main page.](../README.md)

### Add

Add a color to the end of the palette.

`int index = palette.Add(color);`

Returns the index of the color in the palette.

### Clear

Remove all colors from the palette.

`palette.Clear();`

### Insert

Insert a color into a position in the palette.

`palette.Insert(color, index);`

### Remove

Remove the first instance of a color from the palette.

`palette.Remove(color);`

### RemoveAt

Remove a specified color from the palette, by the index position of the color.

`palette.RemoveAt(index);`

Possible exceptions:  
`IndexOutOfRangeException`: index is not valid for palette length

### Replace

Replace all instances of a color in the palette with a new color.

`palette.Replace(oldColor, newColor);`

### ReplaceAt

Replace the color at a specified index position in the palette with a new color.

`palette.Replace(index, newColor);`

Possible exceptions:  
`IndexOutOfRangeException`: index is not valid for palette length
