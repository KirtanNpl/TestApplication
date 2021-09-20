using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Enum
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male = 1,
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Other")]
        Other
    }
}
