namespace GuessTheNumber
{
	public class Settings
	{
		public uint AttemptsCount { get; }
		public uint MinRange { get; }
		public uint MaxRange { get; }
		public Settings()
		{
			AttemptsCount = 5;
			MinRange = 0;
			MaxRange = 10;
		}

		public Settings(uint attemptsCount, uint minRange, uint maxRange)
		{
			AttemptsCount = attemptsCount;
			MinRange = minRange;
			MaxRange = maxRange;
		}
	}
}
