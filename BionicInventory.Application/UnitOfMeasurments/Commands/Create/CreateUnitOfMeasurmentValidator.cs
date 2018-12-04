/*
 * @CreateTime: Dec 4, 2018 7:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 7:59 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.UnitOfMeasurments.Models;
using FluentValidation;

namespace BionicInventory.Application.UnitOfMeasurments.Commands.Create {
    public class CreateUnitOfMeasurmentValidator : AbstractValidator<NewUnitOfMeasureDto> {
        public CreateUnitOfMeasurmentValidator () {
            RuleFor (u => u.Abrivation).NotEmpty ();
            RuleFor (u => u.Active).NotNull ();
            RuleFor (u => u.Name).NotEmpty ();
        }
    }
}