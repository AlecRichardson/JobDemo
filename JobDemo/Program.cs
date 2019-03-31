using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JobDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Job[] jobs = new Job[3]; //Create an array of three Jobs. Don’t change this statement. 
            Program p = new Program();
            //TODO: take user input, construct Job or RushJob object, and save it to the Job array declared above. 
            for (int i = 0; i < jobs.Count(); i++)
            {
                jobs[i] = p.createJob(jobs);
            }
            //TODO: Use the jobs array, display all jobs information
            p.printJobs(jobs);
        }

        private Job createJob(Job[] jobs)
        {
            bool rushJob = validateJobType();
            int jobNumber = validateJobNumber(jobs);
            string custName = validateInputAsString("customer name");
            string jobDesc = validateInputAsString("job description");
            double hours = validateInputAsDouble("estimated hours");
            Console.WriteLine("\nJob created succesfully.\n\n");

            if (rushJob) return new RushJob(jobNumber, custName, jobDesc, hours);
            
            return new Job(jobNumber, custName, jobDesc, hours);
        }

        private void printJobs(Job[] jobs)
        {
            double total = 0;

            Console.WriteLine("Summary:\n\n");

            foreach (Job job in jobs)
            {
                Console.WriteLine($"{job}\n");
                total += job.Price;
            }

            Console.WriteLine($"\nTotal for all jobs is ${total}");
        }

        private bool validateJobType()
        {
            Console.Write("Rush Job (y/n)? ");
            string value = Console.ReadLine().ToLower();

            if (!string.Equals(value, "n") && !string.Equals(value, "y"))
            {
                Console.WriteLine("Enter 'y' or 'n', please try again.");
                validateJobType();
            }

            if (string.Equals(value, "y")) return true;

            return false;
        }

        private int validateJobNumber(Job[] jobs)
        {
            int jobNumber = validateInputAsInt("job number");
            foreach (Job job in jobs)
            {
                while (job != null && job.JobNumber == jobNumber)
                {
                    Console.WriteLine("Job number already exists, please try again.");
                    jobNumber = validateInputAsInt("job number");
                }
            }
            
            return jobNumber;
        }

        private string validateInputAsString(string inputName)
        {
            Console.Write($"Enter {inputName}: ");
            string value = Console.ReadLine();

            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Input cannot be empty, please try again.");
                validateInputAsString(inputName);
            }

            return value;
        }

        private int validateInputAsInt(string inputName)
        {
            int value;
            Console.Write($"Enter {inputName}: ");

            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Input must be an integer, please try again.");
                validateInputAsInt(inputName);
            }

            return value;
        }

        private double validateInputAsDouble(string inputName)
        {
            double value;
            Console.Write($"Enter {inputName}: ");

            if (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Input must be an number, please try again.");
                validateInputAsDouble(inputName);
            }

            return value;
        }
    }
}
