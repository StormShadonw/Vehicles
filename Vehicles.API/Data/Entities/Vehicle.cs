using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Vehicles.API.Data.Entities
{
	public class Vehicle
	{
		public int Id { get; set; }

		[Display(Name = "Tipo de Vehículo")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public VehicleType VehicleType { get; set; }

		[Display(Name = "Marca")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public Brand Brand { get; set; }


		[Display(Name = "Año")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[Range(1900, 3000, ErrorMessage = "Valor de módelo no válido.")]
		public int Year { get; set; }

		[Display(Name = "Placa")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage ="Formato de placa incorrecto.")]
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

		[Display(Name = "Propietario")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		public User User { get; set; }

		[Display(Name = "Observación")]
		[DataType(DataType.MultilineText)]
		public string Remarks { get; set; }

		public ICollection<VehiclePhoto> VehiclePhotos { get; set; }

		[Display(Name = "# Fotos")]
		public int VehiclePhotosCount => VehiclePhotos == null ? 0 : VehiclePhotos.Count;

		//TODO: Fix the images path
		[Display(Name = "Foto")]
		public string ImageFullPath => VehiclePhotos == null || VehiclePhotos.Count == 0
			? $"https://localhost:44342//images/noimage.png"
			: VehiclePhotos.FirstOrDefault().ImageFullPath;

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

		public ICollection<History> Histories { get; set; }

		[Display(Name = "# Historias")]
		public int HistoriesCount => Histories == null ? 0 : Histories.Count;
	}
}
