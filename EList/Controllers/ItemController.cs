using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EList.Data;
using EList.Models;
using AutoMapper;
using EList.Dto;

namespace EList.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        //private readonly EListContext _context;

        //public ItemController(EListContext context)
        //{
        //    _context = context;
        //}
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public ItemController(IItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/item
        [HttpGet]
        public ActionResult<IEnumerable<ItemReadDto>> GetAllItems()
        {
            var items = _repository.GetItems();

            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(items));
        }
        //GET api/item/{id}
        [HttpGet("{id}", Name = "GetItemById")]
        public ActionResult<ItemReadDto> GetItemById(int id)
        {
            var item = _repository.GetItemById(id);
            if (item != null)
            {
                return Ok(_mapper.Map<ItemReadDto>(item));
            }
            return NotFound();
        }
        //POST api/item
        [HttpPost]
        public ActionResult<ItemReadDto> CreateItem(ItemCreateDto itemCreateDto)
        {
            var itemModel = _mapper.Map<Item>(itemCreateDto);
            _repository.CreatItem(itemModel);

            var itemReadDto = _mapper.Map<ItemReadDto>(itemModel);

            return CreatedAtRoute(nameof(GetItemById), new { Id = itemReadDto.ItemId }, itemReadDto);
        }
        //PUT api/item/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, ItemUpdateDto itemUpdateDto)
        {
            var itemModelFromRepo = _repository.GetItemById(id);
            if (itemModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(itemUpdateDto, itemModelFromRepo);

            _repository.UpdateItem(itemModelFromRepo);

            return NoContent();
        }
        //DELETE api/item/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var itemModelFromRepo = _repository.GetItemById(id);
            if (itemModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletItem(itemModelFromRepo);

            return NoContent();
        }
    }
}
