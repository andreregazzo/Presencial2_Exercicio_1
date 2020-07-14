﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
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

    }
}