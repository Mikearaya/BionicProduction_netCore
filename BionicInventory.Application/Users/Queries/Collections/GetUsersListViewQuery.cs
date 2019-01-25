/*
 * @CreateTime: Jan 25, 2019 9:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:36 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using BionicInventory.Application.Users.Models;
using MediatR;

namespace BionicInventory.Application.Users.Queries.Collections {
    public class GetUsersListViewQuery : IRequest<IEnumerable<UserViewModel>> {

    }
}