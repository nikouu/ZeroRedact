# Date

The following show examples of all the date redactor types:

```csharp
var redactor = new Redactor();
var date = new DateTime(2023, 6, 15);

// Uses default redactor (Full)
// returns 
// en-NZ: "**/**/****"
// en-US: "*/**/****"
// ja-JP: "****/**/**"
// InvariantCulture: "**/**/****"
var fullRedaction = redactor.RedactDate(date);

// returns
// en-NZ: "*********"
// en-US: "********"
// ja-JP: "*********"
// InvariantCulture: "*********"
var allOptions = new DateRedactorOptions { RedactorType = DateRedaction.All };
var allRedaction = redactor.RedactDate(date, allOptions);

// returns
// en-NZ: "********"
// en-US: "********"
// ja-JP: "********"
// InvariantCulture: "********"
var fixedLengthOptions = new DateRedactorOptions { RedactorType = DateRedaction.FixedLength };
var fixedLengthRedaction = redactor.RedactDate(date, fixedLengthOptions);

// returns
// en-NZ: "**/06/2023"
// en-US: "6/**/2023"
// ja-JP: "2023/06/**"
// InvariantCulture: "06/**/2023"
var dayOptions = new DateRedactorOptions { RedactorType = DateRedaction.Day };
var dayRedaction = redactor.RedactDate(date, dayOptions);

// returns
// en-NZ: "15/**/2023"
// en-US: "*/15/2023"
// ja-JP: "2023/**/15"
// InvariantCulture: "**/15/2023"
var monthOptions = new DateRedactorOptions { RedactorType = DateRedaction.Month };
var monthRedaction = redactor.RedactDate(date, monthOptions);

// returns
// en-NZ: "15/06/****"
// en-US: "6/15/****"
// ja-JP: "****/06/15"
// InvariantCulture: "06/15/****"
var yearOptions = new DateRedactorOptions { RedactorType = DateRedaction.Year };
var yearRedaction = redactor.RedactDate(date, yearOptions); 

// returns
// en-NZ: "**/**/2023"
// en-US: "*/**/2023"
// ja-JP: "2023/**/**"
// InvariantCulture: "**/**/2023"
var dayAndMonthOptions = new DateRedactorOptions { RedactorType = DateRedaction.DayAndMonth };
var dayAndMonthRedaction = redactor.RedactDate(date, dayAndMonthOptions); 

// returns
// en-NZ: "15/**/****"
// en-US: "*/15/****"
// ja-JP: "****/**/15"
// InvariantCulture: "**/15/****"
var monthAndYearOptions = new DateRedactorOptions { RedactorType = DateRedaction.MonthAndYear };
var monthAndYearRedaction = redactor.RedactDate(date, monthAndYearOptions); 

// returns
// en-NZ: "**/06/****"
// en-US: "6/**/****"
// ja-JP: "****/06/**"
// InvariantCulture: "06/**/****"
var dayAndYearOptions = new DateRedactorOptions { RedactorType = DateRedaction.DayAndYear };
var dayAndYearRedaction = redactor.RedactDate(date, dayAndYearOptions);
```