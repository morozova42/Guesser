using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
	public class AdminMode
	{
		private IValidator _validator;
		public AdminMode(IValidator validator)
		{
			_validator = validator;
		}

		public void Run()
		{
			Console.WriteLine("Now attempts count = " + SettingsHelper.Settings.AttemptsCount);
			Console.WriteLine("Now minimum value = " + SettingsHelper.Settings.MinRange);
			Console.WriteLine("Now maximum value = " + SettingsHelper.Settings.MaxRange);
			Console.WriteLine("***************************************");

			Console.WriteLine("Set the count of attempts or press Enter to skip");
			string attemptsStr = Console.ReadLine();
			uint attempts;
			while (!uint.TryParse(attemptsStr, out attempts) && !string.IsNullOrEmpty(attemptsStr))
			{
				Console.WriteLine("Incorrect.");
				attemptsStr = Console.ReadLine();
			}
			if (string.IsNullOrEmpty(attemptsStr)) attempts = SettingsHelper.Settings.AttemptsCount;

			Console.WriteLine("Set the minimum value or press Enter to skip");
			string minStr = Console.ReadLine();
			uint min;
			while (_validator.Invalid(minStr) && !string.IsNullOrEmpty(minStr))
			{
				Console.WriteLine("Incorrect.");
				minStr = Console.ReadLine();
			}
			if (_validator.Result != null) min = _validator.Result;
			else min = SettingsHelper.Settings.MinRange;

			Console.WriteLine("Set the maximum value or press Enter to skip");
			string maxStr = Console.ReadLine();
			uint max;
			while (_validator.Invalid(maxStr) && !string.IsNullOrEmpty(maxStr))
			{
				Console.WriteLine("Incorrect.");
				maxStr = Console.ReadLine();
			}
			if (_validator.Result != null) max = _validator.Result;
			else max = SettingsHelper.Settings.MaxRange;

			SettingsHelper.Update(new Settings(attempts, min, max));

			Console.WriteLine("***************************************");
			Console.WriteLine("Now attempts count = " + SettingsHelper.Settings.AttemptsCount);
			Console.WriteLine("Now minimum value = " + SettingsHelper.Settings.MinRange);
			Console.WriteLine("Now maximum value = " + SettingsHelper.Settings.MaxRange);

		}
	}
}
