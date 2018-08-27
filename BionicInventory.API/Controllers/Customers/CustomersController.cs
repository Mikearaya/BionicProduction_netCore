using BionicInventory.Application.Customers.Interfaces.Query;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Controllers.Customers
{
    [InventoryAPI("customers")]
    public class CustomersController: Controller
    {
        private readonly ICustomersQuery _customersQuery;

        public CustomersController(ICustomersQuery customersquery) {
            _customersQuery = customersquery;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAllCustomers() {
            var x =_customersQuery.GetAll();
            return Ok(x);
        }
        
    }
}