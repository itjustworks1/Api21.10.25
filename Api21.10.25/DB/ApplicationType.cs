using System;
using System.Collections.Generic;

namespace Api21._10._25.DB;
/// <summary>
/// Тип заявки
/// </summary>
public partial class ApplicationType
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
