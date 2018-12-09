/*
 * @CreateTime: Dec 9, 2018 11:37 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2018 11:46 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Bionic_inventory.Application.Interfaces;
using BionicInventory.Application.Workstations.Models;
using MediatR;

namespace BionicInventory.Application.Workstations.Queries.Collection {
    public class WorkstationListQuery : IRequest<IEnumerable<WorkstationView>> { }
}