using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Models
{
	public class DetailViewModel
	{

		public int Id { get; set; }

		[Display(Name = "Precio Mano de Obra")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal LaborPrice { get; set; }

		[Display(Name = "Precio Repuestos")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal SparePartsPrice { get; set; }

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

		public int HistoryId { get; set; }

		[Display(Name = "Procedimiento")]
		[Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un procedimiento.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public int ProcedureId { get; set; }

		public IEnumerable<SelectListItem> Procedures { get; set; }
	}
}
