using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagement.Bees
{
    internal class HoneyManufacturer : Bee
    {
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15F;
        public HoneyManufacturer() : base("Producentka miodu")
        {
        }

        protected override float CostPerShift { get => 1.7f; }
        protected override void DoJob() {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
