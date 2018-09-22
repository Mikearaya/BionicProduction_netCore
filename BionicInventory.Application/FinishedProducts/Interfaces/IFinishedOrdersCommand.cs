/*
 * @CreateTime: Sep 21, 2018 10:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 21, 2018 10:14 PM
 * @Description: Modify Here, Please 
 */

using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.FinishedProducts;

namespace BionicInventory.Application.FinishedProducts.Interfaces {
    public interface IFinishedProductsCommand {

        List<FinishedProduct> AddFinishedProduct(List<FinishedProduct> finishedProduct);

        bool UpdateFinishedProduct(FinishedProduct current);

        bool DeleteFinishedProduct(FinishedProduct finishedProduct);

    }
}