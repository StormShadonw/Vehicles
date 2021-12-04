using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Data
{
	public class SeedDb
	{
		private readonly DataContext _context;

		public SeedDb(DataContext context)
		{
			_context = context;
		}

		public async Task SeddAsync()
		{
			await _context.Database.EnsureCreatedAsync();
			await CheckVehiclesTypeAsync();
			await CheckBrandsAsync();
			await CheckDocumentTypesAsync();
			await CheckProceduresAsync();
		}

		private async Task CheckProceduresAsync()
		{
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Alineación", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Lubricación de suspención delantera", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Lubricación de suspención trasera", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Frenos delanteros", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Frenos traseros", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Líquido frenos delanteros", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Líquido frenos traseros", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Calibración de válvulas", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Alineacion carburador", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Aceite motor", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Aceite caja", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Filtro de aire", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Sistema eléctrico", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Guayas", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Cambio llanta delantera", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Cambio llanta trasera", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Reparación de motor", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Kit arrastre", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Banda transmisión", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Cambio batería", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Lavado sistema de inyección", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Lavado de tanque", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Cambio de bujia", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Cambio rodamiento delantero", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Cambio rodamiento trasero", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Procedures.Add(new Procedure { Price= 10000, Description = "Accesorios", CreateDate = DateTime.Now, CreatedBy = "system" });
			await _context.SaveChangesAsync();
		}

		private async Task CheckDocumentTypesAsync()
		{
			if (!_context.DocumentTypes.Any())
			{
				_context.DocumentTypes.Add(new DocumentType { Description = "Cédula", CreateDate = DateTime.Now, CreatedBy = "system" });
				_context.DocumentTypes.Add(new DocumentType { Description = "Tarjeta de Identidad", CreateDate = DateTime.Now, CreatedBy = "system" });
				_context.DocumentTypes.Add(new DocumentType { Description = "NIT", CreateDate = DateTime.Now, CreatedBy = "system" });
				_context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte", CreateDate = DateTime.Now, CreatedBy = "system" });
				await _context.SaveChangesAsync();
			}
		}

		private async Task CheckBrandsAsync()
		{
			_context.Brands.Add(new Brand { Description = "Ducati", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Harley Davidson", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "KTM", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "BMW", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Triump", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Victoria", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Honda", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Suzuki", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Kawasaky", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "TVS", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Bajaj", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "AKT", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Yamaha", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Chevrolet", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Mazda", CreateDate = DateTime.Now, CreatedBy = "system" });
			_context.Brands.Add(new Brand { Description = "Renault", CreateDate = DateTime.Now, CreatedBy = "system" });
			await _context.SaveChangesAsync();
		}

		private async Task CheckVehiclesTypeAsync()
		{
			if (!_context.VehicleTypes.Any())
			{
				_context.VehicleTypes.Add(new VehicleType { Description = "Carro", CreateDate = DateTime.Now, CreatedBy = "system" });
				_context.VehicleTypes.Add(new VehicleType { Description = "Moto", CreateDate = DateTime.Now, CreatedBy = "system" });
				await _context.SaveChangesAsync();
			}
		}
	}
}
