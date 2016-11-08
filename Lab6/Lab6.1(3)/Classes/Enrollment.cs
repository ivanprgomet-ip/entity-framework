using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1_3_
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public string EnrollmentName { get; set; }
        public string Grade { get; set; }
        public Course Course { get; set; }
        
        public Enrollment()
        {

        }
    }
}
