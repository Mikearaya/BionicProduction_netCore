/*
 * @CreateTime: Sep 14, 2018 10:17 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 21, 2018 10:32 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace BionicInventory.Application.FinishedProducts.Models {
    public class FinishedProductsViewModel {
        public string product { get; set; }

        public float cost { get; set; }
        public int quantity { get; set; }
    }
}