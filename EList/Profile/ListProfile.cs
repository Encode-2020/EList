using EList.Dto;
using EList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EList.Profile
{
    public class ListProfile: AutoMapper.Profile
    {
        public ListProfile()
        {
            //Source -> Target
            CreateMap<List, ListReadDto>();
            CreateMap<ListCreateDto, List>();
            CreateMap<ListUpdateDto, List>();
            CreateMap<List, ListUpdateDto>();
        }
    }
}
