using System.ComponentModel.DataAnnotations;
using MediatR;

namespace BionicInventory.Application.Users.Models {
    public class PasswordUpdateDto : IRequest {
        [Required]
        public string Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmationPassword { get; set; }

    }
}