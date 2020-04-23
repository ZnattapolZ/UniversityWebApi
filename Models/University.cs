using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityWebApi.Models
{
    public class University
    { 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UniversityId { get; set; }
        public string Name { get; set; }
    }
}
