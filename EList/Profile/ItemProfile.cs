using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EList.Dto;
using EList.Models;

namespace EList.Profile
{
    public class ItemProfile: AutoMapper.Profile
    {
        public ItemProfile()
        {
            //Source -> Target
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemCreateDto, Item>();
            CreateMap<ItemUpdateDto, Item>();
            CreateMap<Item, ItemUpdateDto>();
        }
    }
}
