using Application.Common.Mappings;
using Application.Participants.Commands.UpdateParticipant;
using AutoMapper;
using System;

namespace WebAPI.Models
{
    public class UpdateParticipantDto 
        : IMapWith<UpdateParticipantCommand>
    {
        public Guid Id { get; set; }
        public string NameParticipant { get; set; }
        public Guid GenderId { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Sity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateParticipantDto, UpdateParticipantCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.NameParticipant,
                opt => opt.MapFrom(noteDto => noteDto.NameParticipant))
                .ForMember(noteCommand => noteCommand.GenderId,
                opt => opt.MapFrom(noteDto => noteDto.GenderId))
                .ForMember(noteCommand => noteCommand.Age,
                opt => opt.MapFrom(noteDto => noteDto.Age))
                .ForMember(noteCommand => noteCommand.Experience,
                opt => opt.MapFrom(noteDto => noteDto.Experience))
                .ForMember(noteCommand => noteCommand.Sity,
                opt => opt.MapFrom(noteDto => noteDto.Sity));
        }
    }
}
