using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagement.Bees
{
    internal abstract class Bee
    {
        public string Job { get; }
        protected abstract float CostPerShift { get; }

        public Bee(string job) {
            this.Job = job;
        }
        public void WorkTheNextShift() {
            if (HoneyVault.ConsumeHoney(CostPerShift))
                DoJob();
        }

        protected abstract void DoJob();
    }
}
