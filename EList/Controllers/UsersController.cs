﻿using System;
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
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IListRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllCommmands()
        {
            var users = _repository.GetUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        //GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            return NotFound();
        }

        //POST api/users
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(userModel);

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.UserID }, userReadDto);
        }
        //PUT api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, UserUpdateDto userUpdateDto)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModelFromRepo);

            _repository.UpdateUser(userModelFromRepo);

            return NoContent();
        }
        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(userModelFromRepo);
          

            return NoContent();
        }
    }
}