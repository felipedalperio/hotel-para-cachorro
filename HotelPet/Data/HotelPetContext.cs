using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace HotelPet.Models
{
    public class HotelPetContext : DbContext
    {
        public HotelPetContext (DbContextOptions<HotelPetContext> options)
            : base(options)
        {
        }

        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        public DbSet<HotelInfo> HotelInfo { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
    }
}
