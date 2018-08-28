# FormatGPL object

GIMP *.gpl color palette file format operations.

`filename` always refers to the full path, filename, and extension.

## Properties

`ColorPalette`: the palette loaded from file, or to be saved to file.

`Header`: palette file header

`Name`: palette name

## Constructor

Loads a palette from file.

`new FormatGPL(filename)`

Possible exceptions:  
`FileNotFoundException`: file not found  
`ExtensionNotSupportedException`: file extension not supported  

## Static Methods

### Load

Load a color palette from file.

`ColorPalette palette = FormatGPL.Load(filename);`

Returns the color palette.

Possible exceptions:  
`FileNotFoundException`: file not found  
`ExtensionNotSupportedException`: file extension not supported  

### Save

Save a color palette to file.

`FormatGPL.Save(filename, colorPalette);`

## Methods

### Save

Save a color palette to file.

`formatGPL.Save(filename);`