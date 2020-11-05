using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {  
            _repository = repository;
        }
        
        // GET => api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands() 
        {
            var allCommands = _repository.GetAllCommands();
            return Ok(allCommands);
        }

        // GET => api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id) 
        {
            var commandById = _repository.GetCommandById(id);
            return Ok(commandById);
        }
    }
}