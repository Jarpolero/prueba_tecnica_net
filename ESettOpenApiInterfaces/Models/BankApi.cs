using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESettOpenApiInterfaces.Models
{
    public class BankApi
    {
        public string? Bic { get; set; }   
        public string? Country { get; set; }
        public string? Name { get; set; }
    }

}