# ColorPalette

An ordered list of colors.

Base Type: System.Object

## Properties

### Color[] Colors

Colors in palette.

### Int32 Count

Length of palette.

## Constructors

### ColorPalette()

## Static Methods

### ColorPalette Load(System.String fullFilename)

Load a color palette from file. Supported file formats: .aco, .gpl, .pal.

## Methods

### Int32 Add(System.Drawing.Color color)

Add color to end of palette.

Returns: Index of added color.

### Void Clear()

Remove all colors from palette.

### Void Insert(System.Drawing.Color color, System.Int32 index)

Insert color at a position in the palette.

### Void Remove(System.Drawing.Color color)

Remove all instances of color from the palette.

### Void RemoveAt(System.Int32 index)

Remove the color at a specific position in the palette.

IndexOutOfRangeException: Index is too low or too high for palette.

### Void Replace(System.Drawing.Color oldColor, System.Drawing.Color newColor)

Replace all instances of one color with another color.

### Void ReplaceAt(System.Int32 index, System.Drawing.Color newColor)

Replace the color at a specific position with another color.

IndexOutOfRangeException: Index is too low or too high for palette.

### Void Save(System.String fullFilename)

Save a color palette to file. Supported file formats: .aco, .gpl, .pal.

