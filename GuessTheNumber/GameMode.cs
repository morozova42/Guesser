namespace GuessTheNumber
{
	internal class GameMode
	{
		private IValidator _validator;
		private IChecker _checker;
		private IGuesser _guesser;

		//DIP - игра может сменить проверку ввода и проверку допустимости угадываний без изменений кода
		//OCP? - не проверяет сам, что будем угадывать, а спрашивает у валидатора и угадывалки
		internal GameMode(IValidator validator, IChecker checker, IGuesser guesser)
		{
			_validator = validator;
			_checker = checker;
			_guesser = guesser;
		}

		internal void Run()
		{
			Console.WriteLine($"{_checker.Message} between {SettingsHelper.Settings.MinRange} and {SettingsHelper.Settings.MaxRange}");
			while (_checker.CanGuess)
			{
				var command = Console.ReadLine();
				if (_validator.Invalid(command))
				{
					Console.WriteLine("This string is incorrect :(");
					continue;
				}
				int count =_checker.Increment();
				if (_guesser.Success(_validator.Result))
				{
					Console.WriteLine($"You win! Amazing! It takes {count} attempts");
					return;
				}
				Console.WriteLine("Nope, sorry");
			}
			Console.WriteLine("your attempts are over. It was " + _guesser.Secret);
		}
	}
}
