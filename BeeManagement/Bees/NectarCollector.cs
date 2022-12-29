using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagement.Bees
{
    internal class NectarCollector: Bee
    {
        private const float NECTAR_COLLECTER_PER_SHIFT = 33.25f;
        public NectarCollector() : base("Zbieraczka nektaru")
        {
        }

        protected override float CostPerShift { get => 1.95f; }
        protected override void DoJob() {
            HoneyVault.CollectNectar(NECTAR_COLLECTER_PER_SHIFT);
        }
    }
}
