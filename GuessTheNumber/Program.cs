namespace GuessTheNumber
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Type set to correct and save settings. Or press Enter to play!");
			var command = Console.ReadLine();
			while (command == "set")
			{
				AdminMode admin = new AdminMode(new SimpleNumberValidator());
				admin.Run();
				Console.WriteLine("Type set to correct and save settings. Or press Enter to play!");
				command = Console.ReadLine();
			}
			GameMode guesserService = new GameMode(new SimpleNumberValidator(), new SimpleDigitChecker(), new SimpleDigitChecker());
			guesserService.Run();
		}
	}
}