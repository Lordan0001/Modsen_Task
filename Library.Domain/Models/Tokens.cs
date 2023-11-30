using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Tokens
    {
        public string Token { get; set; } = String.Empty; //Only this one will have realization
        public string RefreshToken { get; set; } = String.Empty;
    }
}
