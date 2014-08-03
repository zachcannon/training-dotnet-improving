using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgileTaskKeeper.Models
{
    public enum TaskStatus
    {
        [Display(Name = "Pending")]
        Pending = 0,

        [Display(Name = "Working")]
        Working,

        [Display(Name = "Finished")]
        Finished
    }
}