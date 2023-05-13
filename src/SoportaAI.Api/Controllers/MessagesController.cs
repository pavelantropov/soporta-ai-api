using Microsoft.AspNetCore.Mvc;
using SoportaAI.Api.Model.Models;

namespace SoportaAI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
	[HttpGet]
	public async Task<ActionResult> GetMessages()
	{
		return Ok();
	}

	[HttpPost]
	public async Task<ActionResult> PostMessage([FromBody]MessageModel message)
	{
		if (message == null)
			return BadRequest("Message is null."); //!!!

		return Ok();
	}
}
