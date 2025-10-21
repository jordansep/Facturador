using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturador.Models.Clases
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public float Cantidad { get; set; }
        [Required]
        public float PrecioUnitario { get; set; }
        public Factura Factura { get; set; }
        public int FacturaId { get; set; }



    }
}
