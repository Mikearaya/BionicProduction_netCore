/*
 * @CreateTime: Nov 6, 2018 11:42 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 12, 2018 1:24 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Application.Invoices.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Interfaces;
using BionicInventory.Application.Invoices.InvoicePayment.Models;
using BionicInventory.Application.SalesOrders.Interfaces;
using BionicInventory.API.Commons;
using BionicInventory.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicInventory.API.Controllers.Invoices.InvoicePayment {
    [InventoryAPI ("invoices")]
    public class InvoicePaymentController : Controller {
        private readonly IInvoicePaymentFactory _factory;
        private readonly ILogger<InvoicePaymentController> _logger;
        private readonly ISalesOrderQuery _customerOrderQuery;
        private readonly IInvoicesQuery _invoiceQuery;
        private readonly IInvoicePaymentCommand _command;

        public IInvoicePaymentQuery _query { get; }

        public InvoicePaymentController (
            IInvoicePaymentCommand command,
            IInvoicePaymentQuery query,
            IInvoicePaymentFactory factory,
            IInvoicesQuery invoiceQuery,
            ISalesOrderQuery customerOrderQuery,
            ILogger<InvoicePaymentController> logger) {
            _command = command;
            _query = query;
            _factory = factory;
            _logger = logger;
            _customerOrderQuery = customerOrderQuery;
            _invoiceQuery = invoiceQuery;

        }


        [HttpGet ("{invoiceId}/payments")]
        public ActionResult<PaymentView> GetAllInvoicePayments (uint invoiceId) {

            var invoice = _invoiceQuery.GetInvoiceById (invoiceId);

            if (invoice == null) {
                return StatusCode (404, $"Invoice with id: {invoiceId} Not Found");
            }

            var paymentSummary = _query.GetInvoicePaymentSummary (invoiceId);
            return StatusCode (200, paymentSummary);

        }

        [HttpPost ("{invoiceId}/payments")]
        public ActionResult<PaymentView> AddInvoicePayment (uint invoiceId, [FromBody] NewInvoicePaymentDto payment) {

            if (!ModelState.IsValid) {
                return new InvalidInputResponse (ModelState);
            }

            var invoice = _invoiceQuery.GetInvoiceById (invoiceId);

            if (invoice == null) {
                return StatusCode (404, $"Invoice with id: {invoiceId} Not Found");
            }

            var paymentOject = _factory.CreateNewPayment (payment);

            var paymentSummary = _command.AddPayment (paymentOject);
            if (paymentSummary != null) {
                return StatusCode (201, paymentOject);
            }
            return StatusCode(500);

        }

    }
}