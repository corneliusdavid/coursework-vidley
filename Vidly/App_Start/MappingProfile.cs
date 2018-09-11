using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;
using Vidly.Models.DTOs;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<MovieDTO, Movie>();
            Mapper.CreateMap<Movie, MovieDTO>();
        }
    }
}