using SoportaAI.Domain.Entities;

namespace SoportaAI.Infrastructure.Services;

public interface IAiService
{
	Task<Message> GenerateResponseAsync(string input, CancellationToken cancellationToken = default);
}