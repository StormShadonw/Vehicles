using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Controllers
{
	[Authorize(Roles ="Admin")]
	public class ProceduresController : Controller
	{
		private readonly DataContext _context;
		public ProceduresController(DataContext context)
		{
			_context = context;
		}

		// GET: VehicleTypes
		public async Task<IActionResult> Index()
		{
			return View(await _context.Procedures.ToListAsync());
		}

		// GET: VehicleTypes/Create
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Procedure procedure)
		{
			procedure.CreateDate = DateTime.Now;
			procedure.CreatedBy = Environment.UserName;
			procedure.IsActive = true;
			var errors = ModelState
			.Where(x => x.Value.Errors.Count > 0)
			.Select(x => new { x.Key, x.Value.Errors })
			.ToArray();
			Console.WriteLine(ModelState.ErrorCount);
			Console.WriteLine(errors.Length);
			if (errors.Length == 0)
			{
				try
				{
					_context.Add(procedure);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
					{
						ModelState.AddModelError(string.Empty, "Ya existe este procedimiento.");
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
			}
			return View(procedure);
		}

		// GET: VehicleTypes/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Procedure vehicleType = await _context.Procedures.FindAsync(id);
			if (vehicleType == null)
			{
				return NotFound();
			}
			return View(vehicleType);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Procedure procedure)
		{
			if (id != procedure.Id)
			{
				return NotFound();
			}



			if (ModelState.IsValid)
			{
				try
				{
					procedure.UpdateDate = DateTime.Now;
					procedure.UpdatedBy = Environment.UserName;
					_context.Update(procedure);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
					{
						ModelState.AddModelError(string.Empty, "Ya existe este procedimiento.");
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
			}
			return View(procedure);
		}

		// GET: VehicleTypes/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Procedure procedure = await _context.Procedures
				.FirstOrDefaultAsync(m => m.Id == id);
			if (procedure == null)
			{
				return NotFound();
			}

			_context.Procedures.Remove(procedure);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
