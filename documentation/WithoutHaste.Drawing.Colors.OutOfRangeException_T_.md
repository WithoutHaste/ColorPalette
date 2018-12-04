# [WithoutHaste.Drawing.Colors](TableOfContents.WithoutHaste.Drawing.Colors.md).OutOfRangeException<T>

**Inheritance:** object → [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) → [SystemException](https://docs.microsoft.com/en-us/dotnet/api/system.systemexception) → [ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)  
**Implements:** [System.Runtime.Serialization.ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable), [System.Runtime.InteropServices._Exception](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices._exception)  

Value was not in the expected range.  

# Fields

## Maximum

**readonly T**  

Range maximum.  

## Minimum

**readonly T**  

Range minimum.  

## Type

**readonly [RangeType](WithoutHaste.Drawing.Colors.RangeType.md)**  

Type of range.  

## Value

**readonly T**  

Value that was out of range.  

# Constructors

## OutOfRangeException<T>(string message, string paramName,  minimum,  maximum, [RangeType](WithoutHaste.Drawing.Colors.RangeType.md) type,  value)

