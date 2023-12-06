namespace GuessTheNumber
{
	public interface IGuesser
	{
		dynamic Secret { get; }
		bool Success(dynamic obj);
	}
}
