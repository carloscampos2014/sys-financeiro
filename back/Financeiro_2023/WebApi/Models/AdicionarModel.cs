using Entities.Enums;

namespace WebApi.Models
{
    public class AdicionarModel
    {
        public int IdSistema { get; set; }

        public int IdCategoria { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string EmailUsuario { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public EnumTipoDespesa TipoDespesa { get; set; }
    }
}
