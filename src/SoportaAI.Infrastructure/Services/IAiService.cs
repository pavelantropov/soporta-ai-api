using OpenAI_API.Models;
using SoportaAI.Domain.Entities;

namespace SoportaAI.Infrastructure.Services;

public interface IAiService
{
	// TODO
	Task<Message> GenerateResponseAsync(string input, Model model, CancellationToken cancellationToken = default);
}