/*
 * @CreateTime: Jan 8, 2019 10:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 8, 2019 10:32 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Models;

namespace BionicInventory.Application.Interfaces {
    public interface ISystemFunctionDiscovery {
        IEnumerable<MvcControllerInfo> GetFunctions ();

    }
}