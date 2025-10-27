
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
        // Hacer Constructor
        public static void AñadirItem()
        {

        }

    }
}
