using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WhatCharacterSupernatural.Classes
{
    public static class FileHelper
    {
        const string questionsFilePath = @"C:\Users\Student\workspace\Side projects\Files\InputQuestions.txt";
        const string answersFilePath = @"C:\Users\Student\workspace\Side projects\Files\InputAnswers.txt";
        public static List<QuestionandAnswers> ReadInputQuestions()
        {
            List<QuestionandAnswers> questions = new List<QuestionandAnswers>();

            try
            {
                using (StreamReader sr = new StreamReader(questionsFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line != "")
                        {
                            string[] lineArray = line.Split("| ");
                            List<string> answerList = new List<string>();
                            string questionText = lineArray[0];

                            for (int i = 1; i < lineArray.Length; i++)
                            {
                                answerList.Add(lineArray[i]);
                            }

                            QuestionandAnswers qAndA = new QuestionandAnswers(questionText, answerList);
                            questions.Add(qAndA);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return questions;
        }
        public static Dictionary<string, List<string>> ReadInputAnswers()
        {
            Dictionary<string, List<string>> AnswerKey = new Dictionary<string, List<string>>();

            try
            {
                using (StreamReader sr = new StreamReader(answersFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line != "")
                        {
                            string[] lineArray = line.Split("|");
                            List<string> answerList = new List<string>();
                            string questionAnswerIndex = lineArray[0];

                            for (int i = 1; i < lineArray.Length; i++)
                            {
                                answerList.Add(lineArray[i]);
                            }

                            AnswerKey.Add(questionAnswerIndex, answerList);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return AnswerKey;
        }
    }
}


