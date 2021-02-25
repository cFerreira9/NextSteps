using Next.Steps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Next.Steps.Application.Dto
{
    public class PersonReadDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Profession { get; set; }

        public string Birthdate { get; set; }

        public string Email { get; set; }

        public List<HobbyDto> Hobbies { get; set; }
    }
}