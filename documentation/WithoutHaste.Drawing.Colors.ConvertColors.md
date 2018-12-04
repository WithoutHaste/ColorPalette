# [WithoutHaste.Drawing.Colors](TableOfContents.WithoutHaste.Drawing.Colors.md).ConvertColors

**Static**  
**Inheritance:** object  

Convert colors between color spaces.  

**Remarks:**  
* Supported color spaces:  
* Red/Green/Blue (RGB)  
* Hue/Saturation/Value (HSV)  
* Cyan/Magenta/Yellow/Black (CMYK)  
* Hexadecimal  

# Static Methods

## CMYKToColor(float cyan, float magenta, float yellow, float black)

**static [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color)**  

Convert Cyan, Magenta, Yellow, Black to Color.  

**Exceptions:**  
* **[OutOfRangeException](WithoutHaste.Drawing.Colors.OutOfRangeException_T_.md)**: Cyan or Magenta or Yellow or Black value is out of range.  

**Parameters:**  
* **float cyan**: Range [0, 1]  
* **float magenta**: Range [0, 1]  
* **float yellow**: Range [0, 1]  
* **float black**: Range [0, 1]  

## HexadecimalToColor(string hexadecimal)

**static [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color)**  

Converts Hexadecimal string to Color.  

**Exceptions:**  
* **[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)**: Hexadecimal string is not in supported format.  

**Parameters:**  
* **string hexadecimal**: Format #RRGGBB or RRGGBB  

## HSVToColor(float hue, float saturation, float value)

**static [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color)**  

Convert from Hue, Saturation, Value to Color.  

**Exceptions:**  
* **[OutOfRangeException](WithoutHaste.Drawing.Colors.OutOfRangeException_T_.md)**: Hue or Saturation or Value value is out of range.  

**Parameters:**  
* **float hue**: Range [0, 360)  
* **float saturation**: Range [0, 1]  
* **float value**: Range [0, 1]  

## RGBToColor(int red, int green, int blue)

**static [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color)**  

Convert from Red, Green, Blue to Color.  

**Exceptions:**  
* **[OutOfRangeException](WithoutHaste.Drawing.Colors.OutOfRangeException_T_.md)**: Red or Green or Blue value is out of range.  

**Parameters:**  
* **int red**: Range [0, 255]  
* **int green**: Range [0, 255]  
* **int blue**: Range [0, 255]  

## ToColor([HSV](WithoutHaste.Drawing.Colors.HSV.md) hsv)

**static [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color)**  

Convert [HSV](WithoutHaste.Drawing.Colors.HSV.md) to Color.  

## ToHexadecimal([System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) color)

**static string**  

Converts Color to Hexadecimal string.  

**Returns:**  
Format #RRGGBB  

## ToHSV([System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) color)

**static [HSV](WithoutHaste.Drawing.Colors.HSV.md)**  

Converts Color to [HSV](WithoutHaste.Drawing.Colors.HSV.md), ignoring Alpha.  

## TryParseHexadecimal(string text, out [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) color)

**static bool**  

Attempts to convert Hexadecimal string to Color. Does not throw exceptions.  

**Remarks:**  
Supported formats: #RRGGBB and RRGGBB.  

**Returns:**  
True, if parse is successful.  

## TryParseHSV(string text, out [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) color)

**static bool**  

Attempts to convert Hue, Saturation, Value string to Color. Does not throw exceptions.  

**Remarks:**  
Supported formats: hsv(H,S,V) and (H,S,V) and H,S,V.  

**Returns:**  
True, if parse is successful.  

## TryParseRGB(string text, out [System.Drawing.Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) color)

**static bool**  

Attempts to convert Red, Green, Blue string to Color. Does not throw exceptions.  

**Remarks:**  
Supported formats: rgb(R,G,B) and (R,G,B) and R,G,B.  

**Returns:**  
True, if parse is successful.  

