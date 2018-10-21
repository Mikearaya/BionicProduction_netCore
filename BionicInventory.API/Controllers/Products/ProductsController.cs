/*
 * @CreateTime: Sep 1, 2018 9:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 21, 2018 2:06 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products {
    [InventoryAPI ("Products")]
    public class ProductsController : Controller {

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

            try {

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

            } catch (Exception) {
                return StatusCode (500, "Server Error, Try Again Later");
            }

        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (ProductView))]
        [ProducesResponseType (500)]
        public IActionResult GetAllProducts (string type = "ALL") {

            try {


                    if(type.Trim().ToUpper() == "ALL") {

                var products = _query.GetAllProduct ();
                ResponseDataFormat response = new ResponseDataFormat ();

                List<ProductView> productsList = new List<ProductView> ();

                foreach (var product in products) {
                    productsList.Add (_factory.CreateProductView (product));
                }
                response.Items = productsList;
                response.Count = productsList.Count;
                return StatusCode (200, response);
                } 


             if(type.Trim().ToUpper() == "LOW") {

                var products = _query.GetCriticalBelowStockItems();
                return StatusCode (200, products);
                } 

                return StatusCode(500, "Not geting found");
                

            } catch (System.Exception) {

                return StatusCode (500, "Server Error, Try Again Later");
            }
        }

        [HttpPost]
        [ProducesResponseType (201, Type = typeof (ProductView))]
        [ProducesResponseType (422)]
        [ProducesResponseType (409)]
        [ProducesResponseType (500)]
        public IActionResult AddProduct ([FromBody] NewProductDto newProduct) {
            try {

                if (ModelState.IsValid && newProduct != null) {

                    if (!_query.IsProductCodeUnique (newProduct.code)) {
                        return StatusCode (409, "item Code Already used for another item");
                    } else {

                        var product = _factory.CreateProductModel (newProduct);

                        var result = _command.CreateProduct (product);

                        if (result != null) {
                            ProductView productView = _factory.CreateProductView (result);
                            return StatusCode (201, productView);
                        } else {
                            return StatusCode (422, "One or more required fields missing for Product");
                        }
                    }

                } else {
                    return StatusCode (422, "One or more required fields missing for Product");
                }

            } catch (Exception) {
                return StatusCode (500, "Server Error, Try Again Later");
            }
        }


        [HttpPut ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateProductRecord (uint id, [FromBody] UpdatedProductDto updatedData) {

            try {
                
                if(updatedData != null){
                    return StatusCode(400);
                }
                
                if (!ModelState.IsValid) {
                    return new InvalidInputResponse(ModelState);
                }

                    var product = _query.GetProductById (id);
                    if (product != null) {

                        var updatedProduct = _factory.ProductUpdateModel (product, updatedData);

                        if (_command.UpdateProduct (updatedProduct)) {
                            return StatusCode (204);
                        } else {
                            return StatusCode (500, "Unkown Error Occured while processing Request, Try Again");
                        }

                    } else {
                        return StatusCode (404);
                    }

            } catch (Exception) {
                return StatusCode (500, "Server Error, Try Again Later");
            }
        }

        [HttpPut]
        [ProducesResponseType (204)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public IActionResult UpdateProductRecord ([FromBody] UpdatedProductDto updatedData) {

            try {

                if (ModelState.IsValid && updatedData != null) {

                    var product = _query.GetProductById (updatedData.id);
                    if (product != null) {

                        var updatedProduct = _factory.ProductUpdateModel (product, updatedData);

                        if (_command.UpdateProduct (updatedProduct)) {
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

            } catch (Exception) {

                return StatusCode (500, "Server Error, Try Again Later");
            }

        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (204)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public IActionResult DeleteProduct (uint id) {
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
                return StatusCode (500, "Server Error, Try Again Later");
            }
        }

    }
}