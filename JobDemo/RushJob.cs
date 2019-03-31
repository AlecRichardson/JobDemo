using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDemo
{
    class RushJob : Job
    {
        public const double PREMIUM = 150.00;

        //TODO: Constructor with no parameters: public RushJob() 
        public RushJob(int num, string cust, string desc, double hrs) : base(num, cust, desc, hrs) { }



        //TODO: update Hour property with new price calculation: price = hours * RATE + PREMIUM;
        public override double Hours
        {
            get => base.Hours;
            set
            {
                hours = value;
                price = hours * RATE + PREMIUM;
            }
        }

        public override string ToString()
        {
            //TODO:
            return $"{GetType()} {JobNumber} {Customer} {Description} {hours} hours @ {RATE.ToString("C")} per hour. " +
                $"Rush job adds 150 premium. Total price is {price.ToString("C")}.";

        }
    }
}
