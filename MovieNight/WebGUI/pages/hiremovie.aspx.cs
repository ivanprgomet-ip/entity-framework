using EFlib;
using EFlib.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace WebGUI.pages
{
    public partial class hiremovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //return currently available movies into a dropdownlist
            List<Movie> availableMovies = BLLMovie.ReturnAvailableMovies();
            StringBuilder sb = new StringBuilder();


            sb.Append("<ul>");
            foreach (var m in availableMovies)
            {
                sb.Append(string.Format($"<li>{m.MovieId}<br/>Title: {m.MovieName} <br/>Director: {m.MovieDirector} <br/>Genre: {m.Genre.GenreName} </li>"));
                sb.Append("<br/><br/>");

                PopulateMovieDroplist(m);
            };

            PopulateCustomerDroplist();

            sb.Append("</ul>");
            sb.Append("<br/><br/>");
            availablemoviesID.InnerHtml = sb.ToString();
        }

        private void PopulateCustomerDroplist()
        {
            List<Customer> customers = BLLCustomer.ReturnAllCustomers();
            foreach (var c in customers)
            {
                ListItem currentCustomer = new ListItem(c.CustomerName, c.CustomerID.ToString());
                dropdown_customerids.Items.Add(currentCustomer);
            }
        }
        private void PopulateMovieDroplist(Movie m)
        {
            ListItem currentMovie = new ListItem(m.MovieName, m.MovieId.ToString(), true);
            dropdown_movieids.Items.Add(currentMovie);
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int movieToBeHiredID = int.Parse(dropdown_movieids.SelectedValue);
            Movie movieToBeHired = BLLMovie.ReturnMovieWithID(movieToBeHiredID);

            int customerThatsHiringID = int.Parse(dropdown_customerids.SelectedValue);
            Customer customerThatsHiring = BLLCustomer.ReturnCustomerWithID(customerThatsHiringID);

            BLLRentedMovie.HireMovie(customerThatsHiring, movieToBeHired);
            lbl_resultMSG.Text = customerThatsHiring.CustomerName + " hired " + movieToBeHired.MovieName;

        }
    }
}