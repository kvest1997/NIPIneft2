using Application.Common.Mappings;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Participants.Queries.GetParticipantList
{
    public class ParticipantLookupDto : IMapWith<Participant>
    {
        public Guid Id { get; set; }
        public string NameParticipant { get; set; }
        public Guid GenderId { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Sity { get; set; }
        

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Participant, ParticipantLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.NameParticipant,
                opt => opt.MapFrom(note => note.NameParticipant))
                .ForMember(noteDto => noteDto.GenderId,
                opt => opt.MapFrom(note => note.GenderId))
                .ForMember(noteDto => noteDto.Age,
                opt => opt.MapFrom(note => note.Age))
                .ForMember(noteDto => noteDto.Experience,
                opt => opt.MapFrom(note => note.Experience))
                .ForMember(noteDto => noteDto.Sity,
                opt => opt.MapFrom(note => note.Sity));
        }
    }
}
