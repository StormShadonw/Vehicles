using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.API.Data.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }
        [Display(Name ="Tipo de Vehiculo")]
        [MaxLength(50, ErrorMessage ="El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public String Description { get; set; }
    }
}
