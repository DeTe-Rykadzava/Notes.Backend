using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.WebAPI.Models;

public class CreateNoteDto : IMapWith<CreateNoteCommand>
{
    [Required] public string Title { get; set; } = null!;

    public string? Details { get; set; } = null;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
            .ForMember(noteCommand => noteCommand.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
            .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details))
            ;
    }
}