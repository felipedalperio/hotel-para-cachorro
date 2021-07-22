using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using HotelPet.Models;
using HotelPet.Models.Service;
using Microsoft.AspNetCore.Hosting;

namespace HotelPet.Controllers
{
    public class PessoaFisicasController : Controller
    {
        private readonly HotelPetContext _context;
        private readonly PessoaFisicaService _pessoaFisicaService;
        private IHostingEnvironment _hostingEnvironment;
        private AuthenticatedUser _user;

        public PessoaFisicasController(HotelPetContext context, PessoaFisicaService pessoaFisicaService, IHostingEnvironment hostingEnvironment, AuthenticatedUser user)
        {
            _context = context;
            _pessoaFisicaService = pessoaFisicaService;
            _hostingEnvironment = hostingEnvironment;
            _user = user;


        }

        public async Task<IActionResult> Index()
        {

            //USUARIO:           
            ViewBag.PessoaFisica = _context.PessoaFisica.ToList();
            ViewBag.Pet = _context.Pet.ToList();
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCpf = _user.Cpf;

            if (_user.Cpf != null)
            {
                ViewBag.usuarioLogadoId = _context.PessoaFisica.Where(x => x.Cpf == _user.Cpf).Select(y => y.Id).FirstOrDefault();
            }
            else if (_user.Cnpj != null)
            {
                ViewBag.usuarioLogadoId = _context.PessoaJuridica.Where(x => x.Cnpj == _user.Cnpj).Select(y => y.Id).FirstOrDefault();
            }

            return View();
        }
     
        // GET: PessoaFisicas/Create
        public IActionResult Create()
        {
          
            return View();
        }

      
        [HttpPost]
        //falsificação de dados para o servidor
        [ValidateAntiForgeryToken] //[Bind("Cpf,Id,Nome,Email,Tel")]
        public async Task<IActionResult> Create( PessoaFisica pessoaFisica,Pet pet)
        {
            if (ModelState.IsValid)
            {
               // _context.Add(pessoaFisica);
                //await _context.SaveChangesAsync();
               await _pessoaFisicaService.InsertAsync(pessoaFisica,pet);

                return Redirect("https://localhost:44351/");
            }
            return View(pessoaFisica);
        }

        //ADICIONAR APENAS O PET:
        // GET: PessoaFisicas/Create
        public IActionResult CreatePet()
        {
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCpf = _user.Cpf;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //[Bind("Cpf,Id,Nome,Email,Tel")]
        public async Task<IActionResult> CreatePet(Pet pet)
        {
            if (ModelState.IsValid)
            {
                string cpf = _user.Cpf;
                await _pessoaFisicaService.InsertPetAsync(pet, cpf);

                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }


        // GET: PessoaFisicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            //Usuario:
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCpf = _user.Cpf;

            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoaFisica.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }
            return View(pessoaFisica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,Id,Nome,Email,Tel,Login,Senha")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     await _pessoaFisicaService.UpdateAsync(pessoaFisica);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaFisicaExists(pessoaFisica.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("https://localhost:44351/");
            }
            return View(pessoaFisica);
        }

        private bool PessoaFisicaExists(int id)
        {
            return _context.PessoaFisica.Any(e => e.Id == id);
        }

        //=-=-=-=-=-=-=-=-=-=--=-==--=-DELETE=-=-=-=-=-=-=-=-=-=--=-==--=-

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pets = await _context.Pet
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pets == null)
            {
                return NotFound();
            }

            return View(pets);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pets = await _context.Pet.FindAsync(id);
            await _pessoaFisicaService.RemoveAsync(pets);
            return RedirectToAction(nameof(Index));
        }

     
    }
}
