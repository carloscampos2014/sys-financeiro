namespace Financeiro.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser 
    {
        [Column("USR_CPF")]
        public string CPF { get; set; } = string.Empty;
    }
}
