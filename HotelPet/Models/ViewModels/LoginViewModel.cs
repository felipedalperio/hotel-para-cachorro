using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPet.Models.ViewModels
{
    public class LoginViewModel
    {
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe o Login!")]
        [MaxLength(50, ErrorMessage = "O Login deve ter no máximo 50 caracteres!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha!")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A Senhe deve ter pelo menos 6 caracteres!")]
        public string Senha { get; set; }
    }
}