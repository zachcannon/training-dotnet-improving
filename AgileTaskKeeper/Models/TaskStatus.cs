using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgileTaskKeeper.Models
{
    public enum TaskStatus
    {
        Pending = 0, 
        Working = 1, 
        Finished = 2
    }
}