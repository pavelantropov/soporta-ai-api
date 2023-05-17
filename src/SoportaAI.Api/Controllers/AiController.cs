using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoportaAI.Api.Model.Models;
using SoportaAI.Infrastructure.Services;
using AiModel = OpenAI_API.Models.Model;

namespace SoportaAI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AiController : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly IAiService _aiService;

	public AiController(IMapper mapper,
						IAiService aiService)
	{
		_mapper = mapper;
		_aiService = aiService;
	}

	[HttpGet("chatGpt")]
	public async Task<ActionResult> GetChatGptResponse(string message)
	{
		var response = await _aiService.GenerateResponseAsync(message, AiModel.ChatGPTTurbo);

		//return Ok(_mapper.Map<MessageModel>(response));
		return Ok(response.Text);
	}

	[HttpGet("gpt4")]
	public async Task<ActionResult> GetGpt4Response(string message)
	{
		var response = await _aiService.GenerateResponseAsync(message, AiModel.GPT4);

		//return Ok(_mapper.Map<MessageModel>(response));
		return Ok(response.Text);
	}
}