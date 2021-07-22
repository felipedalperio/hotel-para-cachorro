using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelPet.Models.ViewModels;
using HotelPet.Models;
using HotelPet.Models.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HotelPet.Controllers
{
    public class HomeController : Controller
    {

        private readonly HotelPetContext _context;
        private readonly PessoaJuridicaService _pessoaJuridicaService;
        private IHostingEnvironment _hostingEnvironment;
        private readonly AuthenticatedUser _user;


        public HomeController(HotelPetContext context, PessoaJuridicaService pessoaJuridicaService, IHostingEnvironment hostingEnvironment, AuthenticatedUser user)
        {
            _context = context;
            _pessoaJuridicaService = pessoaJuridicaService;
            _hostingEnvironment = hostingEnvironment;
            _user = user;
        }


        public IActionResult Index()
        {
            // ViewBag.PessoaJuridica = HttpContext.Session.GetString("Nome");
            ViewBag.PessoaJuridica = _context.PessoaJuridica.ToList();
            ViewBag.Hotel = _context.HotelInfo.ToList();
            ViewBag.usuarioLogado = _user.Nome;
            ViewBag.usuarioLogadoCpf = _user.Cpf;
            ViewBag.usuarioLogadoCnpj = _user.Cnpj;

            if(_user.Cpf != null)
            {
                ViewBag.usuarioLogadoId = _context.PessoaFisica.Where(x => x.Cpf == _user.Cpf).Select(y => y.Id).FirstOrDefault();
            }else if(_user.Cnpj != null)
            {
                ViewBag.usuarioLogadoId = _context.PessoaJuridica.Where(x => x.Cnpj == _user.Cnpj).Select(y => y.Id).FirstOrDefault();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
