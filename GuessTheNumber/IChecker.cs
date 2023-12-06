namespace GuessTheNumber
{
	public interface IChecker
	{
		bool CanGuess { get; }
		string Message { get; }
		int Increment();
	}
}
