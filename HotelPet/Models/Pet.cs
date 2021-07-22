using Hotel.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public Animal Tipo { get; set; }
        public Tamanho Tamanho { get; set; }
        public int PessoaFisicaId { get; set; }
        public PessoaFisica PessoaFisica { get; set; }  

        public Pet()
        {
        }

        public Pet(int id,string nome, string raca, Animal tipo, Tamanho tamanho, PessoaFisica pessoaFisica)
        {
            Id = id;
            Nome = nome;
            Raca = raca;
            Tipo = tipo;
            Tamanho = tamanho;
            PessoaFisica = pessoaFisica;
        }


    }

}

