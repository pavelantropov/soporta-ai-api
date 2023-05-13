using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using SoportaAI.Utils.Extensions;

namespace SoportaAI.Configuration.Settings;

// TODO
public class AppSettings : IAppSettings
{
	private readonly IFormatProvider _formatProvider;

	public AppSettings([NotNull]IFormatProvider formatProvider)
	{
		_formatProvider = formatProvider;
	}

	public T Get<T>(string key)
	{
		var settingString = "";//ConfigurationManager.AppSettings[key];
		if (settingString.IsNullOrEmpty()) return default; //!!!

		return (T) Convert.ChangeType(settingString, typeof(T), _formatProvider);
	}
}