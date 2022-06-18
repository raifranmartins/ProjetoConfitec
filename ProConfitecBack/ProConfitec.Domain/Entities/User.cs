using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Domain.Entities
{
    public class User : Entity
    {
        public User() { }

        public User(string name, string surname, string email, DateTime birthDate, int scholarityId, int schoolRecordsId)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
            ScholarityId = scholarityId;
            SchoolRecordsId = schoolRecordsId;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int ScholarityId { get; set; }
        public virtual Scholarity Scholarity { get; set; }
        public int SchoolRecordsId { get; set; }
        public virtual SchoolRecords SchoolRecords { get; set; }
    }
}
