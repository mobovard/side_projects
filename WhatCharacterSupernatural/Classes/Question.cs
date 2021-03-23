using System;
using System.Collections.Generic;
using System.Text;

namespace WhatCharacterSupernatural
{
    public class QuestionandAnswers
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }

        public QuestionandAnswers (string question, List<string> answers)
        {
            Question = question;
            Answers = answers;
        }

        public override string ToString()
        {
            string returnString = "";
            returnString += Question + "\n" + "\n";
            for (int i = 0; i < Answers.Count; i++)
            {
                string character = "";
                if ( i == 0)
                {
                    character = "A";
                }
                else if (i == 1)
                {
                    character = "B";
                }
                else if (i == 2)
                {
                    character = "C";
                }
                else if (i == 3)
                {
                    character = "D";
                }
                else if (i == 4)
                {
                    character = "E";
                }
                else if (i == 5)
                {
                    character = "F";
                }
                else
                {
                    throw new Exception();
                }
                returnString += $"{character}: {Answers[i]} \n";
            }
            return returnString;
        }
    }

}
