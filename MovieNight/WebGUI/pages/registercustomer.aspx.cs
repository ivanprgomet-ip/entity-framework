using EFlib;
using EFlib.BLL;
using System;

namespace WebGUI.pages
{
    public partial class registercustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string customername = txt_customername.Text;
            string customeraddress = txt_customeradress.Text;
            string customerphone = txt_customerphone.Text;

            bool registratrionSucceeded = BLLCustomer.RegisterNewCustomer(new Customer(customername, customeraddress, customerphone));

            if (registratrionSucceeded)
                lbl_customerregistrationMSG.Text = $"Customer {customername} Registered";
            else
                lbl_customerregistrationMSG.Text = $"Customer Registration Failed";
        }
    }
}