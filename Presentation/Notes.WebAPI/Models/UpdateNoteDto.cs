using System;
using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebAPI.Models;

public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
            .ForMember(noteCmd => noteCmd.Id,
                opt => opt.MapFrom(noteDto => noteDto.Id))
            .ForMember(noteCmd => noteCmd.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
            .ForMember(noteCmd => noteCmd.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details));
    }
}