//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Century.WebApp.Data;
//using Century.WebApp.Models;

//namespace Century.WebApp.Controllers
//{
//    public class AddressesController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public AddressesController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Addresses
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.AddressViewModel.ToListAsync());
//        }

//        // GET: Addresses/Details/5
//        public async Task<IActionResult> Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var addressViewModel = await _context.AddressViewModel
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (addressViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(addressViewModel);
//        }

//        // GET: Addresses/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Addresses/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,ZipCode,Street,Number,Complement,Reference,Neighborhood,City,State,SupplierId")] AddressViewModel addressViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                addressViewModel.Id = Guid.NewGuid();
//                _context.Add(addressViewModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(addressViewModel);
//        }

//        // GET: Addresses/Edit/5
//        public async Task<IActionResult> Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var addressViewModel = await _context.AddressViewModel.FindAsync(id);
//            if (addressViewModel == null)
//            {
//                return NotFound();
//            }
//            return View(addressViewModel);
//        }

//        // POST: Addresses/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ZipCode,Street,Number,Complement,Reference,Neighborhood,City,State,SupplierId")] AddressViewModel addressViewModel)
//        {
//            if (id != addressViewModel.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(addressViewModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AddressViewModelExists(addressViewModel.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(addressViewModel);
//        }

//        // GET: Addresses/Delete/5
//        public async Task<IActionResult> Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var addressViewModel = await _context.AddressViewModel
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (addressViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(addressViewModel);
//        }

//        // POST: Addresses/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(Guid id)
//        {
//            var addressViewModel = await _context.AddressViewModel.FindAsync(id);
//            _context.AddressViewModel.Remove(addressViewModel);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AddressViewModelExists(Guid id)
//        {
//            return _context.AddressViewModel.Any(e => e.Id == id);
//        }
//    }
//}
