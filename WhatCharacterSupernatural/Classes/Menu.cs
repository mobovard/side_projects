using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WhatCharacterSupernatural.Classes
{
    public static class Menu
    {
        static readonly string[] letters = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        public static void GreetUser()
        {
            Console.WriteLine("Welcome to the Supernatural Character Quiz!");
            Console.WriteLine("Press any key to begin the quiz:");
            Console.ReadLine();
        }

        public static void EndQuiz(string winningCharacter, string characterReport)
        {
            Console.WriteLine($"Thanks for playing, your character is: {winningCharacter}!");
            Console.WriteLine();
            Console.WriteLine("Would you like to store your results? (Y/N):");
            string userinput = Console.ReadLine().ToUpper();

            //A loop for checking that the user wrote Y/N
            bool userInputValid = false;
            while (userInputValid != true)
            {
                if (userinput == "Y")
                {
                    userInputValid = true;
                    //A loop for checking that the user wrote a valid path
                    bool fileWrittenSuccesfully = false;
                    while (fileWrittenSuccesfully != true)
                    {
                        Console.WriteLine("What would you like your file path to be?");
                        string userFilepath = Console.ReadLine();
                        try
                        {
                            //Stream writer to write out the character results
                            using (StreamWriter streamWriter = new StreamWriter(userFilepath))
                            {
                                streamWriter.WriteLine("Supernatural Character Quiz Results:");
                                streamWriter.Write(characterReport);
                            }
                            fileWrittenSuccesfully = true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Path invalid, please try again");
                        }
                    }
                }
                else if (userinput == "N")
                {
                    userInputValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection");
                }
            }
        }
        public static int AskQuestion(QuestionandAnswers questionandAnswers, int questionNumber)
        {
            Console.Clear();

            //Loop for making sure the user response is valid
            bool userAnswerValid = false;
            int userInputIndex = -1;
            while (userAnswerValid == false)
            {
                Console.WriteLine($"Question {questionNumber}:");
                Console.WriteLine();
                //Prints out the question and the possible answers
                Console.WriteLine(questionandAnswers.ToString());
                // Capture the user response
                string userInput = Console.ReadLine().ToUpper();

                userInputIndex = LetterToIndex(userInput);

                // Checks to make sure the user input is correct 
                if (userInputIndex < 0 || userInputIndex > questionandAnswers.Answers.Count)
                {
                    Console.WriteLine("Was that a typo? Please choose a valid answer.");
                    Console.ReadLine();
                }
                else
                {
                    userAnswerValid = true;
                }
            }

            return userInputIndex;

        }
        //To convert the user answer letter to the numbers used in the answer key. ex Q1A1
        public static int LetterToIndex(string letter)
        {
            //Default return of -1, means we didn't find the string
            int index = -1;
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == letter)
                {
                    index = i + 1;
                }
            }
            return index;
        }
    }
}
