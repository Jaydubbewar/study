using System;
using System.Collections.Generic;

namespace studyAPI.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? PhoneNumber { get; set; }

    public int? CourseId { get; set; }

    public virtual CourseDetail? Course { get; set; }
}
