using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
 
namespace DataValidation
{
    public class DataValidator
    {
        private List<InputElement> elements;
        private List<InputCombination> combinations;

        private bool validationSuccess = true;
        //todo store indexes instead of elements
        private List<InputElement> nonUniqueElements;
        private List<Tuple<InputCombination, string>> impossibleCombinations;
        private List<InputElement> noImageElements;
        public DataValidator()
        {
            //todo meesage in case json format is incorrect
            //todo message if some fields are missing or empty
            Console.WriteLine("Reading input files");
            LoadJsonElements();
            Console.WriteLine("Total elements read: " + elements.Count);
            LoadJsonCombinations();
            Console.WriteLine("Total combinations read: " + combinations.Count);
        }

        public void run()
        {
            Console.WriteLine("Run validator");
            //---
            Console.WriteLine("CheckElementsAreUnique...");
            nonUniqueElements = CheckElementsAreUnique();
            validationSuccess &= (nonUniqueElements.Count == 0);
            //-----
            Console.WriteLine("CheckCombinationElementsExist...");
            impossibleCombinations = CheckCombinationElementsExist();
            validationSuccess &= (impossibleCombinations.Count == 0);
            //-----
            //todo check that images files from element json exists
            Console.WriteLine("checkElementImagesExist...");
            noImageElements = checkElementImagesExist();
            validationSuccess &= (noImageElements.Count == 0);
            //todo check if all combinations are reachable 
            //----
            report();

        }

        //todo put input file names into the config class
        public void LoadJsonElements()
        {
            using (StreamReader r = new StreamReader("input/elements.json"))
            {
                string json = r.ReadToEnd();
                elements = JsonConvert.DeserializeObject<List<InputElement>>(json);
            }
        }

        public void LoadJsonCombinations()
        {
            using (StreamReader r = new StreamReader("input/combinations.json"))
            {
                string json = r.ReadToEnd();
                combinations = JsonConvert.DeserializeObject<List<InputCombination>>(json);

            }
        }

        //todo remake into 1 method using List<Object> and explicite type cast
        private static void printElementsList(List<InputElement> list)
        {
            foreach (InputElement el in list)
            {
                Console.WriteLine(el.ToString());
            }
        }

        private void printCombinationsList(List<InputCombination> list)
        {
            foreach (var comb in list)
            {
                Console.WriteLine(comb.ToString());
            }
        }

        private void printCombinationsErrors(List<Tuple<InputCombination, string>> list)
        {
            foreach (Tuple<InputCombination, string> comb_error in list)
            {
                Console.WriteLine("-Combination: ");
                Console.WriteLine(comb_error.Item1);
                Console.WriteLine("Missing elements: ");
                Console.WriteLine(comb_error.Item2);
            }
        }

        public List<InputElement> CheckElementsAreUnique()
        {
            List<InputElement> errors = new List<InputElement>();
            HashSet<string> id_names = new();
            foreach (InputElement element in elements)
            {
                if (id_names.Contains(element.id_name))
                {
                    errors.Add(element);
                }
                else
                {
                    id_names.Add(element.id_name);
                }
            }
            return errors;
        }

        public List<Tuple<InputCombination, string>> CheckCombinationElementsExist()
        {
            List<Tuple<InputCombination, string>> errors = new();
            HashSet<string> id_names = new();
            foreach (InputElement element in elements)
            {
                id_names.Add(element.id_name);
            }
            foreach (InputCombination comb in combinations)
            {
                bool failed = false;
                string missing_elements = "";
                {
                    if (!id_names.Contains(comb.input1))
                    {
                        failed = true;
                        missing_elements += comb.input1 + "; ";
                    }
                    if (!id_names.Contains(comb.input2))
                    {
                        failed = true;
                        missing_elements += comb.input1 + "; ";
                    }
                    foreach (string el in comb.output)
                    {
                        if (!id_names.Contains(el))
                        {
                            failed = true;
                            missing_elements += el + "; ";
                        }
                    }
                }
                if (failed)
                {
                    errors.Add(new Tuple<InputCombination, string>(comb, missing_elements));
                }
            }
            return errors;
        }

        public List<InputElement> checkElementImagesExist() 
        {
            List<InputElement> errors = new List<InputElement>();
            string relativeImagesPath = ConfigurationManager.AppSettings["imagesRelativePath"];
            foreach (InputElement element in elements)
            {
                if (!File.Exists(relativeImagesPath + "\\" + element.image))
                {
                    errors.Add(element); 
                }
            }
            return errors;
           
        }

        public void report()
        {
            //-----
            Console.WriteLine("Validation report");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Validation: CheckElementsAreUnique");
            if (nonUniqueElements.Count > 0)
            {
                Console.WriteLine("id_names are NOT unique");
                Console.WriteLine("Failed elements:");
                printElementsList(nonUniqueElements);
            }
            Console.WriteLine("Result of CheckElementsAreUnique: " +
                ((nonUniqueElements.Count < 0) ? "passed" : "false"));
            //-----
            //todo each block can be templated using object and type cast to print results
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Validation: CheckCombinationElementsExist");
            if (impossibleCombinations.Count > 0)
            {
                Console.WriteLine("Failed combinations:");
                printCombinationsErrors(impossibleCombinations);
            }
            Console.WriteLine("Result of CheckCombinationElementsExist: " +
                ((impossibleCombinations.Count < 0) ? "passed" : "false"));
            //-----
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Validation: checkElementImagesExist");
            if (noImageElements.Count > 0)
            {
                Console.WriteLine("Failed elements:");
                printElementsList(noImageElements);
            }
            Console.WriteLine("Result of checkElementImagesExist: " +
                ((noImageElements.Count < 0) ? "passed" : "false"));
            //-----
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("DataValidation result: " + (validationSuccess ? "passed" : "failed"));
        }
    }
}
