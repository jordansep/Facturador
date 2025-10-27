
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facturador.Models.Clases
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public float ImporteTotal { get; set; }
          
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public List<Item> Items { get; set; }

        // Hacer Constructor
        public void RegistrarFactura() 
        { 
            Items = new List<Item>();
        }
        public void BuscarFactura() 
        { 
        
        }

    }
}
