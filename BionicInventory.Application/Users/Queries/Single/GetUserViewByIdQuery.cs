/*
 * @CreateTime: Jan 25, 2019 9:36 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 25, 2019 9:36 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Users.Models;
using MediatR;

namespace BionicInventory.Application.Users.Queries.Single {
    public class GetUserViewByIdQuery : IRequest<UserViewModel> {
        public string Id { get; set; }
    }
}