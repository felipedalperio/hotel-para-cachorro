using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
   public class PessoaFisica : Usuario
    {
        //public int Id { get; set; }
        public string Cpf { get; set; }
        // public Simulacao Simulacao { get; set; 
        public ICollection<Pet> Pet { get; set; } = new List<Pet>();

        public PessoaFisica()
        {
        }

        public PessoaFisica(int id, string nome, string email, string tel, string cpf) : base(id, nome, email, tel)
        {
            Cpf = Cpf;
           
        }

        public void AddPet(Pet pet)
        {
            Pet.Add(pet);
        }


       /* public override string Cadastrar()
        {
            return base.Cadastrar();
        } */
    }

}
