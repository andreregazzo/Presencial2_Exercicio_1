using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Presencial2_Exercicio_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presencial2_Exercicio_1.DAL
{
    public class EnderecoDAO
    {
        private readonly Context _context;

        public EnderecoDAO(Context context)
        {
            _context = context;
        }

        public List<Endereco> Listar()
        {
            return _context.enderecos.ToList();
        }
        public Endereco ListarEndereco(String cep)
        {
            //Formata o CEP Antes da Consulta
            if (cep.Length == 8)
                cep = cep.Insert(5, "-");
            return _context.enderecos.FirstOrDefault(x => x.Cep == cep);
        }
        public Endereco ListarEndereco(int id)
        {
            //Formata o CEP Antes da Consulta
            return _context.enderecos.FirstOrDefault(x => x.EnderecoId == id);
        }

        public bool Cadastrar(Endereco endereco, out String Mensagem)
        {
            Mensagem = "";
            try
            {
                _context.enderecos.Add(endereco);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Endereco endereco)
        {

            if (endereco == null) return false;

            Endereco e = this.ListarEndereco(endereco.EnderecoId);
            if (e == null)
                return false;
            try
            {
                e.Logradouro = endereco.Logradouro;
                e.Complemento = endereco.Complemento;
                e.Bairro = endereco.Bairro;
                e.Cep = endereco.Cep;
                e.Localidade = endereco.Localidade;
                e.Uf = endereco.Uf;
                _context.SaveChanges();
            }
            catch (Exception err)
            {
                return false;
            }
            return true;
        }


        public bool Delete(Endereco endereco)
        {

            _context.enderecos.Remove(endereco);
            _context.SaveChanges();

            return true;
        }

    }
}
