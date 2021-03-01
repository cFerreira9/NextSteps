using System.Collections.Generic;

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

        public List<HobbyReadDto> Hobbies { get; set; }
    }
}