using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPet.Models.ViewModels
{
    public class HotelFormViewModel
    {
        //VAI TER QUE TER UMA LISTA DE DEPARTAMENTOS
        public HotelInfo Hotel { get; set; } = new HotelInfo();
        public Endereco Endereco { get; set; } = new Endereco();
    }
}
