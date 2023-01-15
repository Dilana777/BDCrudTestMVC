using System;
using System.Collections.Generic;

namespace BDCrudTestMVC.Models;

public partial class CoCategorium
{
    public int NIdCategori { get; set; }

    public string? CNombCateg { get; set; }

    public bool? CEsActiva { get; set; }

    public virtual ICollection<CoProducto> CoProductos { get; } = new List<CoProducto>();
}
