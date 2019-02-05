using System;
using System.Collections.Generic;

namespace BionicInventory.Application.Customers.Commandes {
    public abstract class GeneralQuery<T, E> where T : class {

        IEnumerable<E> GetAll () {
            throw new NotImplementedException ();
        }
    }
}