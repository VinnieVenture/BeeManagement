using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagement.Bees
{
    internal class EggCare : Bee
    {
        Queen queen;
        private const float CARE_PROGRESS_PER_SHIFT = 0.15f; 
        public EggCare(Queen queen) : base("Opiekunka jaj")
        {
            this.queen = queen;
        }

        protected override float CostPerShift { get => 1.35f; }
        protected override void DoJob() {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
