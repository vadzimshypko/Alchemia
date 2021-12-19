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

        public bool AreFieldsSet()
        {
            return !(input1.Equals("") || input1 == null) &&
                !(input2.Equals("") || input2 == null) &&
                !(output.Count == 0 || output == null);
            
        }


    }
}
