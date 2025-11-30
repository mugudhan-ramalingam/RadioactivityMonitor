using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactivityMonitor.Core
{
    public interface ISensor
    {
        double NextMeasure();
    }
}
