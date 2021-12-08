using System;
using System.ComponentModel.DataAnnotations;

namespace Vehicles.API.Data.Entities
{
	public class Detail
	{
		public int Id { get; set; }

		[Display(Name = "Historia")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public History History { get; set; }

		[Display(Name = "Procedimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public Procedure Procedure { get; set; }

		[Display(Name = "Precio Mano de Obra")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal LaborPrice { get; set; }

		[Display(Name = "Precio Repuestos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal SparePartsPrice { get; set; }

		[Display(Name = "Total")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal TotalPrice => LaborPrice + SparePartsPrice;

		[Display(Name = "Observación")]
		[DataType(DataType.MultilineText)]
		public string Remarks { get; set; }

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
	}
}
