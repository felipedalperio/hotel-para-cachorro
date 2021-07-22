using Hotel.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPet.Models.Service
{
    public class PessoaJuridicaService
    {
        private readonly HotelPetContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public PessoaJuridicaService(HotelPetContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task InsertAsync(PessoaJuridica pessoajuridica, HotelInfo hotel,Endereco endereco)
        {
            hotel.PessoaJuridica = pessoajuridica;
            hotel.Endereco = endereco;

            _context.AddRange(pessoajuridica, hotel,endereco);
            await _context.SaveChangesAsync();
        }

        public async Task InsertHotelAsync( HotelInfo hotel, Endereco endereco,String Cnpj)
        {
            var pessoaJuridica = _context.PessoaJuridica.Where(x => x.Cnpj == Cnpj).FirstOrDefault();
            hotel.PessoaJuridica = pessoaJuridica;
            hotel.Endereco = endereco;

            _context.AddRange(hotel, endereco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PessoaJuridica pessoajuridica)
        {
            _context.Update(pessoajuridica);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(HotelInfo hotelInfo, Endereco endereco)
        {
            _context.RemoveRange(hotelInfo, endereco);
            await _context.SaveChangesAsync();
        }

    }
}
