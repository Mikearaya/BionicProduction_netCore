using System;

namespace BionicInventory.Application.Shared {
    public class BelowRequiredMinimumItemException : Exception {

        public BelowRequiredMinimumItemException () {

        }
        public BelowRequiredMinimumItemException (string type, uint minimum, string requiredType) 
        : base (String.Format ("{0} required a minimum of {1} {2} to be provided", type, minimum, requiredType)) {

        }
    }

}