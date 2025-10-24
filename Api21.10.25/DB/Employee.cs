using System;
using System.Collections.Generic;

namespace Api21._10._25.DB;
/// <summary>
/// сотрудник
/// </summary>
public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Department Department { get; set; } = null!;
}
