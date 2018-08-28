using System.Collections.Generic;
using BionicInventory.Application.Interfaces;
using BionicInventory.Domain.Items;

namespace BionicInventory.Application.Items.Interfaces
{
    public interface IItemsQuery: IBasicQuery<Item>
    {
    }
}