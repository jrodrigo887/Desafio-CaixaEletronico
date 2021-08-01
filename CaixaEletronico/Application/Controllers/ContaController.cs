using CaixaEletronico.Application.Models;
using CaixaEletronico.Domain;
using CaixaEletronico.Services.Service;
using CaixaEletronico.Services.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        private ContaService _baseService;

        public ContaController(ContaService baseService)
        {
            _baseService = baseService;
        }

        [HttpPost("Transferir")]
        public IActionResult AccountTransiction([FromBody] AccountTransaction account)
        {
            if (account == null)
                return NotFound("Dados Inválidos.");

            _baseService.Transferir(account.ContaId_send, account.Send_money, account.ContaId_receiver);

            return Ok("Tranferência feita com sucesso!");
            
        }

        [HttpPost("Depositar/{id}")]
        public IActionResult AccountDeposit([FromBody] AccountDraweAndDeposit account, long id)
        {
            Console.WriteLine(id);
            var valueId = (long)id;

            if (account == null)
                return NotFound("Dados Inválidos.");
            _baseService.Depositar(valueId, account.money);

            return Ok("Deposito feito com sucesso!");
        }

        [HttpPost("Sacar/{id}")]
        public IActionResult AccountDrawe([FromBody] AccountDraweAndDeposit account, long id)
        {
            if (account == null)
                return NotFound("Dados Inválidos.");
          

            return Execute(() => _baseService.Sacar(id, account.money));
        }

        [HttpGet("Saldo/{id}")]
        public IActionResult AccountBalance(long id)
        {
            if (id == 0)
                return NotFound("Identificador Inválidos.");

            return Execute(() => _baseService.Saldo(id));
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
                return NotFound("Identificador Inválido");
            return Execute(() => _baseService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Conta conta)
        {
            if (conta == null)
                return NotFound("Não possui dados para cadastro.");
            return Execute(() => _baseService.Add<ContaValidator>(conta).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Conta conta)
        {
            if (conta == null)
                return NotFound("Não possui dados para atualização.");
            return Execute(() => _baseService.Update<ContaValidator>(conta));
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            if (id == 0)
                return NotFound("Identificador Inválido");
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
