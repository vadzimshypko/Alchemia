using System.Collections.Generic;
namespace DataValidation
{
    public class InputCombination
    {
        public string input1;
        public string input2;
        public List<string> output;

        public override string ToString()
        {
            string outputSring = "";
            foreach (object element in output)
            {
                outputSring += element + ",";
            }
            return "input1:" + input1 + ";input2:" + input2 + ";output:" + outputSring;
        }


    }
}
