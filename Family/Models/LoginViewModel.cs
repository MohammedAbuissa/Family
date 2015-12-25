using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string E_Mail { get; set; }

        [Required]
        [StringLength(64)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
