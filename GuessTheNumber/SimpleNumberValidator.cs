namespace GuessTheNumber
{
	public class SimpleNumberValidator : IValidator
	{
		private uint? _result;
		public dynamic Result { get { return _result; } }
		public bool Invalid(string command)
		{
			if (uint.TryParse(command, out uint result))
			{
				_result = result;
				return false;
			}
			return true;
		}
	}
}
