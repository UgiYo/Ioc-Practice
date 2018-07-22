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
            #region CASE1
            //InputAccept accept = new InputAccept();
            //accept.Inject(new PromptDataProcessor());
            //accept.Execute();
            //Console.Read();
            #endregion

            #region CASE2
            Container.RegisterImplement(typeof(InputAccept));
            Container.RegisterImplement(typeof(IDataProcessor), new PromptDataProcessor());
            InputAccept accept = (InputAccept)Container.GetInstance(typeof(InputAccept));
            accept.Execute();
            Console.Read();
            #endregion
        }
    }

    public class InputAccept
    {
        private IDataProcessor _dataProcessor;

        #region CASE1 interface DI
        //public void Inject(IDataProcessor dataProcessor)
        //{
        //    _dataProcessor = dataProcessor;
        //}
        #endregion

        #region CASE2 constructor DI
        //public InputAccept(IDataProcessor dataProcessor)
        //{
        //    _dataProcessor = dataProcessor;
        //}
        #endregion

        #region CASE3 setter DI
        public IDataProcessor DataProcessor
        {
            get
            {
                return _dataProcessor;
            }
            set
            {
                _dataProcessor = value;
            }
        }
        #endregion

        public void Execute()
        {
            Console.Write("Please Input some words:");
            string input = Console.ReadLine();
            input = _dataProcessor.ProcessData(input);
            Console.WriteLine(input);
        }
    }
}
