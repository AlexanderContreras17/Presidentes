using System;
using System.Collections.Generic;

namespace Unidad2Ejercicio2.Models.Entities;

public partial class Estadorepublica
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Presidente> Presidente { get; set; } = new List<Presidente>();
}
