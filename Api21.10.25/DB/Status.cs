using System;
using System.Collections.Generic;

namespace Api21._10._25.DB;
/// <summary>
/// Статус
/// </summary>
public partial class Status
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
