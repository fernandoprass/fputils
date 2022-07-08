# FPUtils
FPUtil is a Nuget package for Visual Studio that contains a set of extensions, utilities, and a response class.

## Extensions

- DateTimeExtension
    - FirstDayOfMonth() - Return the first day of the mounth for a given date
    - DaysInMonth() - Return the number of days in the mounth for a given date
    - LastDayOfMonth() - Return the last day of the mounth for a given date
- DecimalExtension
    - EqualZero() - Return true if the value is equal zero
    - GreaterThanZero() - Return true if the value is greater than zero
    - GreaterThanOrEqualZero() - Return true if the value is greater than or equal zero
    - LessThanZero() - Return true if the value is less than zero
    - LessThanOrEqualZero() - Return true if the value is less than or equal zero
- EnumerableExtensions
    - HasData() - Return the if the collection object is not null and has any record
- EnumExtensions
    - GetDescription() - Return the enumerator description as a string
- GuidExtension
    - IsEmpty() - Return true if the guid is empty
    - IsNotEmpty() - Return true if the guid is not empty
- ObjectExtension
    - IsNull() - Return true if the guid is null
    - IsNotNull() - Return true if the guid is not null
- StringExtension
    - KeepOnlyNumbers() - Remove letters and simbols, keeping only numbers
    - KeepOnlyNumbersAndLetters() - Remove simbols keeping only numbers and letters  
    - KeepOnlyNumbersAndLettersAndSpaces() - Remove simbols keeping only numbers, letters and spaces 
    - RemoveAccents() - Remove accents

## Response

- Result: a set of classes to be used as a return in APIs

## Utilities

- Security
    - Encrypt() - Encrypt a string
    - Decrypt() - Decrypt a string


## Installation

Package Manager Console:

```sh
Install-Package FPUtils -Version 0.0.1
```

Package Reference (editing the Project File):
```sh
<PackageReference Include="FPUtils" Version="0.0.1" />
```

.NET.CLI:
```sh
dotnet add package FPUtils --version 0.0.1
```

Change 0.0.1 for the current version

**Free Software, Hell Yeah!**

Develeped by Fernando Prass

