using System;
using System.Collections.Generic;

namespace studyAPI.Models;

public partial class CourseDetail
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? Mentor { get; set; }

    public string? Duration { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
