﻿using System;
using System.Collections.Generic;

namespace Api21._10._25.DB;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
