using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class HotelInfo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public int EnderecoId { get; private set; }
        public Endereco Endereco { get; set; }
        public int PessoaJuridicaId { get; private set; }

        public HotelInfo()
        {
            
        }

        public HotelInfo(int id, string nome, double preco, string descricao, string imagem, PessoaJuridica pessoaJuridica,Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Imagem = imagem;
            PessoaJuridica = pessoaJuridica;
            Endereco = endereco;
        }

       
    }
}

