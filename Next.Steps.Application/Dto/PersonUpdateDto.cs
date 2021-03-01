using System;
using System.Collections.Generic;

namespace Next.Steps.Application.Dto
{
    public class PersonUpdateDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Profession { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Email { get; set; }

        public List<HobbyUpdateDto> Hobbies { get; set; }
    }
}