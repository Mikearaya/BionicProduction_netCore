/*
 * @CreateTime: Jan 27, 2019 9:21 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 27, 2019 9:29 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.AspNetCore.Mvc;

namespace BionicInventory.API.Commons {
    public static class BionicApiResponseConvention {

        [ProducesDefaultResponseType]
        [ProducesResponseType (200)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (500)]
        public static void GetListAuth () { }

        [ProducesDefaultResponseType]
        [ProducesResponseType (200)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public static void GetSingleAuth () { }

        [ProducesDefaultResponseType]
        [ProducesResponseType (201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public static void CreateAuth () { }

        [ProducesDefaultResponseType]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (422)]
        [ProducesResponseType (500)]
        public static void UpdateAuth () { }

        [ProducesDefaultResponseType]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (403)]
        [ProducesResponseType (404)]
        [ProducesResponseType (500)]
        public static void DeleteAuth () { }
    }
}