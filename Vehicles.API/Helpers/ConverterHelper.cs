﻿using System;
using System.Threading.Tasks;
using Vehicles.API.Data;
using Vehicles.API.Data.Entities;
using Vehicles.API.Models;

namespace Vehicles.API.Helpers
{
	public class ConverterHelper : IConverterHelper
	{
		private readonly DataContext _context;
		private readonly ICombosHelper _combosHelper;

		public ConverterHelper(DataContext context, ICombosHelper combosHelper)
		{
			_context = context;
			_combosHelper = combosHelper;
		}
		public async Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew)
		{
			return new User
			{
				Address = model.Address,
				Document = model.Document,
				DocumentType = await _context.DocumentTypes.FindAsync(model.DocumentTypeId),
				Email = model.Email,
				FirstName = model.FirstName,
				Id = isNew ? Guid.NewGuid().ToString() : model.Id,
				ImageId = imageId,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber,
				UserName = model.Email,
				UserType = model.UserType,
				Vehicles = model.Vehicles,
			};
		}

		public UserViewModel ToUserViewModel(User user)
		{
			return new UserViewModel
			{
				Address = user.Address,
				Document = user.Document,
				DocumentType = user.DocumentType,
				DocumentTypeId = user.DocumentType.Id,
				DocumentTypes = _combosHelper.GetComboDocumentTypes(),
				Email = user.Email,
				FirstName = user.FirstName,
				Id = user.Id,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				UserName = user.Email,
				UserType = user.UserType,
				Vehicles = user.Vehicles,
				ImageId = user.ImageId,
			};
		}

		public async Task<Vehicle> ToVehicleAsync(VehicleViewModel model, bool isNew)
		{
			return new Vehicle
			{
				Brand = await _context.Brands.FindAsync(model.BrandId),
				Color = model.Color,
				Id = isNew ? 0 : model.Id,
				Year = model.Year,
				Model = model.Model,
				Plaque = model.Plaque.ToUpper(),
				Remarks = model.Remarks,
				VehicleType = await _context.VehicleTypes.FindAsync(model.VehicleTypeId),
			};
		}

		public VehicleViewModel ToVehicleViewModel(Vehicle vehicle)
		{
			return new VehicleViewModel
			{
				BrandId = vehicle.Brand.Id,
				Brands = _combosHelper.GetComboBrands(),
				Color = vehicle.Color,
				Id = vehicle.Id,
				Year = vehicle.Year,
				Model = vehicle.Model,
				Plaque = vehicle.Plaque.ToUpper(),
				Remarks = vehicle.Remarks,
				UserId = vehicle.User.Id,
			};
		}
	}
}
