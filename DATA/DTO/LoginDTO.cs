using System;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.DTO
{
    public class LoginDTO
    {
        public string? Username { get; set; }

        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1}", MinimumLength = 6)]
        public string? Password { get; set; }
    }
}
