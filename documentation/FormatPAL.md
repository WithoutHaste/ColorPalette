# FormatPAL object

Paint Shop Pro *.pal color palette file format operations.

`filename` always refers to the full path, filename, and extension.

## Properties

`ColorPalette`: the palette loaded from file, or to be saved to file.

`Header`: palette file header

`Version`: file format version

## Constructor

Loads a palette from file.

`new FormatPAL(filename)`

Possible exceptions:  
`FileNotFoundException`: file not found  
`ExtensionNotSupportedException`: file extension not supported  

## Static Methods

### Load

Load a color palette from file.

`ColorPalette palette = FormatPAL.Load(filename);`

Returns the color palette.

Possible exceptions:  
`FileNotFoundException`: file not found  
`ExtensionNotSupportedException`: file extension not supported  

### Save

Save a color palette to file.

`FormatPAL.Save(filename, colorPalette);`

## Methods

### Save

Save a color palette to file.

`formatPAL.Save(filename);`