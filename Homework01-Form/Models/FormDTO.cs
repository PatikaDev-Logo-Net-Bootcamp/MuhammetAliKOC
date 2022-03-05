using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework01_Form.Models
{
    public class FormDTO
    {
        [Display(Name= "Ad")]
        [Required(ErrorMessage ="Ad alanı zorunludur.")]

        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        public string SurName { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Mail alanı zorunludur.")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Mail adresi geçerli formatta olmalıdır.")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        //("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,8}$"
        //Bir üst satırdaki expression türkçe karakterleri dikate almadığı için aşağıdaki yazıldı.
        [RegularExpression("^(?=.*[fgğıodrnhpqwuieaütkmlyşjövcçzsb])(?=.*[FGĞIODRNHPQWŞYLMKTÜAEİUJÖVCÇZSB])(?=.*\\d)[fgğıodrnhpqwuieaütkmlyşjövcçzsbFGĞIODRNHPQWŞYLMKTÜAEİUJÖVCÇZSB\\d]{8,8}$",
        ErrorMessage = "Şifreniz 1 Büyük harf, 1 Küçük harf, 1 Numara içeren 8 karakterden oluşmalıdır.")]
        public string Password { get; set; }



        



    }
}
