using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoportaAI.Api.Model.Models;
using SoportaAI.Infrastructure.Services;

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

	[HttpGet]
	public async Task<ActionResult> GetResponse(string input)
	{
		var response = await _aiService.GenerateResponseAsync(input);

		return Ok(_mapper.Map<MessageModel>(response));
	}
}