using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Models
{
	public class VehicleViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Tipo de vehículo")]
		[Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de vehiculo.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public int VehicleTypeId { get; set; }

		public IEnumerable<SelectListItem> VehicleTypes { get; set; }

		[Display(Name = "Marca")]
		[Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una marca.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public int BrandId { get; set; }

		public IEnumerable<SelectListItem> Brands { get; set; }


		[Display(Name = "Año")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[Range(1900, 3000, ErrorMessage = "El año debe de estar entre 1900 y 3000.")]
		public int Year { get; set; }

		[Display(Name = "Placa")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage = "Formato de placa incorrecto.")]
		[StringLength(6, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
		public string Plaque { get; set; }

		[Display(Name = "Modelo")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
		public string Model { get; set; }

		[Display(Name = "Color")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
		public string Color { get; set; }

		public string UserId { get; set; }

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


		//[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[Display(Name = "Estado")]
		public bool IsActive { get; set; }

		[Display(Name = "Foto")]
		public IFormFile ImageFile { get; set; }
	}
}
