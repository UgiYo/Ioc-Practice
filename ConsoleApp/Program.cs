using ConsoleApp.Processor;
using ConsoleApp.Processor.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InputAccept accept = new InputAccept();
            accept.Inject(new PromptDataProcessor());
            accept.Execute();
            Console.Read();
        }
    }

    public class InputAccept
    {
        private IDataProcessor _dataProcessor;

        public void Inject(IDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        public void Execute()
        {
            Console.Write("Please Input some words:");
            string input = Console.ReadLine();
            input = _dataProcessor.ProcessData(input);
            Console.WriteLine(input);
        }
    }
}
