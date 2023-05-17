using OpenAI_API;
using OpenAI_API.Models;
using SoportaAI.Domain.Factories;
using SoportaAI.Infrastructure.Services;

namespace SoportaAI.Tests.Infrastructure;

public class OpenAiApiServiceTests
{
	private OpenAiService _openAiService;

	[SetUp]
	public void Setup()
	{
		// TODO use moq
		_openAiService = new OpenAiService(new OpenAIAPI(), new MessageService(new MessageFactory()));
	}

	[TestCase("Hello! Are you a chat bot?")]
	public async Task GenerateResponseChatGptTestAsync(string input)
	{
		var response = await _openAiService.GenerateResponseAsync(input, Model.ChatGPTTurbo);

		Assert.That(response, Is.Not.Null);
		Assert.That(response, Is.Not.Empty);
	}
}