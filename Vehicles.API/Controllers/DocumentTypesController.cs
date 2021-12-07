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
	public class DocumentTypesController : Controller
	{
		private readonly DataContext _context;

		public DocumentTypesController(DataContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _context.DocumentTypes.ToListAsync());
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DocumentType documentType)
		{
			documentType.CreateDate = DateTime.Now;
			documentType.CreatedBy = Environment.UserName;
			documentType.IsActive = true;
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
					_context.Add(documentType);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
					{
						ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
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
			return View(documentType);
		}
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			DocumentType documentType = await _context.DocumentTypes.FindAsync(id);
			if (documentType == null)
			{
				return NotFound();
			}
			return View(documentType);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, DocumentType documentType)
		{
			if (id != documentType.Id)
			{
				return NotFound();
			}



			if (ModelState.IsValid)
			{
				try
				{
					documentType.UpdateDate = DateTime.Now;
					documentType.UpdatedBy = Environment.UserName;
					_context.Update(documentType);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
					{
						ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
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
			return View(documentType);
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			DocumentType documentType = await _context.DocumentTypes
				.FirstOrDefaultAsync(m => m.Id == id);
			if (documentType == null)
			{
				return NotFound();
			}

			_context.DocumentTypes.Remove(documentType);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
