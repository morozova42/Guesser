namespace GuessTheNumber
{
	//ISP - разделено угадывание и проверка возможности играть дальше
	public class SimpleDigitChecker : IChecker, IGuesser
	{
		private int _count = 0;
		private uint _secret;

		public SimpleDigitChecker()
		{
			Random rnd = new Random();
			_secret = (uint)rnd.Next((int)SettingsHelper.Settings.MinRange, (int)SettingsHelper.Settings.MaxRange);
		}

		#region IChecker implementation
		public string Message => "Guess the positive number";
		public bool CanGuess => _count < SettingsHelper.Settings.AttemptsCount;

		public int Increment()
		{
			return _count++;
		}
		#endregion

		#region IGuesser Implementation
		public dynamic Secret => _secret;
		public bool Success(dynamic number)
		{
			return number.CompareTo(_secret) == 0;
		}
		#endregion
	}
}
