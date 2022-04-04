﻿namespace MovieAPI.Services.DALModels
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Actors { get; set; }
        public string Directors { get; set; }
    }
}
