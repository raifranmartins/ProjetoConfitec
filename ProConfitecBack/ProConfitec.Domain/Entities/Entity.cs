using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Domain.Entities
{
    public abstract class Entity
    {
        public Entity() { }       
        public int Id { get; protected set; }
    }
}
