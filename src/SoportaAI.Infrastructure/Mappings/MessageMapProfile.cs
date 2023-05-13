﻿using AutoMapper;
using SoportaAI.Api.Model.Models;
using SoportaAI.Domain.Entities;

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