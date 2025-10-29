using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facturador.Models.Clases
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [Required]
        public string CuitCuil { get; private set; }
        [Required]
        public string RazonSocial { get; private set; }
        public string Domicilio { get; private set; }
        public List<Factura> Facturas { get; private set; }

        // Constructor para EF Core
        private Cliente() { }

        
        public Cliente(string cuitCuil, string razonSocial, string domicilio)
        {
            CuitCuil = cuitCuil;
            RazonSocial = razonSocial;
            Domicilio = domicilio;
            Facturas = new List<Factura>();
        }

        
        public void ActualizarDatos(string nuevoCuit, string nuevaRazonSocial, string nuevoDomicilio)
        {
            CuitCuil = nuevoCuit;
            RazonSocial = nuevaRazonSocial;
            Domicilio = nuevoDomicilio;
        }
    }
}
