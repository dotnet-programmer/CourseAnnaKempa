namespace ConsoleMenu;

internal static class PerformanceIfAndSwitch
{
	private const int MAX = 1_000_000;
	private static readonly int[] _testArray = new int[MAX];

	public static void DoPerformanceTests()
	{
		LoadData();
		TestIfElse();
		TestSwitch();
		Console.ReadLine();
	}

	private static void LoadData()
	{
		for (int i = 0; i < MAX; i++)
		{
			_testArray[i] = i;
		}
	}

	private static void TestIfElse()
	{
		int t1, t2, number;
		t1 = Environment.TickCount;
		for (int j = 0; j < 100; j++)
		{
			for (int i = 0; i < MAX; i++)
			{
				if (_testArray[i] == 0)
				{
					number = 1;
				}
				else if (_testArray[i] == 1)
				{
					number = 2;
				}
				else if (_testArray[i] == 2)
				{
					number = 3;
				}
				else if (_testArray[i] == 3)
				{
					number = 4;
				}
				else if (_testArray[i] == 11_000)
				{
					number = 5;
				}
				else if (_testArray[i] == 22_000)
				{
					number = 6;
				}
				else if (_testArray[i] == 33_000)
				{
					number = 7;
				}
				else if (_testArray[i] == 44_000)
				{
					number = 8;
				}
				else if (_testArray[i] == 55_000)
				{
					number = 9;
				}
				else if (_testArray[i] == 66_000)
				{
					number = 10;
				}
			}
		}
		t2 = Environment.TickCount;
		Console.WriteLine($"if else if {t2 - t1}");
	}

	private static void TestSwitch()
	{
		int t1, t2, number;
		t1 = Environment.TickCount;
		for (int j = 0; j < 100; j++)
		{
			for (int i = 0; i < MAX; i++)
			{
				switch (_testArray[i])
				{
					case 0:
						number = 1;
						break;
					case 1:
						number = 2;
						break;
					case 2:
						number = 3;
						break;
					case 3:
						number = 4;
						break;
					case 11_000:
						number = 5;
						break;
					case 22_000:
						number = 6;
						break;
					case 33_000:
						number = 7;
						break;
					case 44_000:
						number = 8;
						break;
					case 55_000:
						number = 9;
						break;
					case 66_000:
						number = 10;
						break;
				}
			}
		}
		t2 = Environment.TickCount;
		Console.WriteLine($"switch {t2 - t1}");
	}
}