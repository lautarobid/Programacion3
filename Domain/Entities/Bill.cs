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
        public int IdBill { get; set; }    // Identificador de la factura
        public float Mount { get; set; }      // Monto de la factura
        public string PayState { get; set; }  // Estado de pago de la factura
    }
}
