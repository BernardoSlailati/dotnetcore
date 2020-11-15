using System;
using System.Collections.Generic;
using AutoMapper;
using Login.Data;
using Login.Dtos;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Login.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsRepo _repository;
        private readonly IMapper _mapper;
        

        public ProductsController(IProductsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductGetDto>> GetAllProducts() 
        {
            var allProducts = _repository.GetAllProducts();
            
            return View(allProducts);
        }

        [HttpGet]
        public IActionResult CreateUpdateProduct(int id=0) 
        {
            if (id == 0) 
            {
                return View(new Product());
            }
            else
            {
                return View(_repository.GetProductById(id));
            }
        }

        [HttpPost]
        public IActionResult CreateUpdateProduct(ProductCreateUpdateDto productCreateUpdateDto) 
        {
            var productCreateUpdate = _mapper.Map<Product>(productCreateUpdateDto);

            if (productCreateUpdate.Id != 0)
            {
                _repository.UpdateProduct(productCreateUpdate);
            }
            else
            {
                productCreateUpdate.Date = DateTime.Now;
                _repository.CreateProduct(productCreateUpdate);
            }
            
            _repository.SaveChanges();

            return RedirectToAction("GetAllProducts", new { userName = productCreateUpdate.UserName });
        }

        [HttpGet("{id}")]
        public IActionResult DeleteProduct(int id) 
        {
            var productDelete =  _repository.GetProductById(id);

            _repository.DeleteProduct(productDelete);
            _repository.SaveChanges();

            return RedirectToAction("GetAllProducts", new { userName = productDelete.UserName });
        }

    }
}
