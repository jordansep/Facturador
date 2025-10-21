using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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



    }
}
