using EFlib;
using EFlib.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebGUI.pages
{
    public partial class allcustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            List<Customer> customers = BLLCustomer.ReturnAllCustomers();

            StringBuilder sb = new StringBuilder();

            sb.Append("All Registered Customers:");
            sb.Append("<br/><br/>");
            sb.Append("..............................");
            sb.Append("<br/><br/>");
            foreach (var customer in customers)
            {
                sb.Append(string.Format($"CustomerID: {customer.CustomerID} <br/>CustomerName: {customer.CustomerName} <br/>CustomerAddress: {customer.CustomerAdress} <br/>CustomerPhone: {customer.CustomerPhone}"));
                sb.Append("<br/><br/>");
            }
            sb.Append("..............................");
            customerslisted.InnerHtml = sb.ToString();
        }
    }
}