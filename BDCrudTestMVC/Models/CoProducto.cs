using System;
using System.Collections.Generic;

namespace BDCrudTestMVC.Models;

public partial class CoProducto
{
    public int NIdProduct { get; set; }

    public string? CNombProdu { get; set; }

    public decimal? NPrecioProd { get; set; }

    public int? NIdCategori { get; set; }

    public virtual CoCategorium? NIdCategoriNavigation { get; set; }
}
