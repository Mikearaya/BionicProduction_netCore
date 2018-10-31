using System.Collections.Generic;

namespace BionicInventory.Application.Interfaces {
    public interface IBasicQuery<T> where T : class {
        T GetById (uint id);
        IEnumerable<T> GetAll ();
    }
}