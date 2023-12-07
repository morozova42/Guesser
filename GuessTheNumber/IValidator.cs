namespace GuessTheNumber
{
	public interface IValidator
	{
		dynamic Result { get; }
		string ValidateMessage { get; }
		public bool Invalid(string message);
	}
}
