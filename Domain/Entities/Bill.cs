using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBill { get; set; }    // Identificador de la factura (se generará automáticamente)
        public float Mount { get; set; }      // Monto de la factura
        public string PayState { get; set; }  // Estado de pago de la factura

        // Constructor actualizado, ahora solo recibe 'mount'
        public Bill(float mount)
        {
            Mount = mount;
            PayState = "Impago"; // Estado inicial
        }

        // Método para simular el pago
        public void Pay()
        {
            if (PayState == "Impago")
            {
                PayState = "Pagado";
                Console.WriteLine("El pago se ha realizado con éxito.");
            }
            else
            {
                Console.WriteLine("La factura ya está pagada.");
            }
        }
    }
}
