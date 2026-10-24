using AutoMapper;
using CarRentalApp.Data;
using CarRentalApp.Dtos;
using CarRentalApp.Helpers;
using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Cars (Arama ve Sayfalama Desteğiyle)
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            var carsQuery = _context.Cars.AsQueryable();

            // Arama filtresi (Marka veya Modele göre)
            if (!string.IsNullOrEmpty(searchString))
            {
                carsQuery = carsQuery.Where(c => c.Brand.Contains(searchString) || c.Model.Contains(searchString));
            }

            // Entity'leri DTO'ya dönüştürüp listeliyoruz
            var carsList = await carsQuery
                .Select(c => _mapper.Map<CarDto>(c))
                .ToListAsync();

            int pageSize = 4; // Sayfa başına araç sayısı
            var paginatedCars = PaginatedList<CarDto>.CreateAsync(
                carsQuery.Select(c => _mapper.Map<CarDto>(c)),
                pageNumber ?? 1,
                pageSize
            );

            // Alternatif pratik yaklaşım için doğrudan PaginatedList helper'ını kullanalım:
            var pagedData = await PaginatedList<CarDto>.CreateAsync(
                carsQuery.Select(c => _mapper.Map<CarDto>(c)),
                pageNumber ?? 1,
                pageSize
            );

            return View(pagedData);
        }
        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();

            var carDto = _mapper.Map<CreateCarDto>(car); // Veya uygun DTO
            ViewBag.CarId = id;
            return View(carDto);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateCarDto updateCarDto)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();

            if (ModelState.IsValid)
            {
                car.Brand = updateCarDto.Brand;
                car.Model = updateCarDto.Model;
                car.Year = updateCarDto.Year;
                car.DailyPrice = updateCarDto.DailyPrice;

                _context.Update(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CarId = id;
            return View(updateCarDto);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarDto createCarDto)
        {
            if (ModelState.IsValid)
            {
                var car = _mapper.Map<Car>(createCarDto);
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createCarDto);
        }
    }
}