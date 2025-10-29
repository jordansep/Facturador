using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Constructor vacío (buena práctica para EF)
        public Item() { }

        // Constructor para crear un item
        public Item(string descripcion, float cantidad, float precioUnitario)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
