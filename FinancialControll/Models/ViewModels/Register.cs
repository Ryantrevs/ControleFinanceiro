using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControll.Models
{
    public class Register
    {
        
        [StringLength(15, MinimumLength = 4)]
        [Required(ErrorMessage = "É obrigatorio o preenchimento deste campo")]
        [Display(Name = "Username")]
        public string UserName { get; set; }


        [StringLength(30, MinimumLength = 4)]
        [Required(ErrorMessage = "É obrigatorio o preenchimento deste campo")]
        [Display(Name = "Nome")]
        public string Name { get; set; }



        [Required(ErrorMessage = "É obrigatorio o preenchimento deste campo")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Inválido")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$",
         ErrorMessage = "A senha deve ter caracter(s):minusculo, maiusculo, especial, numeral, Deve Possuir entre 8 a 16 digitos")]
        [Required(ErrorMessage = "É obrigatorio o preenchimento deste campo")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "É obrigatorio o preenchimento deste campo")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "É obrigatorio o preenchimento deste campo")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public float Sallary { get; set; }
    }
}
