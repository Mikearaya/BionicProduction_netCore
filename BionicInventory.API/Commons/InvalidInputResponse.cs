using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BionicInventory.API.Commons {
    public class InvalidInputResponse : ObjectResult {
        public InvalidInputResponse (ModelStateDictionary value) : base (new SerializableError (value)) {

            if (value == null) {
                throw new ArgumentNullException (nameof (value));
            }

            StatusCode = 422;
        }
    }
}