using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.WebAPI.Models;

namespace Notes.WebAPI.Controllers;

[Route("api/[controller]")]
public class NoteController : BaseController
{
    private readonly IMapper _mapper;

    public NoteController(IMapper mapper) => _mapper = mapper;
    
    [HttpGet(Name = "GetAllNotes")]
    public async Task<ActionResult<NoteListVm>> GetAll()
    {
        var query = new GetNoteListQuery() { UserId = UserId };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{id}", Name = "GetNoteById")]
    public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
    {
        var query = new GetNoteDetailsQuery()
        {
            UserId = UserId,
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost(Name = "CreateNote")]
    public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteDto createNoteDto)
    {
        var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
        command.UserId = UserId;
        var noteId = await Mediator.Send(command);
        return Ok(noteId);
    }

    [HttpPut(Name = "UpdateNote")]
    public async Task<IActionResult> UpdateNote([FromBody] UpdateNoteDto updateNoteDto)
    {
        var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }
    [HttpDelete("{id}", Name = "DeleteNote")]
    public async Task<IActionResult> UpdateNote(Guid id)
    {
        var command = new DeleteNoteCommand()
        {
            Id = id,
            UserId = UserId
        }; 
        await Mediator.Send(command);
        return NoContent();
    }
}