using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;
using Vehicles.API.Helpers;
using Vehicles.Common.Enums;

namespace Vehicles.API.Data
{
	public class SeedDb
	{
		private readonly DataContext _context;
		private readonly IUserHelper _userHelper;

		public SeedDb(DataContext context, IUserHelper userHelper)
		{
			_context = context;
			_userHelper = userHelper;
		}

		public async Task SeddAsync()
		{
			await _context.Database.EnsureCreatedAsync();
			await CheckDocumentTypesAsync();
			await CheckVehiclesTypeAsync();
			await CheckBrandsAsync();
			await CheckProceduresAsync();
			await CheckRolesAsync();
			await CheckUserAsync("1010", "Jorge", "Lopez", "llopez@yopmail.com", "829 962 8522", "Calle luna Calle Sol",
				UserType.Admin);
			await CheckUserAsync("2020", "Angel", "Lopez", "alopez@yopmail.com", "829 962 4444", "Calle luna Calle Angel",
	UserType.User);
			await CheckUserAsync("3030", "Sandra", "Berrocal", "sberrocal@yopmail.com", "829 962 8522", "Calle luna Calle Sol Sandra Berrocal",
	UserType.Admin);
			//			await CheckUserAsync("3030", "Jose", "Lopez", "jlopez@yopmail.com", "829 962 5555", "Calle luna Calle Jose",
			//UserType.User);

		}

		private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber,
			string address, UserType userType)
		{
			User user = await _userHelper.GetUserAsync(email);
			if (user == null)
			{
				user = new User
				{
					Address = address,
					Document = document,
					DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cédula"),
					Email = email,
					FirstName = firstName,
					LastName = lastName,
					PhoneNumber = phoneNumber,
					UserType = userType,
					UserName = email,
				};
				await _userHelper.AddUserAsync(user, "123456");
				await _userHelper.AddUserToRoleAsync(user, userType.ToString());
			}
		}

		private async Task CheckRolesAsync()
		{
			await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
			await _userHelper.CheckRoleAsync(UserType.User.ToString());
		}

		private async Task CheckProceduresAsync()
		{
			if (!_context.Procedures.Any())
			{
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineación", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención delantera", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Lubricación de suspención trasera", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Frenos delanteros", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Frenos traseros", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos delanteros", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Líquido frenos traseros", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Calibración de válvulas", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineacion carburador", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Aceite motor", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Aceite caja", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Filtro de aire", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Sistema eléctrico", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Guayas", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta delantera", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta trasera", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Reparación de motor", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Kit arrastre", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Banda transmisión", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio batería", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Lavado sistema de inyección", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Lavado de tanque", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio de bujia", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento delantero", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio rodamiento trasero", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Procedures.Add(new Procedure { Price = 10000, Description = "Accesorios", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				await _context.SaveChangesAsync();
			}
		}

		private async Task CheckDocumentTypesAsync()
		{
			if (!_context.DocumentTypes.Any())
			{
				_context.DocumentTypes.Add(new DocumentType { Description = "Cédula", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.DocumentTypes.Add(new DocumentType { Description = "Tarjeta de Identidad", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.DocumentTypes.Add(new DocumentType { Description = "NIT", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				await _context.SaveChangesAsync();
			}
		}

		private async Task CheckBrandsAsync()
		{
			if (!_context.Brands.Any())
			{

				_context.Brands.Add(new Brand { Description = "Ducati", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Harley Davidson", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "KTM", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "BMW", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Triump", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Victoria", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Honda", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Suzuki", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Kawasaky", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "TVS", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Bajaj", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "AKT", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Yamaha", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Chevrolet", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Mazda", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.Brands.Add(new Brand { Description = "Renault", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				await _context.SaveChangesAsync();
			}
		}

		private async Task CheckVehiclesTypeAsync()
		{
			if (!_context.VehicleTypes.Any())
			{
				_context.VehicleTypes.Add(new VehicleType { Description = "Carro", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				_context.VehicleTypes.Add(new VehicleType { Description = "Moto", CreateDate = DateTime.Now, CreatedBy = "system", IsActive = true });
				await _context.SaveChangesAsync();
			}
		}
	}
}
