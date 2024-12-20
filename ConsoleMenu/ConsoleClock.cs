﻿namespace ConsoleMenu;

internal static class ConsoleClock
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

	private const int NumberOfLines = 7;

	public static void ShowTime()
	{
		Console.Title = "Zegar";
		Console.CursorVisible = false;
		Thread t = new(new ThreadStart(ActualTime));
		t.Start();
		Console.ReadLine();
		Environment.Exit(0);
	}

	private static void ActualTime()
	{
		while (true)
		{
			DateTime date = DateTime.Now;
			//Console.WriteLine(date.ToString("HH:mm:ss"));
			Clock(date.ToString("HH:mm:ss"));
			Thread.Sleep(1000);
		}
	}

	private static void Clock(string time)
	{
		int digit;
		for (int i = 0; i < NumberOfLines; i++)
		{
			Console.SetCursorPosition((Console.WindowWidth / 2) - _timeHalfWidth, (Console.WindowHeight / 2) - _timeHalfHeight + i);
			for (int j = 0; j < time.Length; j++)
			{
				// 48 to kod znaku '0', zamiana znaków char ze stringa time na liczbę, która jest odpowiednikiem tego znaku
				// 10, bo to 11 znak (kolumna) w tablicy _digits oznaczający dwukropek
				digit = time[j] != ':' ? time[j] - 48 : 10;
				Console.Write(_digits[i, digit] + " ");
			}
			Console.WriteLine();
		}
	}
}