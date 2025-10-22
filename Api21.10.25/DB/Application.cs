using System;
using System.Collections.Generic;

namespace Api21._10._25.DB;

public partial class Application
{
    public int Id { get; set; }

    public int ApplicationTypeId { get; set; }

    public int StatusId { get; set; }

    public string? RejectionReason { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Purpose { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int EmployeeId { get; set; }

    public string ApplicantEmail { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ApplicationType ApplicationType { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<GroupApplicationContact> GroupApplicationContacts { get; set; } = new List<GroupApplicationContact>();

    public virtual ICollection<PersonalVisitor> PersonalVisitors { get; set; } = new List<PersonalVisitor>();

    public virtual Status Status { get; set; } = null!;
}
