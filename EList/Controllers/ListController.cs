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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace EList.Controllers
{
    [Authorize]
    [Route("api/list")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListReposiroty _repository;
        private readonly IMapper _mapper;

        public ListController(IListReposiroty repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/List
        [HttpGet]
        public ActionResult<IEnumerable<List>> GetLists()
        {
            var listItems = _repository.GetLists();

            return Ok(_mapper.Map<IEnumerable<ListReadDto>>(listItems));
        }

        // GET: api/List/5
        [HttpGet("{id}", Name = "GetListById")]
        public ActionResult<ListReadDto> GetListById(int id)
        {
            var list = _repository.GetListById(id);
            if (list != null)
            {
                return Ok(_mapper.Map<ListReadDto>(list));
            }
            return NotFound();

        }
        // GET: api/List/math
        [HttpPost("{name}", Name = "GetListByName")]
        public ActionResult<ListReadDto> GetListByName(string name)
        {
            var list = _repository.GetListByName(name);
            if (list != null)
            {
                return Ok(_mapper.Map<ListReadDto>(list));
            }
            return NotFound();

        }

        // PUT: api/List/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutList(int id, List list)
        {
            if (id != list.ListId)
            {
                return BadRequest();
            }

            var listModelFromRepo = _repository.GetListById(id);
 
            if (listModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(list, listModelFromRepo);

            _repository.UpdateList(listModelFromRepo);
            return NoContent();

        }

        // POST: api/List
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<List> PostList(ListCreateDto listCreateDto)
        {

            var listModel = _mapper.Map<List>(listCreateDto);
            _repository.CreateList(listModel);
          
            var listReadDto = _mapper.Map<ListReadDto>(listModel);

            return CreatedAtRoute(nameof(GetListById), new { id = listReadDto.ListId }, listReadDto);
        }

        // DELETE: api/List/5
        [HttpDelete("{id}")]
 
        public ActionResult<List> DeleteList(int id)
        {

            var listModelFromRepo = _repository.GetListById(id);
            if (listModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteList(listModelFromRepo);

            return NoContent();
        }

        private bool ListExists(int id)
        {
            return _repository.Lists.Any(e => e.ListId == id);
        }

        
    }
}
