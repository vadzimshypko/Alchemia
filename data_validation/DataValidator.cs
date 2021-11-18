using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DataValidation
{
    class DataValidator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LoadJsonElements();
            LoadJsonCombinations();
          
        }

        public static void LoadJsonElements()
        {
            using (StreamReader r = new StreamReader("input/elements.json")) 
            {
                string json = r.ReadToEnd();
                List<InputElement> elements = JsonConvert.DeserializeObject<List<InputElement>>(json);

                foreach (object el in elements)
                {
                    Console.WriteLine(el.ToString());
                }
            }
        }

        public static void LoadJsonCombinations()
        {
            using (StreamReader r = new StreamReader("input/combinations.json"))
            {
                string json = r.ReadToEnd();
                List<InputCombination> combinations = JsonConvert.DeserializeObject<List<InputCombination>>(json);

                foreach (object  comb in combinations)
                {
                    Console.WriteLine(comb.ToString());
                }
            }
        }

    }

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
