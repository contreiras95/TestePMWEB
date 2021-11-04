using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notification
{
    //Classe responsável pelo o retorno de notificações.
    public class Notify
    {
        public Notify()
        {
            Notifications = new List<Notify>();
        }

        [NotMapped]
        public string NameProperty { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notify> Notifications;

        /// <summary>Valida uma propriedade do tipo String.</summary>
        /// <param name="value">Valor da propriedade.</param>
        /// <param name="nameProperty">Nome da propriedade.</param>
        public bool ValidadeProperty(string value, string nameProperty)
        {

            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notify
                {
                    Message = "Campo Obrigatório",
                    NameProperty = nameProperty
                });

                return false;
            }

            return true;
        }

        /// <summary>Valida uma propriedade do tipo Int.</summary>
        /// <param name="value">Valor da propriedade.</param>
        /// <param name="nameProperty">Nome da propriedade.</param>
        public bool ValidadeProperty(int? value, string nameProperty)
        {

            if (value == null || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notify
                {
                    Message = "Campo Obrigatório",
                    NameProperty = nameProperty
                });

                return false;
            }

            return true;
        }

        /// <summary>Valida uma propriedade do tipo Decimal.</summary>
        /// <param name="value">Valor da propriedade.</param>
        /// <param name="nameProperty">Nome da propriedade.</param>
        public bool ValidadeProperty(decimal? value, string nameProperty)
        {

            if (value == null || string.IsNullOrWhiteSpace(nameProperty))
            {
                Notifications.Add(new Notify
                {
                    Message = "Campo Obrigatório",
                    NameProperty = nameProperty
                });

                return false;
            }

            return true;
        }
    }
}
