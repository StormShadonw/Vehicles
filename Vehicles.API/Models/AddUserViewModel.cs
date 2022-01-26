using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vehicles.API.Models
{
	public class AddUserViewModel : EditUserViewModel
	{
		[Display(Name = "Email")]
		[EmailAddress(ErrorMessage = "Debes de introducir un email válido.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Username { get; set; }

		[Display(Name = "Contraseña")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "El campo {0} no puede tener menos de {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Password { get; set; }

		[Display(Name = "Confirmación de contraseña")]
		[MinLength(6, ErrorMessage = "El campo {0} no puede tener menos de {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "La contraseña y confirmación de contraseña no son iguales.")]
		public string ConfirmPassword { get; set; }
	}
}
