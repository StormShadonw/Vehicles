using System;
using System.ComponentModel.DataAnnotations;

namespace Vehicles.API.Data.Entities
{
	public class VehiclePhoto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[Display(Name = "Vehiculo")]
		public Vehicle Vehicle { get; set; }

		[Display(Name = "Foto")]
		public Guid ImageId { get; set; }

		//TODO: Fix the correct path
		[Display(Name = "Foto")]
		public string ImageFullPath => ImageId == Guid.Empty
			? $"https://localhost:44342//images/noimage.png"
			: $"https://vehiclesjorge.blob.core.windows.net/vehicles/{ImageId}";
	}
}
