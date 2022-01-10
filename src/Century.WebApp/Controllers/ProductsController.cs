using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Century.WebApp.Models;
using Century.Business.Interfaces;
using AutoMapper;
using Century.Business.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Century.WebApp.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository,
            ISupplierRepository supplierRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsAndSuppliers()));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var productViewModel = await FillSupplier(new ProductViewModel());
            return View(productViewModel);
        }

        // POST: Products/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            productViewModel = await FillSupplier(productViewModel);

            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            //Upload de imagem
            var imgImageName = Guid.NewGuid() + "_"; //gerando um guid vc impede 2 confusão de duas imagens com mesmo nome
            if (!await UploadFile(productViewModel.ImageUpload, imgImageName))
            {
                return View(productViewModel);
            }

            productViewModel.ImagePath = imgImageName + productViewModel.ImageUpload.FileName;

            await _productRepository.Adicionar(_mapper.Map<Product>(productViewModel));

            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = await GetProduct(id);

            if (productViewModel == null)
            {
                return NotFound();
            }
            return View(productViewModel);
        }

        // POST: Products/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                return NotFound();
            }

            var productatualize = await GetProduct(id);
            productViewModel.Supplier = productatualize.Supplier;
            productViewModel.ImagePath = productatualize.ImagePath;
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            if (productViewModel.ImageUpload != null)
            {
                var imgImageName = Guid.NewGuid() + "_";
                if (!await UploadFile(productViewModel.ImageUpload, imgImageName))
                {
                    return View(productViewModel);
                }
                productatualize.ImagePath = imgImageName + productViewModel.ImageUpload.FileName;
            }
            //evita na edição a mudança de campos que vc não quer, como adicionar um novo fornecedor, por exemplo
            productatualize.Name = productViewModel.Name;
            productatualize.BarCode = productViewModel.BarCode;
            productatualize.QuantityStock = productViewModel.QuantityStock;
            productatualize.Active = productViewModel.Active;
            productatualize.PriceSales = productViewModel.PriceSales;
            productatualize.PricePurchase = productViewModel.PricePurchase;
            productatualize.Category = productViewModel.Category;

            await _productRepository.Atualizar(_mapper.Map<Product>(productatualize));
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.Remover(id);
            return RedirectToAction("Index");
        }



        private async Task<ProductViewModel> GetProduct(Guid id)
        {
            var product = _mapper.Map<ProductViewModel>(await _productRepository.GetProductSupplier(id));
            product.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.ObterTodos());
            return product;
        }


        //Preencher a Model 
        private async Task<ProductViewModel> FillSupplier(ProductViewModel product)
        {
            product.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.ObterTodos());
            return product;
        }

        private async Task<bool> UploadFile(IFormFile file, string imgImageName)
        {
            if (file.Length <= 0) // imagem não está boa
            {
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imgImageName + file.FileName);

            if (System.IO.File.Exists(path)) // se já tiver arquivo com mesmo nome
            {
                ModelState.AddModelError(string.Empty, "There is already a file with this name!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}
