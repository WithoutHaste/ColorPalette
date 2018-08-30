# FormatPAL

Paint Shop Pro *.pal color palette file format.

Base Type: System.Object

## Properties

### ColorPalette ColorPalette

### String Header

### String Version

## Constructors

### FormatPAL(System.String fullFilename)

Load color palette from file.

Parameter fullFilename: Path + filename + extension.  

## Static Methods

### ColorPalette Load(System.String fullFilename)

Load and return color palette from file.

Parameter fullFilename: Path + filename + extension.  

### Void Save(System.String fullFilename, ColorPalette palette)

Save color palette in Version 0100 .pal format.

Parameter fullFilename: Path + filename + extension.  

## Methods

### Void Save(System.String fullFilename)

Save color palette in Version 0100 .pal format.

Parameter fullFilename: Path + filename + extension.  

