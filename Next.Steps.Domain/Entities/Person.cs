using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Steps.Domain.Entities
{
    public class Person : IIdentity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Profession { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public IEnumerable<Hobby> Hobies { get; set; }


    }
}
