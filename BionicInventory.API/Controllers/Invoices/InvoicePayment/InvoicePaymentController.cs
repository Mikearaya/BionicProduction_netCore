/*
 * @CreateTime: Nov 6, 2018 11:42 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 7, 2018 12:06 AM
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
    [InventoryAPI ("salesorders")]
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

        [HttpGet ("{id}/invoices/payments")]
        [ProducesResponseType (200, Type = typeof (InvoicePaymentSummaryView))]
        [ProducesResponseType (500)]
        public IActionResult GetAllCustomerOrderInvoicePayments (uint customerOrderId) {

            var customerOrder = _customerOrderQuery.GetSalesOrderById (customerOrderId);

            if (customerOrder == null) {
                return StatusCode (404, $"Customer Order with id: {customerOrderId} Not Found");
            }

            var paymentSummary = _query.GetCustomerOrderIvoiceSummary (customerOrderId);
            return StatusCode (200, paymentSummary);

        }

        [HttpGet ("invoices/{id}/payments")]
        [ProducesResponseType (200, Type = typeof (PaymentView))]
        [ProducesResponseType (500)]
        public IActionResult GetAllInvoicePayments (uint invoiceId) {

            var invoice = _invoiceQuery.GetInvoiceById (invoiceId);

            if (invoice == null) {
                return StatusCode (404, $"Invoice with id: {invoiceId} Not Found");
            }

            var paymentSummary = _query.GetInvoicePaymentsView (invoiceId);
            return StatusCode (200, paymentSummary);

        }

        [HttpPost ("invoices/{id}/payments")]
        [ProducesResponseType (201, Type = typeof (PaymentView))]
        [ProducesResponseType (500)]
        public IActionResult AddInvoicePayment (uint invoiceId, [FromBody] NewInvoicePaymentDto payment) {

            if (payment == null) {
                return StatusCode (400);
            }

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