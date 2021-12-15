using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Models
{
	public class UserViewModel : User
	{
		[Display(Name = "Foto")]
		public IFormFile ImageFile { get; set; }

		[Display(Name = "Tipo de documento")]
		[Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de documento.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public int DocumentTypeId { get; set; }

		public IEnumerable<SelectListItem> DocumentTypes { get; set; }
	}
}
