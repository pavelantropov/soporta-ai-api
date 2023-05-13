using AutoMapper;
using SoportaAI.Domain.Entities;
using SoportaAI.Model.Models;

namespace SoportaAI.Infrastructure.Mappings;

public class MessageMapProfile : Profile
{
	public MessageMapProfile()
	{
		RegisterMappings();
	}

	private void RegisterMappings()
	{
		CreateMap<Message, MessageModel>()
			.ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToShortTimeString()));
	}
}