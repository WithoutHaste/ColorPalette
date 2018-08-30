# ConvertColors

Static type.

Convert colors between color spaces.

Supported color spaces:  
* Red/Green/Blue (RGB)  
* Hue/Saturation/Value (HSV)  
* Cyan/Magenta/Yellow/Black (CMYK)  
* Hexadecimal  

Base Type: System.Object

## Static Methods

### Color CMYKToColor(System.Single cyan, System.Single magenta, System.Single yellow, System.Single black)

Convert Cyan, Magenta, Yellow, Black to Color.

Parameter cyan: Range [0, 1]
Parameter magenta: Range [0, 1]
Parameter yellow: Range [0, 1]
Parameter black: Range [0, 1]

OutOfRangeException`1: Cyan or Magenta or Yellow or Black value is out of range.

### Color HexadecimalToColor(System.String hexadecimal)

Converts Hexadecimal string to Color.

Parameter hexadecimal: Format #RRGGBB or RRGGBB

ArgumentException: Hexadecimal string is not in supported format.

### Color HSVToColor(System.Single hue, System.Single saturation, System.Single value)

Convert from Hue, Saturation, Value to Color.

Parameter hue: Range [0, 360)
Parameter saturation: Range [0, 1]
Parameter value: Range [0, 1]

OutOfRangeException`1: Hue or Saturation or Value value is out of range.

### Color RGBToColor(System.Int32 red, System.Int32 green, System.Int32 blue)

Convert from Red, Green, Blue to Color.

Parameter red: Range [0, 255]
Parameter green: Range [0, 255]
Parameter blue: Range [0, 255]

OutOfRangeException`1: Red or Green or Blue value is out of range.

### Color ToColor(HSV hsv)

Convert [HSV](HSV.md) to Color.

### String ToHexadecimal(System.Drawing.Color color)

Converts Color to Hexadecimal string.

Returns: Format #RRGGBB

### HSV ToHSV(System.Drawing.Color color)

Converts Color to [HSV](HSV.md), ignoring Alpha.

## Methods

### TryParseHexadecimal(System.String, System.Drawing.Color@)

Attempts to convert Hexadecimal string to Color. Does not throw exceptions.

Returns: True, if parse is successful.

### TryParseHSV(System.String, System.Drawing.Color@)

Attempts to convert Hue, Saturation, Value string to Color. Does not throw exceptions.

Returns: True, if parse is successful.

### TryParseRGB(System.String, System.Drawing.Color@)

Attempts to convert Red, Green, Blue string to Color. Does not throw exceptions.

Returns: True, if parse is successful.

