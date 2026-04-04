using System;
using System.Collections.Generic;

namespace WebAPIdbFirst.Models;

public partial class Student
{
    public int Studentid { get; set; }

    public string Studentname { get; set; } = null!;

    public string? Class { get; set; }

    public int? Fid { get; set; }

    public virtual Faculty? FidNavigation { get; set; }
}
