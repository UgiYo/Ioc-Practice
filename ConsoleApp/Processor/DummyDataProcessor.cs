using ConsoleApp.Processor.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Processor
{
    class DummyDataProcessor: IDataProcessor
    {
        #region IDataProcessor Members

        public string ProcessData(string input)
        {
            return input;
        }

        #endregion
    }

    public class PromptDataProcessor : IDataProcessor
    {
        #region IDataProcessor Members

        public string ProcessData(string input)
        {
            return "your input is: " + input;
        }

        #endregion
    }
}
