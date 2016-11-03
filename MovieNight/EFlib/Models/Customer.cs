using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFlib
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerPhone { get; set; }

        public Customer()
        {

        }
        public Customer(string name, string adress, string phone)
        {
            this.CustomerName = name;
            this.CustomerAdress = adress;
            this.CustomerPhone = phone;
        }
    }
}
