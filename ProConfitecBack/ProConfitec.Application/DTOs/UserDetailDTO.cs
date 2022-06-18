using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Application.DTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int ScholarityId { get; set; }
        public int SchoolRecordsId { get; set; }
        public string ScholarytyDescription { get; set; }
        public string SchoolRecordsName { get; set; }
        public string SchoolRecordsType { get; set; }
        public string fileSource { get; set; }

    }
}
