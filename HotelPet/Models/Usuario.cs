using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, string nome, string email, string tel)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Tel = tel;
        }

        /*public virtual string Cadastrar()
        {
            return "";
        }*/
    }

}

