/*
 * @CreateTime: Sep 1, 2018 9:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 5, 2018 9:35 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BionicInventory.Application.Products.BOMs.Queries.Collection;
using BionicInventory.Application.Products.BOMs.Queries.Models;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Application.Shared.Exceptions;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using BionicInventory.Domain.Items;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Products {
    [InventoryAPI ("Products")]
    public class ProductsController : Controller {

        private readonly IProductsCommand _command;
        private readonly IProductsQuery _query;
        private readonly IProductsFactory _factory;

        public IMediator _Mediator { get; }

        public ProductsController (
            IProductsCommand command,
            IProductsQuery query,
            IProductsFactory factory,
            IMediator mediator
        ) {
            _command = command;
            _query = query;
            _factory = factory;
            _Mediator = mediator;
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public ActionResult<ProductView> GetProductById (uint id, string type = "VIEW") {

            Object productView = null;
            if (id == 0) {
                return StatusCode (400);
            }

            if (!ModelState.IsValid) {
                return StatusCode (422, ModelState);
            }

            if (type.ToUpper () == "LOW") {
                productView = _query.GetCriticalBelowStockItem (id);
            } else {
                productView = _query.GetProductViewById (id);
            }

            if (productView == null) {
                return StatusCode (404);
            }

            return StatusCode (200, productView);

        }

        [HttpGet]
        [ProducesResponseType (200, Type = typeof (ProductView))]
        [ProducesResponseType (500)]
        public IActionResult GetAllProducts (string type = "ALL") {

            try {
                IEnumerable<Object> products = null;

                if (type.Trim ().ToUpper () == "ALL") {

                    products = _query.GetAllProduct ();
                    ResponseDataFormat response = new ResponseDataFormat ();

                    List<ProductView> productsList = new List<ProductView> ();

                    foreach (var product in products) {
                        productsList.Add (_factory.CreateProductView ((Item) product));
                    }
                    response.Items = productsList;
                    response.Count = productsList.Count;

                    return StatusCode (200, response);
                }

                if (type.Trim ().ToUpper () == "LOW") {

                    products = _query.GetCriticalBelowStockItems ();
                    return StatusCode (200, products);
                }

                return StatusCode (500, "Not geting found");

            } catch (Exception e) {

                return StatusCode (500, e.Message);
            }
        }

        // api/id/boms
        [HttpGet ("{id}/boms")]
        [ProducesResponseType (200)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public async Task<ActionResult<IEnumerable<BomView>>> GetItemBoms (uint id) {

            if (id == 0) {
                return StatusCode (400);
            }

            try {

                var itemBom = await _Mediator.Send (new ItemBomViewQuery () { ItemId = id });
                return StatusCode (200, itemBom);

            } catch (NotFoundException e) {

                return StatusCode (404, e.Message);
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
                            return StatusCode (500, "One or more required fields missing for Product");
                        }
                    }

                } else {
                    return new InvalidInputResponse (ModelState);
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

                if (updatedData == null) {
                    return StatusCode (400);
                }

                if (!ModelState.IsValid) {
                    return new InvalidInputResponse (ModelState);
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