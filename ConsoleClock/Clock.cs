﻿namespace ConsoleClock;

internal static class Clock
{
	private static readonly string[,] _digits =
	{
		{"XXXXX", "   X ", " XXX ", "XXXXX", "   X ", "XXXXX", "XXXXX", "XXXXX", "XXXXX", "XXXXX", "     " },
		{"X   X", " X X ", "X   X", "    X", "  XX ", "X    ", "X    ", "    X", "X   X", "X   X", "     " },
		{"X   X", "X  X ", "    X", "    X", " X X ", "X    ", "X    ", "   X ", "X   X", "X   X", "  X  " },
		{"X   X", "   X ", "   X ", " XXXX", "X  X ", "XXXXX", "XXXXX", "  X  ", "XXXXX", "XXXXX", "     " },
		{"X   X", "   X ", "  X  ", "    X", "XXXXX", "    X", "X   X", " X   ", "X   X", "    X", "  X  " },
		{"X   X", "   X ", " X   ", "    X", "   X ", "    X", "X   X", " X   ", "X   X", "    X", "     " },
		{"XXXXX", "   X ", "XXXXX", "XXXXX", "   X ", "XXXXX", "XXXXX", " X   ", "XXXXX", "XXXXX", "     " },
	};

	private static readonly int _timeHalfWidth = (8 * 5 + 7) / 2;
	private static readonly int _timeHalfHeight = 4;

	public static void ShowTime(ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.Title = "Clock";
		Console.CursorVisible = false;

		//Thread t = new(new ThreadStart(ActualTime));
		//t.Start();
		//Console.ReadLine();
		//Environment.Exit(0);

		Task clockTask = Task.Run(ActualTime);
		clockTask.Wait();
		//ActualTime();
	}

	private static void ActualTime()
	{
		while (true)
		{
			Console.Clear();
			DateTime date = DateTime.Now;
			DrawClock(date.ToString("HH:mm:ss"));
			Thread.Sleep(1000);
		}
	}

	private static void DrawClock(string time)
	{
		for (int i = 0; i < 7; i++)
		{
			Console.SetCursorPosition((Console.WindowWidth / 2) - _timeHalfWidth, (Console.WindowHeight / 2) - _timeHalfHeight + i);
			for (int j = 0; j < time.Length; j++)
			{
				int digit = time[j] != ':' ? time[j] - 48 : 10;
				Console.Write(_digits[i, digit] + " ");
			}
			Console.WriteLine();
		}
	}
}