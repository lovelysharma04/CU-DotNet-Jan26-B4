using System;
using System.Collections.Generic;

namespace WebAPIdbFirst.Models;

public partial class Faculty
{
    public int Facultyid { get; set; }

    public string Facultyname { get; set; } = null!;

    public string? Subject { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
