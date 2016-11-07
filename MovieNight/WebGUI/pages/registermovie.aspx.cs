using EFlib;
using EFlib.BLL;
using System;

namespace WebGUI.pages
{
    public partial class registermovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string movieTitle = txt_movietitleID.Text;
            string movieDirector = txt_moviedirectorID.Text;
            string movieGenre = dropdown_moviegenre.SelectedValue;

            Genre currentGenre = new Genre() { GenreName = movieGenre };

            Movie newMovie = new Movie() { Genre = currentGenre, MovieDirector = movieDirector, MovieName = movieTitle };
            bool success = BLLMovie.RegisterNewMovie(newMovie);
            Console.WriteLine(success ? $"Movie {newMovie} Registered" : "Movie Registration Failed");


            lbl_movieregistrationMSG.Text = "movie successfully registered";
        }
    }
}