using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facturador.Models.Clases
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; private set; }
        [Required]
        public string CuitCuil { get; private set; }
        [Required]
        public string RazonSocial { get; private set; }
        public string Domicilio { get; private set; }
        public List<Factura> Facturas { get; private set; }

        public Cliente(string CuitCuil, string RazonSocial, string Domicilio)
        {
            this.CuitCuil = CuitCuil;
            this.RazonSocial = RazonSocial;
            this.Domicilio = Domicilio;
            Facturas = new List<Factura>();
        }
        public void BuscarCliente()
        {

        }
        public void RegistrarCliente()
        {

        }
        public void BorrarCliente() 
        { 

        }
        public void MostrarListaDeClientes() 
        {

        }
        public void ModificarCliente()
        {

        }
    }
}
