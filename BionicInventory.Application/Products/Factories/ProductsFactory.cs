/*
 * @CreateTime: Sep 1, 2018 7:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 1, 2018 8:16 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Products.Interfaces;
using BionicInventory.Application.Products.Models;
using BionicInventory.Domain.Items;
using BionicInventory.Domain.Items.ItemPrices;

namespace BionicInventory.Application.Products.Factories {
    public class ProductsFactory : IProductsFactory {
        public Item CreateProductModel (ProductDTO newProduct) {
            var product = new Item ();
            product.Name = newProduct.name;
            product.Code = newProduct.code;
            product.Weight = newProduct.weight;
            product.UnitCost = newProduct.unitCost;
            product.Photo = newProduct.photo;

            return product;
        }

        public IEnumerable<ItemPrice> CreateProductPriceModel (Item product, IEnumerable<ProductPriceDTO> prices) {
            
            List<ItemPrice> price = new List<ItemPrice> ();

            foreach (var value in prices) {
                var item = new ItemPrice ();
                item.ItemId = product.Id;
                item.CategoryName = value.categoryName;
                item.Currency = value.currency;
                item.Price = value.price;
                price.Add (item);
            }

            return price;
        }

        public ProductView CreateProductView (Item product) {
            var productView = new ProductView ();

            productView.id = product.Id;
            productView.name = product.Name;
            productView.weight = product.Weight;
            productView.unitCost = product.UnitCost;
            productView.photo = product.Photo;
            productView.discription = product.Description;

            return productView;
        }
    }
}