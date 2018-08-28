# FormatACO object

Photoshop *.aco color palette file format operations.

`filename` always refers to the full path, filename, and extension.

## Properties

`ColorPalette`: the palette loaded from file, or to be saved to file.

## Constructor

Loads a palette from file.

`new FormatACO(filename)`

Possible exceptions:  
`FileNotFoundException`: file not found  
`ExtensionNotSupportedException`: file extension for supported  

## Static Methods

### Load

Loads a color palette from file and returns it.

`ColorPalette palette = FormatACO.Load(filename);`

Possible exceptions:  
`FileNotFoundException`: file not found  
`ExtensionNotSupportedException`: file extension for supported  

### Save

Save a color palette to file.

`FormatACO.Save(filename, colorPalette);`

## Methods

### Save

Save a color palette to file.

`formatACO.Save(filename);`