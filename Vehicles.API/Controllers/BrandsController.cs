﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Controllers
{
	public class BrandsController : Controller
	{
		private readonly DataContext _context;

		public BrandsController(DataContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _context.Brands.ToListAsync());
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Brand brand)
		{
			brand.CreateDate = DateTime.Now;
			brand.CreatedBy = Environment.UserName;
			brand.IsActive = true;
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
					_context.Add(brand);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
					{
						ModelState.AddModelError(string.Empty, "Ya existe esta marca.");
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
			return View(brand);
		}
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Brand brand = await _context.Brands.FindAsync(id);
			if (brand == null)
			{
				return NotFound();
			}
			return View(brand);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Brand brand)
		{
			if (id != brand.Id)
			{
				return NotFound();
			}



			if (ModelState.IsValid)
			{
				try
				{
					brand.UpdateDate = DateTime.Now;
					brand.UpdatedBy = Environment.UserName;
					_context.Update(brand);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException dbUpdateException)
				{
					if (dbUpdateException.InnerException.Message.Contains("duplicate"))
					{
						ModelState.AddModelError(string.Empty, "Ya existe esta marca.");
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
			return View(brand);
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Brand brand = await _context.Brands
				.FirstOrDefaultAsync(m => m.Id == id);
			if (brand == null)
			{
				return NotFound();
			}

			_context.Brands.Remove(brand);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
