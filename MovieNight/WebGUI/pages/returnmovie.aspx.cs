using EFlib;
using EFlib.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace WebGUI.pages
{
    public partial class returnmovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<RentedMovie> rentals = BLLRentedMovie.GetRentedMovies();//todo: 
            StringBuilder sb = new StringBuilder();

            foreach (var r in rentals)
            {
                sb.Append(string.Format($"{r.RentedID}# {r.Movie.MovieName} hired by {r.Customer.CustomerName}"));
                sb.Append("<br/><br>");
                //POPULATE THE DROPBOX WITH THE RENTEDID's
                ListItem currentRentedMovie = new ListItem(r.RentedID+" "+ r.Movie.MovieName + " (" + r.Customer.CustomerName + ")", r.RentedID.ToString());
                dropdown_rentedmovieids.Items.Add(currentRentedMovie);
            }

            hiredmoviesID.InnerHtml = sb.ToString();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int rentIDToReturn = int.Parse(dropdown_rentedmovieids.SelectedValue);
            bool returnSuccessfull = BLLRentedMovie.RemoveRentedMovie(rentIDToReturn);
            lbl_resultMSG.Text =
                (returnSuccessfull ?
                "movie returned successfully" :
                "movie was not returned");
        }
    }
}