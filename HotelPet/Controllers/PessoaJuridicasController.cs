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
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;

namespace HotelPet.Controllers
{
    public class PessoaJuridicasController : Controller
    {
        private readonly HotelPetContext _context;
        private readonly PessoaJuridicaService _pessoaJuridicaService;
        private IHostingEnvironment _hostingEnvironment;
        private AuthenticatedUser _user;

        public PessoaJuridicasController(HotelPetContext context, PessoaJuridicaService pessoaJuridicaService, IHostingEnvironment hostingEnvironment, AuthenticatedUser user)
        {
            _context = context;
            _pessoaJuridicaService = pessoaJuridicaService;
            _hostingEnvironment = hostingEnvironment;
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            // ViewBag.PessoaJuridica = HttpContext.Session.GetString("Nome");
            ViewBag.PessoaJuridica = _context.PessoaJuridica.ToList();
            ViewBag.Hotel = _context.HotelInfo.ToList();
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCnpj = _user.Cnpj;

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

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCnpj = _user.Cnpj;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //[Bind("Cpf,Id,Nome,Email,Tel")]
        public async Task<IActionResult> Create(PessoaJuridica pessoaJuridica, HotelInfo hotel, Endereco endereco, IFormFile file)
        {
            //string newPath = "/images";
            string newPath = Path.Combine(_hostingEnvironment.WebRootPath, "upload");
            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string fullPath = Path.Combine(newPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            hotel.Imagem = "/upload/" + fileName;
            // _context.HotelInfo.Add(new HotelInfo { Imagem = "/upload/" + fileName });
            //  _context.SaveChanges();
            if (ModelState.IsValid)
            {
                // _context.Add(pessoaFisica);
                //await _context.SaveChangesAsync();
                // pessoaJuridica.Hotel.Add(hotel);
                //string newPath = "/images";
                await _pessoaJuridicaService.InsertAsync(pessoaJuridica, hotel, endereco);


                return Redirect("https://localhost:44351/");
            }
            return View(pessoaJuridica);
        }


        //ADICIONANDO HOTEL:
        [HttpGet]
        public IActionResult CreateHotel()
        {
            //USUARIO:
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCnpj = _user.Cnpj;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //[Bind("Cpf,Id,Nome,Email,Tel")]
        public async Task<IActionResult> CreateHotel( HotelInfo hotel, Endereco endereco, IFormFile file)
        {
            //string newPath = "/images";
            string newPath = Path.Combine(_hostingEnvironment.WebRootPath, "upload");
            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string fullPath = Path.Combine(newPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            hotel.Imagem = "/upload/" + fileName;
            // _context.HotelInfo.Add(new HotelInfo { Imagem = "/upload/" + fileName });
            //  _context.SaveChanges();
            if (ModelState.IsValid)
            {
                // _context.Add(pessoaFisica);
                //await _context.SaveChangesAsync();
                // pessoaJuridica.Hotel.Add(hotel);
                //string newPath = "/images";
                String cnpj = _user.Cnpj;
                await _pessoaJuridicaService.InsertHotelAsync( hotel, endereco,cnpj);

                return Redirect("https://localhost:44351/");
            }
            return View(hotel);
        }

        // GET: PessoaFisicas/Edit/5
        // GET: PessoaFisicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //USUARIO:
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCnpj = _user.Cnpj;

            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoaJuridica.FindAsync(id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }
            return View(pessoaJuridica);
        

    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cnpj,Id,Nome,Email,Tel,Login,Senha")] PessoaJuridica pessoaJuridica)
        {
            if (id != pessoaJuridica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _pessoaJuridicaService.UpdateAsync(pessoaJuridica);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaJuridicaExists(pessoaJuridica.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaJuridica);
        }

        private bool PessoaJuridicaExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Visualizar(int? id)
        {
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCpf = _user.Cpf;

            var hotel = await _context.HotelInfo.FindAsync(id);
            var dono = _context.HotelInfo.Where(x => x.Id == id).Select(y => y.PessoaJuridica).FirstOrDefault();
            var endereco = _context.HotelInfo.Where(x => x.Id == id).Select(y => y.Endereco).FirstOrDefault();
            hotel.Endereco = endereco;
            hotel.PessoaJuridica = dono;
            
            ViewBag.Hotel = hotel;


            return View();
        }

        public async Task<IActionResult> Simulacao(int QntsDias, Simulacao simulacao, int id, HotelInfo hotel, ICollection<Pet> pets)
        {

            //USUARIO:
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCpf = _user.Cpf;

            var pessoaFisica = _context.PessoaFisica.Where(x => x.Cpf == _user.Cpf).FirstOrDefault();
            pets = _context.Pet.Where(x => x.PessoaFisicaId == pessoaFisica.Id).ToList();
            hotel = _context.HotelInfo.Where(h => h.Id == id).FirstOrDefault();

            //INSTANCIANDO:
            simulacao = new Simulacao
            {
                Hotel = hotel,
                Pets = pets,
                QntsDias = QntsDias

            };
            ViewBag.PessoaFisica = pessoaFisica;
            ViewBag.Pets = pets;
            ViewBag.Hotel = hotel;
            ViewBag.Simulacao = simulacao;
            ViewBag.ValorTotal = simulacao.Calcular();
            return View();
        }


//=-=-=-=-=-=-=-=-=-=--=-==--=-DELETE=-=-=-=-=-=-=-=-=-=--=-==--=-

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelInfo = await _context.HotelInfo
                .FirstOrDefaultAsync(m => m.Id == id);

            var endereco = await _context.Endereco.FirstOrDefaultAsync(x => x.Id == hotelInfo.EnderecoId);

            if (hotelInfo == null)
            {
                return NotFound();
            }

            return View(hotelInfo);
        }

        // POST: PessoaFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelInfo = await _context.HotelInfo.FindAsync(id);
            var endereco = await _context.Endereco.FirstOrDefaultAsync(x => x.Id == hotelInfo.EnderecoId);
            await _pessoaJuridicaService.RemoveAsync(hotelInfo, endereco);
            return RedirectToAction(nameof(Index));
        }

      
    }
}

       
