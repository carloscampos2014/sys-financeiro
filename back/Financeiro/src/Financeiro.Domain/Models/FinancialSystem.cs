namespace Financeiro.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("SistemaFinanceiro")]
    public class FinancialSystem : Base
    {
        public DateTime Date { get; set; }

        public int CloseDay { get; set; }

        public bool CopyAnother { get; set; }

        public DateTime DateCopy { get; set; }
    }
}
