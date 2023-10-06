using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker.Models;

public class TimeLogModel
{
    public int Id { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
}
