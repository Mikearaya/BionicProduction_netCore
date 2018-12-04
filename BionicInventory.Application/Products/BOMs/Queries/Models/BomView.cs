/*
 * @CreateTime: Dec 4, 2018 11:09 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 11:24 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicInventory.Domain.Items.BOMs;
using MediatR;

namespace BionicInventory.Application.Products.BOMs.Queries.Models {
    public class BomView : IRequest {
        public uint id { get; set; }
        public string name { get; set; }
        public string item { get; set; }
        public uint itemId { get; set; }
        public bool active { get; set; }
        public DateTime? dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        public IEnumerable<BomItemView> bomItems { get; set; } = new List<BomItemView> ();

        public static Expression<Func<Bom, BomView>> Projection {
            get {
                return bom => new BomView {
                    id = bom.Id,
                    name = bom.Name,
                    item = bom.Item.Name,
                    itemId = bom.ItemId,
                    active = (bom.Active == 1) ? true : false,
                    dateAdded = bom.DateAdded,
                    dateUpdated = bom.DateUpdated,
                    bomItems = bom.BomItems.AsQueryable ().Select (BomItemView.Projection)

                };
            }
        }

        public static BomView Create (Bom bom) {
            return Projection.Compile ().Invoke (bom);
        }
    }
}