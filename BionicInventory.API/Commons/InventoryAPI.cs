using System;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BionicInventory.Commons {

  public class InventoryAPI : Attribute, IRouteTemplateProvider {

    public string Template { get; set; }
    public InventoryAPI (string controller) {
      Template = $"api/{controller}";
    }

    public int? Order { get; set; }

    public string Name { get; set; }
  }

}