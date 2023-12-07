namespace GuessTheNumber
{
	//SOLID LSP? - если его использовать вместо базового класса, то старая логика не сломается.
	//SOLID OCP? тут же, я не в старый класс добавила в метод, а сделала наследника
	public class SimpleNumberValidatorAndConsoleNotificator : SimpleNumberValidator
	{
		public void Notify()
		{
			Console.WriteLine(ValidateMessage);
		}
	}
}
