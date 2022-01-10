//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Century.Business.Interfaces;
//using Century.Business.Models;
//using Century.WebApp.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace Century.WebApp.Controllers
//{
//    public class CategoriesController : BaseController
//    {

//        private readonly ICategoryRepository _categoryRepository;
//        private readonly IProductRepository _productRepository;
//        private readonly IMapper _mapper;

//        public CategoriesController(ICategoryRepository categoryRepository, 
//            IProductRepository productrepository, IMapper mapper)
//        {
//            _categoryRepository = categoryRepository;
//            _productRepository = productrepository;
//            _mapper = mapper;
//        }

//        public async Task<IActionResult> Index()
//        {
//            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetCategories()));
//        }

//        public async Task<IActionResult> Details(Guid id)
//        {
//            var categoryViewModel = await GetCategory(id);

//            if (categoryViewModel == null)
//            {
//                return NotFound();
//            }

//            return View(categoryViewModel);
//        }

//        public async Task<IActionResult> Create()
//        {
//            var categoryViewModel = await GetCategory(new CategoryViewModel());
//            return View(categoryViewModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
//        {
//            categoryViewModel = await FillCategory(categoryViewModel);

//            if (!ModelState.IsValid)
//            {
//                return View(categoryViewModel);
//            }
            
//            await _categoryRepository.Adicionar(_mapper.Map<Category>(categoryViewModel));

//            return RedirectToAction("Index");
//        }

//        public async Task<IActionResult> Edit(Guid id)
//        {
//            var categoryViewModel = await GetCategory(id);

//            if (categoryViewModel == null)
//            {
//                return NotFound();
//            }
//            return View(categoryViewModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(Guid id, CategoryViewModel categoryViewModel)
//        {
//            if (id != categoryViewModel.Id)
//            {
//                return NotFound();
//            }                   
    
//            await _categoryRepository.Atualizar(_mapper.Map<Category>(categoryViewModel));
//            return RedirectToAction("Index");
//        }

//        public async Task<IActionResult> Delete(Guid id)
//        {
//            var category = await GetCategory(id);

//            if (category == null)
//            {
//                return NotFound();
//            }
//            return View(category);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(Guid id)
//        {
//            var category = await GetCategory(id);

//            if (category == null)
//            {
//                return NotFound();
//            }
//            await _categoryRepository.Remover(id);
//            return RedirectToAction("Index");
//        }


//        //private async Task<CategoryViewModel> GetCategory(Guid id)
//        //{
//        //    var category = _mapper.Map<CategoryViewModel>(await _categoryRepository.GetProductsByCategory(id));
//        //    category.Products = _mapper.Map<IEnumerable<ProductViewModel>>(await _categoryRepository.ObterTodos());
//        //    return category;
//        //}

//        private async Task<CategoryViewModel> GetCategory(Guid id)
//        {
//            var category = _mapper.Map<CategoryViewModel>(await _categoryRepository.GetCategory(id));
//            return category;
//        }

//        //Preencher a Model 
//        private async Task<CategoryViewModel> FillCategory(CategoryViewModel category)
//        {
//            category.Products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.ObterTodos());
//            return category;
//        }
//    }
//}
