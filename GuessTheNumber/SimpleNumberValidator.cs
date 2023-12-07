namespace GuessTheNumber
{
	//SOLID SRP - только валидирует и конвертит в uint
	public class SimpleNumberValidator : IValidator
	{
		private uint? _result;
		private string _message;
		public dynamic Result => _result;

		public string ValidateMessage => string.IsNullOrWhiteSpace(_message) ? "Correct" : _message;

		public bool Invalid(string command)
		{
			if (uint.TryParse(command, out uint result))
			{
				_result = result;
				return false;
			}
			if (string.IsNullOrEmpty(command)) _message = "String is empty";
			else _message = "Cann't convert to Uint. It is not simple number";
			return true;
		}

	}
}
