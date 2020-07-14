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
    

    [Route("api/Endereco")]
    [ApiController]
    public class EnderecoApiController : ControllerBase
    {
        private readonly EnderecoDAO _dao;
        public EnderecoApiController(EnderecoDAO enderecoDAO)
        {
            _dao = enderecoDAO;
        }

        // URL: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult ListarEnderecos()
        {
            return Ok(_dao.Listar());
        }
        
        //URL: /api/Endereco/ListarEndereco/81730000
        [HttpGet]
        [Route("ListarEndereco/{cep}")]
        public IActionResult ListarEndereco(String cep)
        {
            Endereco e = _dao.ListarEndereco(cep);
            return Ok(_dao.ListarEndereco(cep));
        }
    }

    



}
