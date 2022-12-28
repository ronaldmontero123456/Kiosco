using System;
using System.ComponentModel.DataAnnotations;

namespace Kiosco.App.Data
{
    public class GlobalSearchDTO
    {
        // General
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public long CUSTOMER_ID { get; set; }
        public long PaymentType { get; set; }
        public long InvoiceNo { get; set; }
        public long InvoiceType { get; set; }
        public long DeliveryStatus { get; set; }
        public long PaidStatus { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public DateTime InvoicePaidDateTime { get; set; }
        public DateTime DeleteDateTime { get; set; }
        public DateTime OracleFusionSyncDateTime { get; set; }
        public DateTime PaidToDateTime { get; set; }
        public string Module { get; set; }
        // Paging
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GlobalSearchDTO()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public GlobalSearchDTO(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 0 ? 0 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }

}

