using System.ComponentModel.DataAnnotations;

namespace UniversityWebApi.Models
{
    public class Enroll
    {
        [Key]
        public int EnrollId { get; set; }
        public int StudentId { get; set; }
        public int UniversityId { get; set; }
        public string Degree { get; set; }
    }
}
