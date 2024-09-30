using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESettRepositoriesInterfaces.Models
{
    public class BankDAO
    {
        [Key]
        public int Id { get; set; }
        public required string Bic { get; set; }
        public string? Country { get; set; }
        public string? Name { get; set; }
    }
}
