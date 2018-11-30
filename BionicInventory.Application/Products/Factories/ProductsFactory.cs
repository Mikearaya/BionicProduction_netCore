/*
 * @CreateTime: Sep 1, 2018 7:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 3:03 PM
 * @Description: Product Factory Class
 */
using System;
using System.Collections.Generic;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.ItemPrices;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Products.Factories {
    public class ProductsFactory : IProductsFactory {
        private readonly ILogger<ProductsFactory> _logger;

        public ProductsFactory (ILogger<ProductsFactory> logger) {
            _logger = logger;
        }
        public Item CreateProductModel (NewProductDto newProduct) {

            try {

                return new Item () {
                    Name = newProduct.name,
                        Code = newProduct.code,
                        Weight = newProduct.weight,
                        UnitCost = newProduct.unitCost,
                        Photo = newProduct.photo,
                        MinimumQuantity = newProduct.MinimumQuantity,
                        GroupId = newProduct.groupId,
                        ShelfLife = newProduct.shelfLife,
                        IsInventory = newProduct.isInventoryItem,
                        IsProcured = newProduct.isProcured,
                        ManufacturingUomId = newProduct.manufacturingUomId,
                        StoringUomId = newProduct.stockUomId,
                        Price = newProduct.price
                };

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public ProductView CreateProductView (Item product) {

            try {
                var productView = new ProductView ();

                productView.id = product.Id;
                productView.name = product.Name;
                productView.weight = product.Weight;
                productView.unitCost = product.UnitCost;
                productView.photo = product.Photo;
                productView.code = product.Code;
    
                productView.minimumQuantity = product.MinimumQuantity;

                return productView;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }

        public Item ProductUpdateModel (Item product, UpdatedProductDto updatedProduct) {

            try {

        
                product.Name = updatedProduct.name;
                product.UnitCost = updatedProduct.unitCost;
                product.Photo = updatedProduct.photo;
                product.Weight = updatedProduct.weight;
                product.MinimumQuantity = updatedProduct.MinimumQuantity;

                return product;

            } catch (Exception e) {
                _logger.LogError (1, e.Message, e);
                return null;
            }
        }
    }
}