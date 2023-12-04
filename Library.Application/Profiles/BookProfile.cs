using AutoMapper;
using Library.Application.Dto;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
                CreateMap<BookDTO, Book>(); 
        }
    }
}
