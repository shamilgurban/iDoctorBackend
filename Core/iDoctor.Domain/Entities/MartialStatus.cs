using iDoctor.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Domain.Entities
{
    public class MaritalStatus:BaseEntity
    {
        public string Status { get; set; }
        public List<Patient> Patients { get; set; }

    }
}
