using System.Globalization;

namespace ConsoleMenu;

internal class FormattingDateAndTime
{
	public static void DateAndTime()
	{
		Console.Title = "Formatowanie daty i czasu";
		DateTime date = DateTime.Now;
		Console.WriteLine(date.ToString());
		Console.WriteLine(date.ToString("MM-yyyy"));
		Console.WriteLine(date.ToString("hh:mm:ss"));
		Console.WriteLine(date.ToString("HH:mm:ss"));
		Console.WriteLine(date.ToString("d MMMM"));
		Console.WriteLine(date.ToString("d MMMM", CultureInfo.CreateSpecificCulture("en-US")));
		Console.WriteLine();
		Console.WriteLine(date.ToString("d"));
		Console.WriteLine(date.ToString("D"));
		Console.WriteLine(date.ToString("Y"));
		Console.WriteLine(date.ToString("T"));
		Console.WriteLine(date.ToString("T", CultureInfo.CreateSpecificCulture("en-US")));
		Console.ReadLine();
	}
}