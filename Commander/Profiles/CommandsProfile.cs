using AutoMapper;
using Commander.Models;
using Commander.Dtos;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source (database) -> Target (user)
            // GET
            CreateMap<Command, CommandGetDto>();
            // POST            
            CreateMap<CommandCreateDto, Command>();
            // PUT
            CreateMap<CommandUpdateDto, Command>();
            // PATCH
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}