using System.Diagnostics;
using System.Text;

namespace ConsoleMenu;

internal static class PerformanceStringAndStringBuilder
{
	private const int Iterations = 150_000;

	public static void TestMethod()
	{
		long timeString = TestString();
		long timeStringBuilderWithString = TestStringBuilderWithString();
		long timeStringBuilderWithChar = TestStringBuilderWithChar();

		Console.WriteLine($"String: {timeString}");
		Console.WriteLine($"StringBuilder with string: {timeStringBuilderWithString}");
		Console.WriteLine($"StringBuilder with char: {timeStringBuilderWithChar}");
		Console.WriteLine($"String / StringBuilderWithChar: {timeString / timeStringBuilderWithChar}");
		Console.ReadLine();
	}

	private static long TestString()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		string text = string.Empty;
		for (int i = 0; i < Iterations; i++)
		{
			text += "A";
		}
		stopwatch.Stop();
		return stopwatch.ElapsedTicks;
	}

	private static long TestStringBuilderWithString()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		StringBuilder text = new();
		for (int i = 0; i < Iterations; i++)
		{
			text.Append("A");
		}
		stopwatch.Stop();
		return stopwatch.ElapsedTicks;
	}

	private static long TestStringBuilderWithChar()
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		StringBuilder text = new();
		for (int i = 0; i < Iterations; i++)
		{
			text.Append('A');
		}
		stopwatch.Stop();
		return stopwatch.ElapsedTicks;
	}
}