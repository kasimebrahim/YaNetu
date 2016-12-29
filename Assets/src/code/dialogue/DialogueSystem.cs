using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Assets.src.dialogue
{
    class DialogueSystem
    {
        private string[] introductionScripts = null;
        private string[] learningScripts = null;
        private string[] testingScripts = null;

        public DialogueSystem()
        {
            loadScripts();
        }

        /*
         * Read Script files
         */
        public void loadScripts()
        {
            try
            {
                introductionScripts = System.IO.File.ReadAllLines("Assets/Data/introductionScripts.txt");
                learningScripts = System.IO.File.ReadAllLines("Assets/Data/learnScripts.txt");
                testingScripts = System.IO.File.ReadAllLines("Assets/Data/testScripts.txt");
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
        }

        /*
         * sanitize the introduction's script and return the script.
         */
        public ArrayList getIntroductionScripts()
        {
            return sanitizeScripts(introductionScripts);
            
        }

        /*
         * sanitize the learning's script and return the script.
         */
        public ArrayList getLearningScripts()
        {
            return sanitizeScripts(learningScripts);
        }

        /*
         * sanitize the testing's script and return the script.
         */
        public ArrayList getTestingScripts()
        {
            return sanitizeScripts(testingScripts);
        }

        /*
         * extract  only learner's name from the learner input 
         */
        public string getName(string input)
        {
            string value = input;
            ArrayList optionScripts = getOptionScripts(introductionScripts);
            string[] nameOption = (string[])optionScripts[0];
            for (int i = 0; i < nameOption.Length; i++)
            {
                if (value.Contains(nameOption[i].ToString().Trim()))
                {
                    value = input.Replace(nameOption[i].ToString().Trim(), " ").Trim();
                }
            }
            return value;
        }

        /*
         * extract only learner's age from the learner input 
         */
        public string getAge(string input)
        {
            string value = input;
            ArrayList optionScripts = getOptionScripts(introductionScripts);
            string[] ageOption = (string[])optionScripts[1];
            for (int i = 0; i < ageOption.Length; i++)
            {
                Console.WriteLine(ageOption[i]);
                if (value.Contains(ageOption[i].ToString().Trim().Trim().Trim().Trim()))
                {
                    value = value.Replace(ageOption[i].ToString().Trim(), " ").Trim();
                }
            }
            return value;
        }

        /*
         * extract  only the specific number's name from the learner input in learning scene. 
         */
        public string getNumberName(string input)
        {
            string value = input;
            ArrayList optionScripts = getOptionScripts(learningScripts);
            string[] numberNameOption = (string[])optionScripts[0];
            for (int i = 0; i < numberNameOption.Length; i++)
            {
                if (input.Contains(numberNameOption[i].ToString().Trim()))
                {
                    return numberNameOption[i].ToString().Trim();
                }
            }
            return null;
        }

        /*
         * sanitize the loaded scripts, remove the option scripts. 
         */
        private ArrayList sanitizeScripts(string[] allScripts)
        {
            ArrayList scripts = new ArrayList();
            for (int i = 0; i < allScripts.Length; i++)
            {
                if (!allScripts[i].Contains("("))
                {
                    scripts.Add(allScripts[i].Trim());
                }
            }
            return scripts;
        }

        /*
         * extract the option scripts 
         */
        private ArrayList getOptionScripts(string[] allScripts)
        {
            ArrayList scripts = new ArrayList();
            for (int i = 0; i < allScripts.Length; i++)
            {
                if (allScripts[i].Contains("("))
                {
                    string[] eachOption = (allScripts[i].Replace("(", "").Replace(")", "")).Trim().Split('/');
                    scripts.Add(eachOption);
                }
            }
            return scripts;
        }

    }
}