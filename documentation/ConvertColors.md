# ConvertColors static object

Convert colors between color spaces.

## Color Spaces

### Red/Green/Blue

Red, Green, and Blue values are all in the range [0, 255].

### Hue/Saturation/Value

Hue is in the range [0, 360).

Saturation and Value are in the range [0, 1].

## Objects

System.Drawing.Color: alpha, red, green, blue color space

HSV: hue, saturation, value color space

## To System.Drawing.Color

From Red/Green/Blue:  
`ConvertColors.RGBToColor(red, green, blue);`

From Red/Green/Blue:  
Formats: "rgb(red, green, blue)" or "(red, green, blue)" or "red, green, blue"  
```
System.Drawing.Color color;
string rgb = "rgb(255, 0, 0)";
bool success = ConvertColors.TryParseRGB(rgb, out color);
```

From Cyan/Magenta/Yellow/Black:  
`ConvertColors.CMYKToColor(cyan, magenta, yellow, black);`

From Hue/Saturation/Value:  
`ConvertColors.HSVToColor(hue, saturation, value);`

From HSV:  
`ConvertColors.ToColor(hsv);`

From Hue/Saturation/Value:  
Formats: "hsv(hue, saturation, value)" or "(hue, saturation, value)" or "hue, saturation, value"  
```
System.Drawing.Color color;
string hsv = "hsv(0, 1, 1)";
bool success = ConvertColors.TryParseHSV(hsv, out color);
```

From Hexadecimal string:  
Formats: "#RRGGBB" or "RRGGBB"  
`ConvertColors.HexadecimalToColor(hexadecimal);`

From Hexadecimal string:  
Formats: "#RRGGBB" or "RRGGBB"  
```
System.Drawing.Color color;
string hexadecimal = "#FF0000";
bool success = ConvertColors.TryParseHexadecimal(hexadecimal, out color);
```

## To HSV

From System.Drawing.Color:  
`ConvertColors.ToHSV(color);`

## To Hexadecimal string

Format: #RRGGBB

From System.Drawing.Color:  
`ConvertColors.ToHexadecimal(color);`
