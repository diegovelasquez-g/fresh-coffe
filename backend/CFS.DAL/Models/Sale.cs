using System;
using System.Collections.Generic;

namespace CFS.DAL.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTime? SaleDate { get; set; }

    public int? UserId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public decimal? TotalAmount { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual Ticket? Ticket { get; set; }

    public virtual User? User { get; set; }
}
