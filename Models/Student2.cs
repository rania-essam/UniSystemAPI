using System;
using System.Collections.Generic;

namespace Web_API_DAY2;

public partial class Student2
{
    public int StId { get; set; }

    public string? StFname { get; set; }

    public string? StLname { get; set; }

    public string? StAddress { get; set; }

    public int? StAge { get; set; }

    public int? DeptId { get; set; }

    public int? StSuper { get; set; }

    public int NewId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Student? StSuperNavigation { get; set; }
}
