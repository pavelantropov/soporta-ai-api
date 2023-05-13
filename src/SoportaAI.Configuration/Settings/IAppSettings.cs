namespace SoportaAI.Configuration.Settings;

public interface IAppSettings
{
	T Get<T>(string key);
}