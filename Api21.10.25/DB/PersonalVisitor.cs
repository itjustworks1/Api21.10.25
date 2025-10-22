using System;
using System.Collections.Generic;

namespace Api21._10._25.DB;

public partial class PersonalVisitor
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Organization { get; set; }

    public DateOnly BirthDate { get; set; }

    public string PassportSeries { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public virtual Application Application { get; set; } = null!;
}
