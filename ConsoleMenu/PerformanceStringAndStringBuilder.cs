using System.Diagnostics;
using System.Text;

namespace ConsoleMenu;

internal static class PerformanceStringAndStringBuilder
{
	private const int _iterations = 150_000;

	public static void TestMethod()
	{
		long timeString = TestString();
		long timeStringBuilder = TestStringBuilder();
		Console.WriteLine($"String: {timeString}");
		Console.WriteLine($"StringBuilder: {timeStringBuilder}");
		Console.WriteLine($"String / StringBuilder: {timeString / timeStringBuilder}");
		Console.ReadLine();
	}

	private static long TestString()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		string text = string.Empty;
		for (int i = 0; i < _iterations; i++)
		{
			text += "A";
		}
		stopwatch.Stop();
		return stopwatch.ElapsedTicks;
	}

	private static long TestStringBuilder()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		StringBuilder text = new();
		for (int i = 0; i < _iterations; i++)
		{
			text.Append('A');
		}
		stopwatch.Stop();
		return stopwatch.ElapsedTicks;
	}
}