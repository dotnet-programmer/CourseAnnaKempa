namespace ConsoleClock;

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

	private const int NumberOfLines = 7;

	public static void ShowTime(ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.Title = "Clock";
		Console.CursorVisible = false;

		Task clockTask = Task.Run(ActualTime);
		clockTask.Wait();
	}

	private static void ActualTime()
	{
		while (true)
		{
			DateTime date = DateTime.Now;
			DrawClock(date.ToString("HH:mm:ss"));

			// synchroniczne opóźnienie - blokuje wątek główny
			Thread.Sleep(1000);

			// asynchroniczne wstrzymanie wykonania - nie blokuje wątku głównego
			//await Task.Delay(3000);
		}
	}

	private static void DrawClock(string time)
	{
		for (int i = 0; i < NumberOfLines; i++)
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