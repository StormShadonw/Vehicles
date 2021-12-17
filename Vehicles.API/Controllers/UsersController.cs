using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data;
using Vehicles.API.Data.Entities;
using Vehicles.API.Helpers;
using Vehicles.API.Models;
using Vehicles.Common.Enums;

namespace Vehicles.API.Controllers
{
	[Authorize(Roles = "Admin")]
	public class UsersController : Controller
	{
		private readonly DataContext _context;
		private readonly IUserHelper _userHelper;
		private readonly ICombosHelper _combosHelper;
		private readonly IConverterHelper _converterHelper;
		private readonly IBlobHelper _blobHelper;

		public UsersController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper,
			IConverterHelper converterHelper, IBlobHelper blobHelper)
		{
			_context = context;
			_userHelper = userHelper;
			_combosHelper = combosHelper;
			_converterHelper = converterHelper;
			_blobHelper = blobHelper;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Users
				.Include(x => x.DocumentType)
				.Include(x => x.Vehicles)
				.Where(x => x.UserType == UserType.User)
				.ToListAsync());
		}

		public IActionResult Create()
		{
			UserViewModel model = new UserViewModel
			{
				DocumentTypes = _combosHelper.GetComboDocumentTypes(),
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(UserViewModel model)
		{
			model.DocumentType = await _context.DocumentTypes.FindAsync(model.DocumentTypeId);
			if (ModelState.IsValid)
			{
				Guid imageId = Guid.Empty;
				if (model.ImageFile != null)
				{
					imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
				}
				User user = await _converterHelper.ToUserAsync(model, imageId, true);
				user.UserType = UserType.User;
				user.CreateDate = DateTime.Now;
				user.CreatedBy = Environment.UserName;
				user.IsActive = true;
				await _userHelper.AddUserAsync(user, "123456");
				await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());

				return RedirectToAction("Index");
			}
			model.DocumentTypes = _combosHelper.GetComboDocumentTypes();
			return View(model);
		}

		public async Task<IActionResult> Edit(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			User user = await _userHelper.GetUserAsync(Guid.Parse(id));
			if (user == null)
			{
				return NotFound();
			}

			UserViewModel model = _converterHelper.ToUserViewModel(user);

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(UserViewModel model)
		{
			if (ModelState.IsValid)
			{
				Guid imageID = model.ImageId;
				if (model.ImageFile != null)
				{
					imageID = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
				}

				User user = await _converterHelper.ToUserAsync(model, imageID, false);

				user.UpdateDate = DateTime.Now;
				user.UpdatedBy = Environment.UserName;

				await _userHelper.UpdateUserAsync(user);
				return RedirectToAction(nameof(Index));

			}

			model.DocumentTypes = _combosHelper.GetComboDocumentTypes();
			return View(model);

		}

		public async Task<IActionResult> Delete(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			User user = await _userHelper.GetUserAsync(Guid.Parse(id));

			if (user == null)
			{
				return NotFound();
			}

			await _blobHelper.DeleteBlobAsync(user.ImageId, "users");
			await _userHelper.DeleteUserAsync(user);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Details(string id)
		{
			if(string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
			User user = await _context.Users
				.Include(x => x.DocumentType)
				.Include(x => x.Vehicles)
				.ThenInclude(x => x.Brand)
				.Include(x => x.Vehicles)
				.ThenInclude(x => x.VehicleType)
				.Include(x => x.Vehicles)
				.ThenInclude(x => x.VehiclePhotos)
				.Include(x => x.Vehicles)
				.ThenInclude(x => x.Histories)
				.FirstOrDefaultAsync(x => x.Id == id);
			if(user == null)
			{
				return NotFound();
			}
			return View(user);
		}

		public async Task<IActionResult> AddVehicle(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			User user = await _context.Users
				.Include(x => x.Vehicles)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (user == null)
			{
				return NotFound();
			}
			var model = new VehicleViewModel {
			Brands = _combosHelper.GetComboBrands(),
			UserId = user.Id,
			VehicleTypes = _combosHelper.GetComboVehicleTypes(),
			};

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddVehicle(VehicleViewModel vehicleViewModel)
		{
			//if(ModelState.IsValid)
			//{
				User user = await _context.Users
					.Include(x => x.Vehicles)
					.FirstOrDefaultAsync(x => x.Id == vehicleViewModel.UserId);
				if(user == null)
				{
					return NotFound();
				}

				Guid imageId = Guid.Empty;
				if(vehicleViewModel.ImageFile != null)
				{
					imageId = await _blobHelper.UploadBlobAsync(vehicleViewModel.ImageFile, "vehicles");
				}

				Vehicle vehicle = await _converterHelper.ToVehicleAsync(vehicleViewModel, true);

				if(vehicle.VehiclePhotos == null)
				{
					vehicle.VehiclePhotos = new List<VehiclePhoto>();
				}
				vehicle.VehiclePhotos.Add(new VehiclePhoto
				{
					ImageId = imageId,
				});

				try
				{
					vehicle.CreateDate = DateTime.Now;
					vehicle.CreatedBy = Environment.UserName;
					vehicle.IsActive = true;
					user.Vehicles.Add(vehicle);
					_context.Users.Update(user);
					await _context.SaveChangesAsync();
					return RedirectToAction("Details", new {Id = user.Id});
				}

				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
					{
						ModelState.AddModelError(string.Empty, "Ya existe un vehículo con esta placa.");
					}
					else
					{
						ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
					}
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			//}
			vehicleViewModel.Brands = _combosHelper.GetComboBrands();
			vehicleViewModel.VehicleTypes = _combosHelper.GetComboVehicleTypes();
			return View(vehicleViewModel);
		}

	}
}
