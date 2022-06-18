using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Domain.Entities
{
    public class Scholarity : Entity
    {
        public Scholarity() { }

        public Scholarity(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

    }
}
