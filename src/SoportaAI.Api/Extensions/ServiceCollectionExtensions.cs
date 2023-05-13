using OpenAI_API;
using SoportaAI.Configuration.Options;
using SoportaAI.Domain.Factories;
using SoportaAI.Infrastructure.Mappings;
using SoportaAI.Infrastructure.Services;

namespace SoportaAI.Api.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager configuration)
	{
		var openAiOptions = new OpenAiOptions();
		configuration.GetSection(OpenAiOptions.OpenAi).Bind(openAiOptions);

		services.AddSingleton<IOpenAIAPI, OpenAIAPI>(_ =>
			new OpenAIAPI(new APIAuthentication(openAiOptions.ApiKey, openAiOptions.Organization)));
		services.AddSingleton<IAiService, OpenAiService>();

		services.AddSingleton<IMessageFactory, MessageFactory>();
		services.AddSingleton<IMessageService, MessageService>();

		return services;
	}

	public static IServiceCollection AddMappings(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(MessageMapProfile));
		services.AddAutoMapper(typeof(UserMapProfile));

		return services;
	}
}