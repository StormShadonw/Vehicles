using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Vehicles.API.Helpers
{
	public interface ICombosHelper
	{
		IEnumerable<SelectListItem> GetCombosDocumentTypes();
		IEnumerable<SelectListItem> GetCombosProcedures();
		IEnumerable<SelectListItem> GetCombosVehicleTypes();
		IEnumerable<SelectListItem> GetCombosBrands();
	}
}
