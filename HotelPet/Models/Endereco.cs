using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Endereco {
    public int Id { get; set; }
    public string Rua { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public int Numero { get; set; }
    public int Cep { get; set; }

        public Endereco()
        {
        }

        public Endereco(int id, string rua, string cidade, string estado, int numero, int cep)
    {
        Id = id;
        Rua = rua;
        Cidade = cidade;
        Estado = estado;
        Numero = numero;
        Cep = cep;
    }

    public void Validar()
    {

    }

    }
}
