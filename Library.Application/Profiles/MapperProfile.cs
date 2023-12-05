using AutoMapper;
using Library.Application.Dto;
using Library.Domain;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
