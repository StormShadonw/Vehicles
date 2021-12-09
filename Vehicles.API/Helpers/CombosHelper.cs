using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Vehicles.API.Data;

namespace Vehicles.API.Helpers
{
	public class CombosHelper : ICombosHelper
	{
		private readonly DataContext _context;

		public CombosHelper(DataContext context)
		{
			_context = context;
		}
		public IEnumerable<SelectListItem> GetCombosBrands()
		{
			List<SelectListItem> list = _context.Brands.Select(x => new SelectListItem
			{
				Text = x.Description,
				Value = x.Id.ToString(),
			}).OrderBy(x => x.Text).ToList();

			list.Insert(0, new SelectListItem { Text = "Selecciones una marca...", Value = "0" });
			return list;
		}

		public IEnumerable<SelectListItem> GetCombosDocumentTypes()
		{
			List<SelectListItem> list = _context.DocumentTypes.Select(x => new SelectListItem
			{
				Text = x.Description,
				Value = x.Id.ToString(),
			}).OrderBy(x => x.Text).ToList();

			list.Insert(0, new SelectListItem { Text = "Selecciones un tipo de documento...", Value = "0" });
			return list;
		}

		public IEnumerable<SelectListItem> GetCombosProcedures()
		{
			List<SelectListItem> list = _context.Procedures.Select(x => new SelectListItem
			{
				Text = x.Description,
				Value = x.Id.ToString(),
			}).OrderBy(x => x.Text).ToList();

			list.Insert(0, new SelectListItem { Text = "Selecciones un procedimiento...", Value = "0" });
			return list;
		}

		public IEnumerable<SelectListItem> GetCombosVehicleTypes()
		{
			List<SelectListItem> list = _context.VehicleTypes.Select(x => new SelectListItem
			{
				Text = x.Description,
				Value = x.Id.ToString(),
			}).OrderBy(x => x.Text).ToList();

			list.Insert(0, new SelectListItem { Text = "Selecciones un tipo de vehiculo...", Value = "0" });
			return list;
		}
	}
}
