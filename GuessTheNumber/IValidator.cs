namespace GuessTheNumber
{
	//OCP? - сюда можно ещё добавить вывод сообщения-подсказки, почему строка инвалид
	public interface IValidator
	{
		dynamic Result { get; }
		public bool Invalid(string message);
	}
}
