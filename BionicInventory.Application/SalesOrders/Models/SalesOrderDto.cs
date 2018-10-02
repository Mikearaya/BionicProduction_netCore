/*
 * @CreateTime: Sep 23, 2018 7:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 26, 2018 9:20 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace BionicInventory.Application.SalesOrders.Models {
    public abstract class SalesOrderDto {

        const string cash = "CASH";
        const string check = "CHECK";

        private float _minimumQuantity = 0;
        private string _paymentMethod = "CHECK";
        [Required]
        public uint ClientId { get; set; }

        [Required]
        public string PaymentMethod {
            get {
                return _paymentMethod.Trim ().ToUpper ();
            }
            set {
                _paymentMethod =
                    (
                        value.ToString ().ToUpper () != "CASH" &&
                        value.ToString ().ToUpper () != "CHECK"
                    ) ?
                    "CASH" :
                    value.ToString ().ToUpper ();
            }
        }

        [Required]
        public float InitialPayment { get; set; }

        [Required]
        public uint CreatedBy { get; set; }

        public string Title { get; set; }

        [MaxLength (255)]
        public string Description { get; set; }

    }
}