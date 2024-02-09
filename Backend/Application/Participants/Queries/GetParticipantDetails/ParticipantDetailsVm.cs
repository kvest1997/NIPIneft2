using Application.Common.Mappings;
using AutoMapper;
using Domain;
using System;

namespace Application.Participants.Quires.GetParticipantDetails
{
    public class ParticipantDetailsVm : IMapWith<Participant>
    {
        public Guid Id { get; set; }
        public string NameParticipant { get; set; }
        public Guid GenderId { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Sity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Participant, ParticipantDetailsVm>()
                .ForMember(noteVm => noteVm.NameParticipant,
                opt => opt.MapFrom(note => note.NameParticipant))
                .ForMember(noteVm => noteVm.Experience,
                opt => opt.MapFrom(note => note.Experience))
                .ForMember(noteVm => noteVm.Age,
                opt => opt.MapFrom(note => note.Age))
                .ForMember(noteVm => noteVm.Experience,
                opt => opt.MapFrom(note => note.Experience))
                .ForMember(noteVm => noteVm.Sity,
                opt => opt.MapFrom(note => note.Sity))
                .ForMember(noteVm => noteVm.GenderId,
                opt => opt.MapFrom(note => note.GenderId));
        }
    }
}