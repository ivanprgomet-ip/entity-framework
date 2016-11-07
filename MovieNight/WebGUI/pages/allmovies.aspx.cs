using System;
using System.Web.UI;
using System.Collections.Generic;
using EFlib;
using EFlib.BLL;
using System.Text;

namespace WebGUI.pages
{
    public partial class allmovies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //retrieve all movies and list them in the html innertext element
            List<Movie> movies = BLLMovie.ReturnAllMovies();

            StringBuilder sb = new StringBuilder();

            sb.Append("All Movies:");
            sb.Append("<br/><br/>");
            sb.Append("..............................");
            sb.Append("<br/><br/>");
            foreach (var movie in movies)
            {
                sb.Append(string.Format($"Title: {movie.MovieName} <br/>Director: {movie.MovieDirector} <br/>Genre: {movie.Genre.GenreName}"));
                sb.Append("<br/><br/>");
            }
            sb.Append("..............................");
            movieslisted.InnerHtml = sb.ToString();
        }
    }
}