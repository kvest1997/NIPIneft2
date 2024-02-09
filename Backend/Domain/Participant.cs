using System;

namespace Domain
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string NameParticipant { get; set; }
        public Guid GenderId { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Sity { get; set; }
    }
}
