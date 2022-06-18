using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Domain.Entities
{
    public class SchoolRecords : Entity
    {
        public SchoolRecords() { }

        public SchoolRecords(string name, string typefile)
        {
            Name = name;
            TypeFile = typefile;
        }

        public string Name { get; set; }

        public string TypeFile { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }

    }
}
