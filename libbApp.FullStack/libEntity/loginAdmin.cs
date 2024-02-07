using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libEntity
{
    public class loginAdmin
    {
        [Key]
        public int userId {  get; set; }
        [Required]
        public string usarName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
