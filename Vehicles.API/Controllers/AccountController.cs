using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data;
using Vehicles.API.Data.Entities;
using Vehicles.API.Helpers;
using Vehicles.API.Models;
using Vehicles.Common.Enums;

namespace Vehicles.API.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserHelper _userHelper;
		private readonly DataContext _context;
		private readonly ICombosHelper _combosHelper;
		private readonly IBlobHelper _blobHelper;
		public AccountController(IUserHelper userHelper, DataContext context, ICombosHelper combosHelper, IBlobHelper blobHelper)
		{
			_userHelper = userHelper;
			_blobHelper = blobHelper;
			_combosHelper = combosHelper;
			_context = context;
		}

		public IActionResult Login()
		{
			if(User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}
			return View(new LoginViewModel());
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model) {
			if(ModelState.IsValid)
			{
				var result = await _userHelper.LoginAsync(model);
				if(result.Succeeded)
				{
					if(Request.Query.Keys.Contains("ReturnUrl"))
					{
						return Redirect(Request.Query["ReturnUrl"].First());
					}
					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError(string.Empty,"Email o contraseña incorrectos.");
			}
			return View(model);
		}

		public async Task<IActionResult> Logout()
		{
			await _userHelper.LogoutAsync();
			return RedirectToAction("Index", "Home");
		}

		public IActionResult NotAuthorized()
		{
			return View();
		}

		public IActionResult Register()
		{
			AddUserViewModel model = new AddUserViewModel
			{
				DocumentTypes = _combosHelper.GetComboDocumentTypes(),
			};

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(AddUserViewModel model)
		{
			if (ModelState.IsValid) {
				Guid imageId = Guid.Empty;
				if(model.ImageFile != null)
				{
					imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
				}
				User user = await _userHelper.AddUserAsync(model, imageId, UserType.User);
				if(user == null)
				{
					ModelState.AddModelError(string.Empty, "Este correo ya esta siendo usado por otro usuario.");
					model.DocumentTypes = _combosHelper.GetComboDocumentTypes();
					return View(model);
				}
				LoginViewModel loginViewModel = new LoginViewModel
				{
					Password = model.Password,
					RememberMe = false,
					Username = model.Username,
				};
				var result2 = await _userHelper.LoginAsync(loginViewModel);
				if (result2.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
			}
			model.DocumentTypes = _combosHelper.GetComboDocumentTypes();
			return View(model);
		}

		public async Task<IActionResult> ChangeUser()
		{
			User user = await _userHelper.GetUserAsync(User.Identity.Name);
			if(user == null)
			{
				return NotFound();
			}
			EditUserViewModel model = new EditUserViewModel
			{
				Address = user.Address,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				ImageId = user.ImageId,
				Id = user.Id,
				Document = user.Document,
				DocumentTypeId = user.DocumentType.Id,
				DocumentTypes = _combosHelper.GetComboDocumentTypes(),
			};

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ChangeUser(EditUserViewModel model)
		{
			if(ModelState.IsValid)
			{
				Guid imageId = model.ImageId;

				if(model.ImageFile != null)
				{
					imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
				}

				User user = await _userHelper.GetUserAsync(User.Identity.Name);

				user.FirstName = model.FirstName;
				user.LastName = model.LastName;
				user.PhoneNumber = model.PhoneNumber;
				user.ImageId = imageId;
				user.Document = model.Document;
				user.DocumentType = await _context.DocumentTypes.FindAsync(model.DocumentTypeId);

				await _userHelper.UpdateUserAsync(user);

				return RedirectToAction("Index", "Home");
			}

			model.DocumentTypes = _combosHelper.GetComboDocumentTypes();
			return View(model);
		}

		public IActionResult ChangePassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if(ModelState.IsValid)
			{
				User user = await _userHelper.GetUserAsync(User.Identity.Name);
				if(user != null)
				{
					IdentityResult result = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
					if(result.Succeeded)
					{
						return RedirectToAction("ChangeUser");
					}
					else
					{
						ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Usuario no encontrado");
				}
			}
			return View(model);
		}

	}
}
