using System;
using System.Collections.Generic;

namespace Task26_2.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public int? ClinicId { get; set; }

    public virtual Clinicc? Clinic { get; set; }
}
