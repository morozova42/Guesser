using System.Text;
using System.Text.Json;

namespace GuessTheNumber
{
	//SRP - только с настройкой работает
	public static class SettingsHelper
	{
		private static Settings _instance;
		public static Settings Settings
		{
			get
			{
				if (_instance == null) _instance = Load();
				return _instance;
			}
		}

		internal static void Update(Settings newSettings)
		{
			var path = Environment.CurrentDirectory;
			path = Path.Combine(path, "settings");

			using (FileStream stream = File.Create(path))
			{
				var data = JsonSerializer.Serialize(newSettings);
				byte[] buffer = Encoding.Default.GetBytes(data);
				stream.Write(buffer, 0, buffer.Length);
			}
			_instance = newSettings;
		}

		private static Settings Load()
		{
			var path = Environment.CurrentDirectory;
			path = Path.Combine(path, "settings");
			if (File.Exists(path))
			{
				return JsonSerializer.Deserialize<Settings>(File.ReadAllText(path));
			}
			return new Settings();
		}
	}
}
