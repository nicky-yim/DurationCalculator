# Duration Calculator
A little method that I wrote to calculate the duration between two dates. It is written in C# as I used it at work.

Given a `DateTime?`start date and `DateTime?`end date, return a `Tuple<int, int, int>`, in year(s), month(s) and day(s), that indicates the duration between the two dates.

# Example
```C#
DateTime startDate = new DateTime(2020, 02, 19);
DateTime endDate = new DateTime(2084, 02, 14);

Tuple<int, int, int> duration = GetDuration(startDate, endDate);
Console.WriteLine(String.Format("{0} is {1} year(s), {2} month(s) and {3} day(s) from {4}.",
	endDate.ToShortDateString(),
	duration.Item1,
	duration.Item2,
	duration.Item3,
	startDate.ToShortDateString())
);
```
##### Output
```14/2/2084 is 63 year(s), 11 month(s) and 26 day(s) from 19/2/2020.```
