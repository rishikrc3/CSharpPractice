using DefaultNamespace;
class Program
{
    public static void Main(string[] args)
    {
        Report report = new Report();
        ReportPrinter printer = new ReportPrinter();
        printer.Print(report);
    }
}