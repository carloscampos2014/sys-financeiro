namespace Financeiro.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Categorias")]
    public class Category : Base
    {
        [ForeignKey("SistemaFinanceiro")]
        [Column(Order = 1)]
        public int SystemId { get; set; }

        public virtual FinancialSystem System { get; set; } = new FinancialSystem();
    }
}
