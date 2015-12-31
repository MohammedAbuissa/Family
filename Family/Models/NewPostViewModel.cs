using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Family.Models
{
    public class NewPostViewModel
    {
        [Column(TypeName = "text")]
        [StringLength(144)]
        public string Caption { get; set; }

        public bool? Private_Public { get; set; }

        public HttpPostedFileBase Picture { get; set; }
    }
}
