# [WithoutHaste.Drawing.Colors](TableOfContents.WithoutHaste.Drawing.Colors.md).FormatPAL

**Inheritance:** object  
**Implements:** [IPaletteFormat](WithoutHaste.Drawing.Colors.IPaletteFormat.md)  

Paint Shop Pro *.pal color palette file format.  

# Properties

## ColorPalette

**[ColorPalette](WithoutHaste.Drawing.Colors.ColorPalette.md) { public get; }**  

## Header

**string { public get; protected set; }**  

## Version

**string { public get; protected set; }**  

# Constructors

## FormatPAL(string fullFilename)

Load color palette from file.  

**Parameters:**  
* **string fullFilename**: Path + filename + extension.  

# Methods

## Save(string fullFilename)

**void**  

Save color palette in Version 0100 .pal format.  

**Parameters:**  
* **string fullFilename**: Path + filename + extension.  

# Static Methods

## Load(string fullFilename)

**static [ColorPalette](WithoutHaste.Drawing.Colors.ColorPalette.md)**  

Load and return color palette from file.  

**Parameters:**  
* **string fullFilename**: Path + filename + extension.  

## Save(string fullFilename, [ColorPalette](WithoutHaste.Drawing.Colors.ColorPalette.md) palette)

**static void**  

Save color palette in Version 0100 .pal format.  

**Parameters:**  
* **string fullFilename**: Path + filename + extension.  

