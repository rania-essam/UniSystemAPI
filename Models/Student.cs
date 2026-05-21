using System;
using System.Collections.Generic;

namespace Web_API_DAY2;

public partial class Student
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

    public virtual ICollection<Student> InverseStSuperNavigation { get; set; } = new List<Student>();

    public virtual Student? StSuperNavigation { get; set; }

    public virtual ICollection<StudCourse> StudCourses { get; set; } = new List<StudCourse>();

    public virtual ICollection<Student2> Student2s { get; set; } = new List<Student2>();
}
