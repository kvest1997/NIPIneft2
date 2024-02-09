using Application.Participants.Commands.CreateParticipant;
using Application.Participants.Commands.DeleteParticipant;
using Application.Participants.Commands.UpdateParticipant;
using Application.Participants.Queries.GetParticipantList;
using Application.Participants.Quires.GetParticipantDetails;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ParticipantController : BaseController
    {
        private readonly IMapper _mapper;

        public ParticipantController(IMapper mapper) => _mapper = mapper;
        /// <summary>
        /// Получение списка Учасников
        /// </summary>
        /// <remarks>
        /// Запрос образца:
        /// Get /participant
        /// </remarks>
        /// <returns>Возращает ParticipantListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Пользователь не авторизован</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ParticipantListVm>> GetAll()
        {
            var query = new GetParticipantListQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ParticipantDetailsVm>> Get(Guid id)
        {
            var query = new GetParticipantDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePaticipantDto createParticipantDto)
        {
            var command = _mapper.Map<CreateParticipantCommand>(createParticipantDto);
            command.Id = Id;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateParticipantDto updateParticipantDto)
        {
            var command = _mapper.Map<UpdateParticipantCommand>(updateParticipantDto);
            command.Id = Id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteParticipantCommand
            {
                Id = id
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
