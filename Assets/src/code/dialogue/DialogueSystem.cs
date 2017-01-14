using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Assets.src.code.dialogue
{
    public class DialogueSystem
    {
        private string[] introductionScripts = null;
        private string[] learningScripts = null;
        private string[] testingScripts = null;
		public string error = "";
        public DialogueSystem()
        {
            
        }

        /*
         * Read Script files
         */
        public void loadScripts()
        {
			StringBuilder reader = null;
            try
			{
				
				UnityEngine.TextAsset introduction = (UnityEngine.TextAsset)UnityEngine.Resources.Load("introductionScripts", typeof(UnityEngine.TextAsset));
				UnityEngine.TextAsset learn = (UnityEngine.TextAsset)UnityEngine.Resources.Load("learnScripts", typeof(UnityEngine.TextAsset));
				UnityEngine.TextAsset test = (UnityEngine.TextAsset)UnityEngine.Resources.Load("testScripts", typeof(UnityEngine.TextAsset));
			    reader = new StringBuilder(introduction.text);
				introductionScripts = reader.ToString().Split('\n');
				reader = new StringBuilder(learn.text);
				learningScripts = reader.ToString().Split('\n');
				reader = new StringBuilder(test.text);
				testingScripts = reader.ToString().Split('\n');
						
            }
			catch (Exception ex) { error = ex.Message;
			}
        }

        /*
         * sanitize the introduction's script and return the script.
         */
        public ArrayList getIntroductionScripts()
        {
			loadScripts();
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