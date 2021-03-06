﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1_3_
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            //Enrollments = new HashSet<Enrollment>();
        }
        public Student(string lastname, string firstmidname, DateTime enrollmentdate)
        {
            this.LastName = lastname;
            this.FirstMidName = firstmidname;
            this.EnrollmentDate = enrollmentdate;
        }
    }
}
