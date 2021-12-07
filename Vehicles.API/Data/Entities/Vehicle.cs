using System.ComponentModel.DataAnnotations;

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


		[Display(Name = "Modelo")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[Range(1900, 3000, ErrorMessage = "Valor de módelo no válido.")]
		public int Model { get; set; }

		[Display(Name = "Placa")]
		[Required(ErrorMessage = "El campo {0} es obligatorio.")]
		[RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage ="Formato de placa incorrecto.")]
		public string Plaque { get; set; }
	}
}
