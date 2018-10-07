using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestipsSignalFunctions.Models
{
    public class SignalContext : DbContext
    {
        public virtual DbSet<Signal> Signals { get; set; }
    }
}
