using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackAlleyClinic.Models
{
  public class Patient
  {
    public Patient()
    {
      this.JoinEntities = new HashSet<DoctorPatient>();
    }

    public int PatientId { get; set; }
    public string Name { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime BirthDate { get; set; }
    public virtual ICollection<DoctorPatient> JoinEntities { get; }
  }
}