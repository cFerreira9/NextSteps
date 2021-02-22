using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Next.Steps.Application.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Person's FirstName is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Person's LastName is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Person's Profession is Required")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Person's Birthday is Required")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Person's Email is Required")]
        public string Email { get; set; }

        public virtual IEnumerable<HobbyDto> Hobbies { get; set; }
    }
}
