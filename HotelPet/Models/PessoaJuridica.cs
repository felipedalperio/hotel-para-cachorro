using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
   public class PessoaJuridica : Usuario
    {
        
        public string Cnpj { get; set; }
        public ICollection<HotelInfo> Hotel { get; set; } = new List<HotelInfo>();

        public PessoaJuridica()
        {
        }

        public PessoaJuridica(int id, string nome, string email, string tel, string cnpj) : base( id, nome, email, tel)
        { 
            Cnpj = cnpj;         
        }

       /* public override string Cadastrar()
        {
            return base.Cadastrar();
        } */
    }
}
