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
            switch (dropdown_movielists.SelectedValue)
            {
                case "all":
                    ListAllMovies();
                    break;
                case "available":
                    ListAllAvailableMovies();
                    break;
                case "unavailable":
                    ListAllUnavailableMovies();
                    break;
                default:
                    break;
            }
        }
        private void ListAllMovies()
        {
            //retrieve all movies and list them in the html innertext element
            List<Movie> movies = BLLMovie.ReturnAllMovies();

            StringBuilder sb = new StringBuilder();

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
        private void ListAllAvailableMovies()
        {
            List<Movie> movies = BLLMovie.ReturnAvailableMovies();

            StringBuilder sb = new StringBuilder();

            sb.Append("Available Movies:");
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
        public void ListAllUnavailableMovies()
        {
            //retrieve all movies and list them in the html innertext element
            List<RentedMovie> movies = BLLRentedMovie.ReturnAllRentedMovies();

            StringBuilder sb = new StringBuilder();

            sb.Append("Unavailable Movies:");
            sb.Append("<br/><br/>");
            sb.Append("..............................");
            sb.Append("<br/><br/>");
            foreach (var movie in movies)
            {
                sb.Append(string.Format($"Title: {movie.Movie.MovieName} <br/>Director: {movie.Movie.MovieDirector} <br/>Genre: {movie.Movie.Genre.GenreName}"));
                sb.Append("<br/><br/>");
            }
            sb.Append("..............................");
            movieslisted.InnerHtml = sb.ToString();
        }
    }
}