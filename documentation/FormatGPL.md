# FormatGPL

GIMP *.gpl color palette file format.

Base Type: System.Object

## Properties

### ColorPalette ColorPalette

### String Header

### String Name

## Constructors

### FormatGPL(System.String fullFilename)

Load color palette from file.

Parameter fullFilename: Path + filename + extension.  

## Static Methods

### ColorPalette Load(System.String fullFilename)

Load and return color palette from file.

Parameter fullFilename: Path + filename + extension.  

### Void Save(System.String fullFilename, ColorPalette palette)

Save color palette in standard .gpl format

Parameter fullFilename: Path + filename + extension.  

## Methods

### Void Save(System.String fullFilename)

Save color palette in standard .gpl format

Parameter fullFilename: Path + filename + extension.  

