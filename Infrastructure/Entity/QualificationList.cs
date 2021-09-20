using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class QualificationList
    {
        [Key]
        public long Id { get; set; }

         public string Q_Name { get; set; }
    }
}
