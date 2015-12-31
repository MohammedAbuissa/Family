using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
namespace Family.Models
{
    public class CreateAccountViewModel
    {
        [Required]
        [StringLength(15)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string E_Mail { get; set; }

        [Required]
        [StringLength(68)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public HttpPostedFileBase Profile_Picture { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }


        [DataType(DataType.Text)]
        public string About_Me { get; set; }

        [StringLength(50)]
        public string HomeTown { get; set; }


        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string Phone_Number { get;  set; }

        [Required]
        public bool Gender { get; internal set; }

        [Required]
        [Range(0,2)]
        public byte Marital_Status { get; set; }
    }
}
