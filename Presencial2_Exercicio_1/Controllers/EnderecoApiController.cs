using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presencial2_Exercicio_1.DAL;
using Presencial2_Exercicio_1.Models;

namespace Presencial2_Exercicio_1.Controllers
{

    //André Regazzo - 1908239
    [Route("api/Endereco")]
    [ApiController]
    public class EnderecoApiController : ControllerBase
    {
        private readonly EnderecoDAO _dao;
        public EnderecoApiController(EnderecoDAO enderecoDAO)
        {
            _dao = enderecoDAO;
        }

        //GET:  URL: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult ListarEnderecos()
        {
            return Ok(_dao.Listar());
        }
        
        //GET: URL: /api/Endereco/ListarEndereco/81730000
        [HttpGet]
        [Route("ListarEndereco/{cep}")]
        public IActionResult ListarEndereco(String cep)
        {
            Endereco e = _dao.ListarEndereco(cep);
            return Ok(_dao.ListarEndereco(cep));
        }

        //POST: URL: /api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Endereco endereco)
        {
            String mensagem = "";
            
            _dao.Cadastrar(endereco, out mensagem);
            return Created("", endereco);
        }
        
        //PUT: URL: /api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult AlterarEndereco(Endereco endereco)
        {
            
            if (endereco == null)  return BadRequest();

            if(!_dao.Editar(endereco))
                return NotFound(endereco);
            
            return Ok(endereco);
        }

        //[DELETE] URL: /api/Endereco/DeletarEndereco/2
        [HttpDelete]
        [Route("DeletarEndereco/{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            Endereco endereco = _dao.ListarEndereco(id);
            if (endereco == null)
            {
                return NotFound();
            }

            if (!_dao.Delete(endereco))
                return null;

            return Ok(endereco);
        }




    }

    



}
