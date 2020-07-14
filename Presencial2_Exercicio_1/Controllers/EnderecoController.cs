using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presencial2_Exercicio_1.Models;
using Newtonsoft.Json;
using System.Net;
using Presencial2_Exercicio_1.DAL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Presencial2_Exercicio_1.Controllers
{
    //André Regazzo - 1908239
    public class EnderecoController : Controller
    {

        private readonly EnderecoDAO _dao;

        public EnderecoController(EnderecoDAO enderecoDAO)
        {
            _dao = enderecoDAO;
        }
       
        public IActionResult Index()
        {
            if (TempData["Endereco"] != null)
            {
                String retorno = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(retorno);

                if ( !String.IsNullOrWhiteSpace(endereco.Uf))
                {
                    String mensagem = "";
                    _dao.Cadastrar(endereco, out mensagem);
                }
                return View(_dao.Listar());

            }
            return View(_dao.Listar());
        }

        [HttpPost]
        public IActionResult PesquisarEndereco(string textBoxCEP)
        {
            if (string.IsNullOrWhiteSpace(textBoxCEP) || textBoxCEP.Length != 8)
            {
                return RedirectToAction("Index");
            }
            string url = $"http://viacep.com.br/ws/{textBoxCEP}/json/";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TempData["Endereco"] = json;
            }

            return RedirectToAction("Index");
        }
    }
}
