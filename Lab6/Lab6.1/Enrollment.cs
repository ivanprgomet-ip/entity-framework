using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1
{
    class Enrollment
    {
        public int EnrollmentID { get; set; }
        public string EnrollmentName { get; set; }
        public string Grade { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public Enrollment()
        {
            Course = new Course();
        }
    }
}
