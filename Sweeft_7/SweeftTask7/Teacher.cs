using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Teacher
    {
        [Key]
        public int Teacher_ID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Subject { get; set; }

        public List<TeacherPupil> TeacherPupils { get; set; }
    }
}
