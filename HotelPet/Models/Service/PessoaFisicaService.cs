using Hotel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPet.Models.Service
{
    public class PessoaFisicaService
    {

        private readonly HotelPetContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public PessoaFisicaService(HotelPetContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(PessoaFisica pessoaFisica, Pet pet)
        {

            if (!_context.PessoaFisica.Any(p => p.Cpf == pessoaFisica.Cpf))
            {
                pet.PessoaFisica = pessoaFisica;
                _context.AddRange(pessoaFisica, pet);
                await _context.SaveChangesAsync();
            }


        }

        public async Task InsertPetAsync(Pet pet, string cpf)
        {
            var pessoaFisica = _context.PessoaFisica.Where(x => x.Cpf == cpf).FirstOrDefault();
            pet.PessoaFisica = pessoaFisica;
            _context.AddRange(pet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PessoaFisica pessoaFisica)
        {
            _context.PessoaFisica.Update(pessoaFisica);
            await _context.SaveChangesAsync();
            
        }
        public async Task RemoveAsync(Pet pets)
        {
           
            _context.Remove(pets);
            await _context.SaveChangesAsync();
           

        }



    }
}
