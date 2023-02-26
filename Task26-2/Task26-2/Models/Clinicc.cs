using System;
using System.Collections.Generic;

namespace Task26_2.Models;

public partial class Clinicc
{
    public int ClinicId { get; set; }

    public string? ClinicName { get; set; }

    public string? Clinicimg { get; set; }

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();
}
