using System;
using System.Collections.Generic;

namespace Api21._10._25.DB;
/// <summary>
/// один из контактов группового посещения
/// </summary>
public partial class GroupApplicationContact
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public string ContactName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public string? ContactPhone { get; set; }

    public string? Organization { get; set; }

    public virtual Application Application { get; set; } = null!;
}
