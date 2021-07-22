using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPet.Models.Service
{
    public class SeedingService
    {

        private HotelPetContext _context;

        public SeedingService(HotelPetContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.PessoaFisica.Any() || _context.PessoaJuridica.Any() || _context.HotelInfo.Any() || _context.Pet.Any() || _context.Usuario.Any() || _context.Endereco.Any())
            {
                return;
            }

        }
    }
}
