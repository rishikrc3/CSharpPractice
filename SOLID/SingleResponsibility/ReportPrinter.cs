using System;

namespace DefaultNamespace
{
    public class ReportPrinter
    {
        public void Print(Report report)
        {
            Console.WriteLine(report.Text);
        }
    }
}

