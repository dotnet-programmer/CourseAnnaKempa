namespace ConsoleMenu;

internal static class SimpleMenu
{
	public static void StartSimpleMenu()
	{
		Console.Title = "Simple menu";

		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Clear();
			Console.WriteLine(">>> MENU <<<");
			Console.WriteLine("1 - Wydajność if else i switch case");
			Console.WriteLine("2 - String and StringBuilder");
			Console.WriteLine("3 - Data i czas");
			Console.WriteLine("4 - Zegarek");
			Console.WriteLine("5 - Koniec");
			Console.Write(">");
			ConsoleKeyInfo clickedKey = Console.ReadKey();
			Console.Clear();
			switch (clickedKey.Key)
			{
				case ConsoleKey.D1:
					PerformanceIfAndSwitch.DoPerformanceTests();
					break;
				case ConsoleKey.D2:
					PerformanceStringAndStringBuilder.TestMethod();
					break;
				case ConsoleKey.D3:
					FormattingDateAndTime.DateAndTime();
					break;
				case ConsoleKey.D4:
					ConsoleClock.ShowTime();
					break;
				case ConsoleKey.Escape:
				case ConsoleKey.D5:
					Environment.Exit(0);
					break;
				default:
					break;
			}
		}
	}

	private static void MethodInConstruction()
	{
		Console.WriteLine("Opcja w budowie");
		Console.ReadLine();
	}
}