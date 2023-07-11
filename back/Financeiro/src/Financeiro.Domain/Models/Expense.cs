namespace Financeiro.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Financeiro.Domain.Emuns;

    [Table("Despesas")]
    public class Expense : Base
    {
        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        public ExpenseTypes Type { get; set; }

        public bool PaidOut { get; set; }

        public DateTime PayDate { get; set; }
        [ForeignKey("Categorias")]
        [Column(Order = 1)]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = new Category();
    }
}
