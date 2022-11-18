using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Data.DTOs;
using Week4.Domain.Entity;

namespace Week4.Service.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap(); 
        }
    }
}
