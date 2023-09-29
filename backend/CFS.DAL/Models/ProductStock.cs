using System;
using System.Collections.Generic;

namespace CFS.DAL.Models;

public partial class ProductStock
{
    public int StockId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Product? Product { get; set; }
}
