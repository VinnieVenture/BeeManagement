using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagement.Bees
{
    internal class Queen: Bee
    {
        private const float EGGS_PER_SHIFT = 0.45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        protected override float CostPerShift { get => 2.15f; }
        public string StatusReport { get; private set; }

        private Bee[] workers = new Bee[0];
        private float unassignedWorkers = 3;
        private float eggs = 0;

        public Queen() : base("Królowa")
        {
            AssignBee("Opiekunka jaj");
            AssignBee("Zbieraczka nektaru");
            AssignBee("Producentka miodu");
        }

        protected override void DoJob() {
            eggs += EGGS_PER_SHIFT;
            foreach(var worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
        }

        public void AssignBee(string beeType) {
            switch (beeType)
            {
                case "Opiekunka jaj":
                    AddWorker(new EggCare(this));
                    break; 
                case "Zbieraczka nektaru": 
                    AddWorker(new NectarCollector()); 
                    break; 
                case "Producentka miodu": 
                    AddWorker(new HoneyManufacturer()); 
                    break; 
                default:break;
            }
            UpdateStatusReport();
        }
        public void CareForEggs(float eggsForCare) {
            if (eggs >= eggsForCare) { 
                eggs -= eggsForCare;
                unassignedWorkers += eggsForCare;
            }
        }

        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        private void UpdateStatusReport() {
            StatusReport = HoneyVault.StatusReport + 
                $"Liczba jaj: {eggs:0.0}" +
                $"\nNieprzydzielone robotnice: {unassignedWorkers:0.0}" +
                WorkerStatus("Zbieraczka nektaru") +
                WorkerStatus("Producentka miodu") +
                WorkerStatus("Opiekunka jaj") +
                $"\nROBOTNICE W SUMIE: {workers.Length}";
        }

        private string WorkerStatus(string job)
        {
            var counter = 0;
            foreach (var worker in workers)
            {
                if (worker.Job == job) counter++;
            }
            return $"\n{job}: {counter}";
        }
    }
}
