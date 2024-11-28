using System.Globalization;

namespace ConsoleMenu;

internal class FormattingDateAndTime
{
	public static void DateAndTime()
	{
		Console.Title = "Formatowanie daty i czasu";
		DateTime date = DateTime.Now;
		Console.WriteLine($"default  - {date}");
		Console.WriteLine($"MM-yyyy  - {date:MM-yyyy}");
		Console.WriteLine($"hh:mm:ss - {date:hh:mm:ss}");
		Console.WriteLine($"HH:mm:ss - {date:HH:mm:ss}");
		Console.WriteLine($"d MMMM   - {date:d MMMM}");
		Console.WriteLine($"d MMMM en-US - {date.ToString("d MMMM", CultureInfo.CreateSpecificCulture("en-US"))}");
		Console.WriteLine();
		Console.WriteLine($"d - {date:d}");
		Console.WriteLine($"D - {date:D}");
		Console.WriteLine($"Y - {date:Y}");
		Console.WriteLine($"T - {date:T}");
		Console.WriteLine($"T en-US - {date.ToString("T", CultureInfo.CreateSpecificCulture("en-US"))}");
		Console.ReadLine();
	}
}