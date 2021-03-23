using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WhatCharacterSupernatural.Classes
{
    public class Quiz
    {
        //Reads input file of questions and possible answers into a list
        public List<QuestionandAnswers> Questions = FileHelper.ReadInputQuestions();

        //Reads input answer key file to store which answers give points to which characters
        public Dictionary<string, List<string>> answerKey = FileHelper.ReadInputAnswers();

        public User user = new User();

        public void QuizLoop()
        {
            Menu.GreetUser();

            //For each question
            for (int i = 0; i < Questions.Count; i++)
            {
                //Use menu to ask question and save user response
                int userResponse = Menu.AskQuestion(Questions[i], i + 1);

                //Retrieve the answer key value for the response
                string responseKey = $"Q{i + 1}A{userResponse} ";
                List<string> charactersToAddPoints = answerKey[responseKey];

                //Add points to the characters for the user
                user.AddPoints(charactersToAddPoints);

            }
            Menu.EndQuiz(user.HighestPointCharacter(), user.CharacterReport());
        }
    }
}
