using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1
{
    class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        //Ändra så att den inte laddar in alla enrollments för varje student
        public Student()
        {
            //Enrollments = new List<Enrollment>();
        }
        public Student(string lastname, string firstmidname, DateTime enrollmentdate)
        {
            this.LastName = lastname;
            this.FirstMidName = firstmidname;
            this.EnrollmentDate = enrollmentdate;

            //TODO: not neccessary to initialize new icollection of enrollments here...?
            //Enrollments = new List<Enrollment>();

        }

    }
}
