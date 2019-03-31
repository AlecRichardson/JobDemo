using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDemo
{
    class Job
    {
        protected double hours;
        protected double price;
        public const double RATE = 45.00;
        public Job(int num, string cust, string desc, double hrs)
        {
            //TODO:
            JobNumber = num;
            Customer = cust;
            Description = desc;
            Hours = hrs;
        }

        //TODO: auto implement property JobNumber, Customer, Description 
        public int JobNumber { get; set; }
        public String Customer { get; set; }
        public String Description { get; set; }

        //TODO: implment Hours, Price property. Consider to make Hours virtual for derived class to override
        public virtual double Hours
        {
            get => hours;
            set
            {
                hours = value;
                price = hours * RATE;
            }
        }
        public virtual float Price { get => (float)price; }


        public override string ToString()
        {
            return $"{GetType()} {JobNumber} {Customer} {Description} {hours} hours @ {RATE.ToString("C")} per hour. " +
                $"Total price is {price.ToString("C")}.";
        }

        public override bool Equals(Object e)
        {
            //TODO:
            if (e.Equals(JobNumber))
            {
                return true;
            }
            return false;

        }

        public override int GetHashCode()
        {
            //TODO:
            return JobNumber;
        }

    }

}
