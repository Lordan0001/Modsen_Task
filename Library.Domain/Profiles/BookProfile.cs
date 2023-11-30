using AutoMapper;
using Library.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
                CreateMap<BookDTO, Book>(); 
        }
    }
}
