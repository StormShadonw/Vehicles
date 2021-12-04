using System;
using System.ComponentModel.DataAnnotations;

namespace Vehicles.API.Data.Entities
{
	public class DocumentType
	{
        public int Id { get; set; }
        [Display(Name = "Tipo de Documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        [Display(Name = "Fecha de Creación")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Creado por")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        public string CreatedBy { get; set; }

        [Display(Name = "Fecha de Actualizacion")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "Actualizado por")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        public string UpdatedBy { get; set; }


        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Estado")]
        public bool IsActive { get; set; }
    }
}
