﻿using OpenAI_API;
using OpenAI_API.Chat;
using SoportaAI.Domain.Entities;
using AiModel = OpenAI_API.Models.Model;

namespace SoportaAI.Infrastructure.Services;

public class OpenAiService : IAiService
{
	private readonly IOpenAIAPI _api;
	private readonly IMessageService _messageService;

	private readonly Conversation _chat;

    public OpenAiService(IOpenAIAPI api, IMessageService messageService)
	{
		_api = api;
		_messageService = messageService;

		_chat = _api.Chat.CreateConversation();
	}

	public async Task<Message> GenerateResponseAsync(string input, AiModel model, CancellationToken cancellationToken = default)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return default; // !!!
		}

		_chat.Model = model;

		_chat.AppendUserInput(input);

		var response = await _chat.GetResponseFromChatbotAsync();

		var message = await _messageService.GenerateMessageAsync(response, null, cancellationToken);

		return message;
	}
}