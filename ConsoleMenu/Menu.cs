namespace ConsoleMenu;

internal static class Menu
{
	private static readonly string[] _menuPositions =
		[
			"1 - Wydajność if else i switch case",
			"2 - String and StringBuilder",
			"3 - Data i czas",
			"4 - Zegarek",
			"Opcja 5",
			"Koniec",
		];

	private static readonly int _lastMenuPosition = _menuPositions.Length - 1;

	private static int _activeMenuPosition = 0;

	public static void StartMenu()
	{
		Console.Title = "Tytuł konsoli";
		Console.CursorVisible = false;

		while (true)
		{
			ShowMenu();
			SetOption();
			StartOption();
		}
	}

	private static void ShowMenu()
	{
		SetDefaultColors();
		ShowHeader();
		ShowPositions();

		static void ShowHeader()
		{
			Console.Clear();
			Console.WriteLine(">>> MENU <<<");
			Console.WriteLine();
		}

		static void ShowPositions()
		{
			for (int i = 0; i < _menuPositions.Length; i++)
			{
				if (i == _activeMenuPosition)
				{
					SetActivePositionColors();
					Console.WriteLine($"{_menuPositions[i],-40}");
					SetDefaultColors();
				}
				else
				{
					Console.WriteLine(_menuPositions[i]);
				}
			}
		}
	}

	private static void SetDefaultColors()
	{
		Console.BackgroundColor = ConsoleColor.Gray;
		Console.ForegroundColor = ConsoleColor.DarkCyan;
	}

	private static void SetActivePositionColors()
	{
		Console.BackgroundColor = ConsoleColor.DarkCyan;
		Console.ForegroundColor = ConsoleColor.White;
	}

	private static void SetOption()
	{
		while (true)
		{
			ConsoleKeyInfo clickedKey = Console.ReadKey();

			if (clickedKey.Key == ConsoleKey.UpArrow)
			{
				_activeMenuPosition = (_activeMenuPosition > 0) ? _activeMenuPosition - 1 : _lastMenuPosition;
				ShowMenu();
			}
			else if (clickedKey.Key == ConsoleKey.DownArrow)
			{
				//_activeMenuPosition = (_activeMenuPosition < _lastMenuPosition) ? _activeMenuPosition + 1 : 0;
				// to samo, tylko z użyciem modulo
				_activeMenuPosition = (_activeMenuPosition + 1) % _menuPositions.Length;
				ShowMenu();
			}
			else if (clickedKey.Key == ConsoleKey.Escape)
			{
				_activeMenuPosition = _lastMenuPosition;
				break;
			}
			else if (clickedKey.Key == ConsoleKey.Enter)
			{
				break;
			}
		}
	}

	private static void StartOption()
	{
		Console.Clear();
		switch (_activeMenuPosition)
		{
			case 0:
				PerformanceIfAndSwitch.DoPerformanceTests();
				break;
			case 1:
				PerformanceStringAndStringBuilder.TestMethod();
				break;
			case 2:
				FormattingDateAndTime.DateAndTime();
				break;
			case 3:
				ConsoleClock.ShowTime();
				break;
			case 4:
				MethodInConstruction();
				break;
			case 5:
				Environment.Exit(0);
				break;
			default:
				break;
		}
	}

	private static void MethodInConstruction()
	{
		Console.SetCursorPosition(12, 4);
		Console.WriteLine("Opcja w budowie");
		Console.ReadLine();
	}
}