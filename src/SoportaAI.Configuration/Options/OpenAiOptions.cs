using static System.String;

namespace SoportaAI.Configuration.Options;

public class OpenAiOptions
{
	public const string OpenAi = "OpenAi";

	public string ApiKey { get; set; } = Empty;
	public string Organization { get; set; } = Empty;
}