using Application.Common.Mappings;
using Application.Participants.Commands.CreateParticipant;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CreatePaticipantDto 
        : IMapWith<CreateParticipantCommand>
    {
        [Required]
        public string NameParticipant { get; set; }
        public Guid GenderId { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Sity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePaticipantDto, CreateParticipantCommand>()
                .ForMember(noteCommand => noteCommand.Experience,
                opt => opt.MapFrom(noteDto => noteDto.Experience))
                .ForMember(noteCommand => noteCommand.GenderId,
                opt => opt.MapFrom(noteDto => noteDto.Experience))
                .ForMember(noteCommand => noteCommand.GenderId,
                opt => opt.MapFrom(noteDto => noteDto.GenderId))
                .ForMember(noteCommand => noteCommand.NameParticipant,
                opt => opt.MapFrom(noteDto => noteDto.NameParticipant))
                .ForMember(noteCommand => noteCommand.Sity,
                opt => opt.MapFrom(noteDto => noteDto.Sity))
                .ForMember(noteCommand => noteCommand.Age,
                opt => opt.MapFrom(noteDto => noteDto.Age));
        }
    }
}
