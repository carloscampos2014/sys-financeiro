using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notificacoes
{
    public class Notifica
    {
        [NotMapped]
        public string NomePropriedade { get; set; } = string.Empty;

        [NotMapped]
        public string Mensagem { get; set; } = string.Empty;

        [NotMapped]
        public List<Notifica> Notificacoes { get; set; } = new List<Notifica>();

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = "Campo obrigatório.",
                    NomePropriedade = nomePropriedade,
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor <= 0 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = "Campo obrigatório.",
                    NomePropriedade = nomePropriedade,
                });

                return false;
            }

            return true;
        }
    }
}
