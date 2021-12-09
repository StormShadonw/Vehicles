using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vehicles.Common.Enums;

namespace Vehicles.API.Data.Entities
{
	public class User : IdentityUser
	{
		[Display(Name = "Nombres")]
		[MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string FirstName { get; set; }

		[Display(Name = "Apellidos")]
		[MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string LastName { get; set; }

		[Display(Name = "Tipo de documento")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public DocumentType DocumentType { get; set; }

		[Display(Name = "Documento")]
		[MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public string Document { get; set; }

		[Display(Name = "Dirección")]
		[MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
		public string Address { get; set; }

		[Display(Name = "Foto")]
		public Guid ImageId { get; set; }

		//TODO: Fix the images path
		[Display(Name = "Foto")]
		public string ImageFullPath => ImageId == Guid.Empty 
			? $"https://localhost:44342//images/noimage.png" 
			: $"https://vehicleszuluprep.blob.core.windows.net/users/{ImageId}";

		[Display(Name = "Tipo de usuario")]
		public UserType UserType { get; set; }

		[Display(Name = "Nombre completo")]
		public string FullName => $"{FirstName} {LastName}";

		public ICollection<Vehicle> Vehicles { get; set; }

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

		[Display(Name = "# Vehiculos")]
		public int VehiclesCount => Vehicles == null ? 0 : Vehicles.Count;
	}
}
