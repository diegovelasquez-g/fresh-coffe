using System;
using System.Collections.Generic;

namespace CFS.DAL.Models;

public partial class Ticket
{
    public int SaleId { get; set; }

    public string TicketNumber { get; set; } = null!;

    public DateTime? IssueDate { get; set; }

    public virtual Sale Sale { get; set; } = null!;
}
