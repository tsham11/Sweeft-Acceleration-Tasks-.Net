using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class TeacherPupil
    {
        public int Teacher_Id { get; set; }
        public int Pupil_Id { get; set; }

        public Teacher Teacher { get; set; }
        public Pupil Pupil { get; set; }
    }
}
