using AutoMapper;
using SoportaAI.Api.Model.Models;
using SoportaAI.Domain.Entities;

namespace SoportaAI.Infrastructure.Mappings;

public class UserMapProfile : Profile
{
	public UserMapProfile()
	{
		RegisterMappings();
	}

	private void RegisterMappings()
	{
		CreateMap<User, UserModel>();
		CreateMap<UserModel, User>();
	}
}