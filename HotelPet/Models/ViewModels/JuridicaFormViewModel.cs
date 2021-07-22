using Hotel.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPet.Models.ViewModels
{
    public class JuridicaFormViewModel
    {
        //VAI TER QUE TER UM VENDEDOR:
        public PessoaJuridica PessoaJuridica { get; set; }
        //VAI TER QUE TER UMA LISTA DE DEPARTAMENTOS
        public HotelInfo Hotel { get; set; }
        public Endereco Endereco { get; set; }
       
    }
}
