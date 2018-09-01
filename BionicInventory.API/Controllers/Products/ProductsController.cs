/*
 * @CreateTime: Sep 1, 2018 9:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 1, 2018 9:14 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products
{
    [InventoryAPI("Products")]
    public class ProductsController : Controller
    {
        
        private readonly IProductsCommand _command;
        private readonly IProductsQuery _query;
        private readonly IProductsFactory _factory;

        public ProductsController (
            IProductsCommand command,
            IProductsQuery query,
            IProductsFactory factory
        ) {
            _command = command;
            _query = query;
            _factory = factory;
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200, Type = typeof (ProductView))]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult GetProductById (uint id) {

            if (ModelState.IsValid && id != 0) {

                try {
                    var product = _query.GetProductById (id);

                    if (product != null) {
                        var productView = _factory.CreateProductView (product);
                        return StatusCode (200, productView);
                    } else {
                        return StatusCode (404);
                    }
                } catch (Exception) {
                    return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                }

            } else {
                return StatusCode (422, "Invalid Parameter For Product Id");
            }

        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (ProductView))]
        [ProducesResponseType (500)]
        public IActionResult GetAllProducts () {

            try {

                var products = _query.GetAllProduct ();
                List<ProductView> productsList = new List<ProductView> ();

                foreach (var product in products) {
                    productsList.Add (_factory.CreateProductView (product));
                }

                return StatusCode (200, productsList);

            } catch (System.Exception) {

                return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
            }
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (ProductView))]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult AddProduct ([FromBody] ProductDTO newProduct) {

            if (ModelState.IsValid && newProduct != null) {
                    var product = _command.CreateProduct (newProduct);
                    if (product != null) {
                        return StatusCode (201, product);
                    } else {
                        return StatusCode (422, "One or more required fields missing for Product");
                    }

            } else {
                return StatusCode (422, "One or more required fields missing for Product");
            }
        }

        [HttpPost("{productId}/prices")]
        [ProducesResponseType(201, Type = typeof(ProductView))]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult AddProductPrices(uint productId, IEnumerable<ProductPriceDTO> prices) {
            throw new NotImplementedException();
        }



        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateProductRecord (uint id, [FromBody] ProductDTO updatedData) {

            if (ModelState.IsValid && updatedData != null) {

                var product = _query.GetProductById (id);
                if (product != null) {

                    if (_command.UpdateProduct (product, updatedData)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                    }

                } else {
                    return StatusCode (404);
                }

            } else {
                return StatusCode (422, "One or more required fields missing for employee");
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteSingleProductRecord (uint id) {

            try {
                var product = _query.GetProductById (id);

                if (product != null) {

                    if (_command.DeleteProduct (product)) {
                        return StatusCode (204);
                    } else {
                        return StatusCode (422);
                    }

                } else {

                    return StatusCode (404);
                }
            } catch (Exception) {

                return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
            }
    }
}

}
