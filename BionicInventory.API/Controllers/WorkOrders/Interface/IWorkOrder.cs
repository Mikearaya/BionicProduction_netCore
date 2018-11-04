



using BionicInventory.Application.ProductionOrders.Models;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.WorkOrders.Interface {

    public interface IWorkOrder {
        IActionResult CreateNewWorkWorder (NewWorkOrderDto newWork);
    }
}