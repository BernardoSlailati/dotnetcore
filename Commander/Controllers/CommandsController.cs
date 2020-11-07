using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {  
            _repository = repository;
            _mapper = mapper;
        }

        // POST => api/commands
        [HttpPost]
        public ActionResult<CommandGetDto> CreateCommand(CommandCreateDto commandCreateDto) 
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandGetDto = _mapper.Map<CommandGetDto>(commandModel);

            // Correctly way to generate a 201 CREATED response, by checking GET_BY_ID route using target Id
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandGetDto.Id}, commandGetDto);
        } 
        
        // GET => api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandGetDto>> GetAllCommands() 
        {
            var allCommands = _repository.GetAllCommands();
            
            return Ok(_mapper.Map<IEnumerable<CommandGetDto>>(allCommands));
        }

        // GET => api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandGetDto> GetCommandById(int id) 
        {
            var commandById = _repository.GetCommandById(id);
            if (commandById != null) {
                return Ok(_mapper.Map<CommandGetDto>(commandById));
            }

            return NotFound();
        }

        // UPDATE => api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto) 
        {
            var commandGetById = _repository.GetCommandById(id);
            if (commandGetById == null) {
                return NotFound();
            }

            // Updates target command get by id properties using new structure passed in 
            // "commandUpdateDto" by user
            _mapper.Map(commandUpdateDto, commandGetById);

            _repository.UpdateCommand(commandGetById);
            _repository.SaveChanges();

            // Good response practice in update requests
            return NoContent();
        }

        // PATCH => api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandById = _repository.GetCommandById(id);
            if (commandById == null) {
                return NotFound();
            }

            // --------------------- new PATCH code --------------------------
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandById);

            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch)) {
                return ValidationProblem(ModelState);
            }
            // ---------------------------------------------------------------

            _mapper.Map(commandToPatch, commandById);

            _repository.UpdateCommand(commandById);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE => api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id) 
        {
            var commandById = _repository.GetCommandById(id);
            if (commandById == null) {
                return NotFound();
            }

            _repository.DeleteCommand(commandById);
            _repository.SaveChanges();

            return NoContent();
        }

         // DELETE ALL => api/commands/
        [HttpDelete]
        public ActionResult DeleteAllCommands() 
        {
            var allCommands = _repository.GetAllCommands();
            if (!allCommands.Any()) {
                return NotFound();
            }

            _repository.DeleteAllCommands();
            _repository.SaveChanges();

            return NoContent();
        }
     }
}