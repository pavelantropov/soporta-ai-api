using OpenAI_API;
using SoportaAI.Domain.Factories;
using SoportaAI.Infrastructure.Services;

namespace SoportaAI.Tests.Infrastructure;

public class OpenAiApiServiceTests
{
	private OpenAiService _aiService;

	[SetUp]
	public void Setup()
	{
		// TODO use moq
		_aiService = new OpenAiService(new OpenAIAPI(), new MessageService(new MessageFactory()));
	}

	[TestCase("Hello! Are you a chat bot?")]
	public async Task GenerateResponseTestAsync(string input)
	{
		var response = await _aiService.GenerateResponseAsync(input);

		Assert.That(response, Is.Not.Null);
		Assert.That(response, Is.Not.Empty);
	}
}