using Hotel.Models;
using Hotel.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPet.Models.ViewModels
{
    public class FisicaFormViewModel
    {
        //VAI TER QUE TER UM VENDEDOR:
        public PessoaFisica PessoaFisica { get; set; }
        //VAI TER QUE TER UMA LISTA DE DEPARTAMENTOS
        public Pet Pet { get; set; }


    }
}
