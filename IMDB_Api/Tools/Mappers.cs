﻿using ASP_Demo_Archi_DAL.Models;
using IMDB_Api.Models;

namespace IMDB_Api.Tools
{
    public static class Mappers
    {
        public static Movie ToDAL(this MovieCreateForm form)
        {
            return new Movie
            {
                Title = form.Title,
                Description = form.Description,
                RealisatorId = form.RealisatorId
            };
        }
        public static Person ToDAL(this PersonCreateForm form)
        {
            return new Person
            {
                Lastname = form.Lastname,
                Firstname = form.Firstname,
                PictureURL = form.PictureURL
            };
        }
    }
}
