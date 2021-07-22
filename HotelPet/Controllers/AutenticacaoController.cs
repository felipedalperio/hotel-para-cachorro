using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hotel.Models;
using HotelPet.Models;
using HotelPet.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelPet.Controllers
{
    public class AutenticacaoController : Controller
    {

        private readonly HotelPetContext _context;


        public AutenticacaoController(HotelPetContext context)
        {
            _context = context;


        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AuthenticateSignIn(string username, string password)
        {
            var result = _context.Usuario.Where(x => x.Login == username).FirstOrDefault();
            var PessoaFisicaObj = _context.PessoaFisica.Where(x => x.Id == result.Id).FirstOrDefault();
            var PessoaJuridicaObj = _context.PessoaJuridica.Where(x => x.Id == result.Id).FirstOrDefault();

            //VERIFICANDO SE É UMA PESSOA FISICA OU JURIDICA
            if (PessoaFisicaObj != null)
            {
                 PessoaFisica p = (PessoaFisica) result;

                if (p != null && p.Senha == password)
                {
                    HttpContext.Session.SetString("username", p.Login);
                    HttpContext.Session.SetString("Cpf", p.Cpf );

                    return Redirect("https://localhost:44351/");

                }
                else
                {
                    TempData["Message"] = "Login está incorreto.";
                    return RedirectToAction("Login");
                }
            }
             else
            {
                PessoaJuridica p = (PessoaJuridica)result;

                if (p != null && p.Senha == password)
                {
                    HttpContext.Session.SetString("username", p.Login);
                    HttpContext.Session.SetString("Cnpj", p.Cnpj);

                    return Redirect("https://localhost:44351/");

                }
                else
                {
                    TempData["Message"] = "Login está incorreto.";
                    return RedirectToAction("Login");
                }
            }
            
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return Redirect("https://localhost:44351/");
        }
    }

}