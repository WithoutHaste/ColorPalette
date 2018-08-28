# WithoutHaste.Drawing.Colors

A C# library for color operations.  
- Load and save color palette formats: ACO, GPL, PAL  
- Convert colors between color spaces: RGB, HSV, CMYK, Hexadecimal  

Colors are passed as System.Drawing.Color.

This library is under active development. Report bugs and request features on Github, or to wohaste@gmail.com.

## Download

Library file located at Colors/bin/Release/WithoutHaste.Drawing.Colors.dll

## Requirements

System.Drawing.dll

## File Formats Supported

Palettes can be loaded/saved through the individual `Format` objects (see below) or through the `ColorPalette` object. When using the `ColorPalette` object, the file format is determined by the extension on the `filename`.

`
ColorPalette palette = ColorPalette.Load(filename);\
palette.Save(filename);
`

`filename` means the full path with file extension.

[ColorPalette object documentation](documentation/ColorPalette.md)

### Photoshop *.aco

Load from Version 1 and 2 with Color Space 0.

Save to Version 1 with Color Space 0.

`
ColorPalette palette = FormatACO.Load(filename);  
FormatACO.Save(palette, filename);  
`

[FormatACO object documentation](documentation/FormatACO.md)

### GIMP *.gpl

Load and save files.

`
ColorPalette palette = FormatGPL.Load(filename);  
FormatGPL.Save(palette, filename);  
`

[FormatGPL object documentation](documentation/FormatGPL.md)

### Paint Shop Pro *.pal

Load and save Version 0100 files.

`
ColorPalette palette = FormatPAL.Load(filename);  
FormatPAL.Save(palette, filename);  
`

[FormatPAL object documentation](documentation/FormatPAL.md)

## Color Space Conversions

All color space conversions are available in the static `ConvertColors` class.

[ConvertColors object documentation](documentation/ConvertColors.md)

## Version Notes

Version 1 in development.
