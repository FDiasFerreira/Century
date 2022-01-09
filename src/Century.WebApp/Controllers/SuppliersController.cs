using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Century.WebApp.Models;
using Century.Business.Interfaces;
using AutoMapper;
using Century.Business.Models;

namespace Century.WebApp.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;


        public SuppliersController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }             
       
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository
                 .ObterTodos()));
        }
       
        public async Task<IActionResult> Details(Guid id)
        {
            var supplierViewModel = await GetSupplierAddressPhoneEmail(id);

            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);           
        }

        
        public IActionResult Create()
        {
            return View();
        }
             
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(supplierViewModel);
            }

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Adicionar(supplier);

            return RedirectToAction("Index");
        }
      
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplierViewModel = await GetSupplierProductsAddressPhoneEmail(id);
           
            if (supplierViewModel == null)
            {
                return NotFound();
            }
            return View(supplierViewModel);
        }

        // POST: Suppliers/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(supplierViewModel);
            }

            var supplier = _mapper.Map<Supplier>(supplierViewModel);
            await _supplierRepository.Atualizar(supplier);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var supplierViewModel = await GetSupplierAddressPhoneEmail(id);
                
            if (supplierViewModel == null)
            {
                return NotFound();
            }

            return View(supplierViewModel);
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supplierViewModel = await GetSupplierAddressPhoneEmail(id);

            if(supplierViewModel == null)
            {
                return NotFound();
            }

            await _supplierRepository.Remover(id);

            return RedirectToAction("Index");
        }      


        private async Task<SupplierViewModel> GetSupplierAddressPhoneEmail(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository
                .GetSupplierAddressPhoneEmail(id));
        }

        private async Task<SupplierViewModel> GetSupplierProductsAddressPhoneEmail(Guid id)
        {
            return _mapper.Map<SupplierViewModel>(await _supplierRepository
                .GetSupplierProductsAddressPhoneEmail(id));
        }


    }
}
