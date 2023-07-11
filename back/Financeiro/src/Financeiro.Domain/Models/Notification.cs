namespace Financeiro.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Notification
    {
        [NotMapped]
        public string PropertyName { get; set; } = string.Empty;

        [NotMapped]
        public string Message { get; set; } = string.Empty;

        [NotMapped]
        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public bool ValidatedStringProperty(string propertyName, string value)
        {
            if (string.IsNullOrWhiteSpace(propertyName) || string.IsNullOrWhiteSpace(value))
            {
                Notifications.Add(new Notification()
                {
                    PropertyName = propertyName,
                    Message = "Campo Obrigatório.",
                });

                return false;
            }

            return true;
        }

        public bool ValidatedIntProperty(string propertyName, int value)
        {
            if (string.IsNullOrWhiteSpace(propertyName) || value <= 0)
            {
                Notifications.Add(new Notification()
                {
                    PropertyName = propertyName,
                    Message = "Campo Obrigatório.",
                });

                return false;
            }

            return true;
        }
    }
}
