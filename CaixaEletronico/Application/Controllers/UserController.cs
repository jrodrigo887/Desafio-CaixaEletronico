using CaixaEletronico.Application.Models;
using CaixaEletronico.Domain;
using CaixaEletronico.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaixaEletronico.Services.Validators;
using CaixaEletronico.Services.Service;

namespace CaixaEletronico.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _baseService;

        public UserController(UserService baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            if (id == 0)
                return NotFound("Identificador do usuário Inválido");
            return Execute(() => _baseService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound("Não possui dados do usuário para cadastro.");
            return Execute(() => _baseService.Add<UserValidator>(user).Id );
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return NotFound("Não possui dados do usuário para atualização.");
            return Execute(() => _baseService.Update<UserValidator>(user));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound("Identificador do usuário Inválido");
            Execute(() => 
            {
                _baseService.Delete(id);
                return true;
            });

            return new NoContentResult();

        }  

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
