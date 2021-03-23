using System;
using System.Collections.Generic;
using System.Text;

namespace WhatCharacterSupernatural
{
    public class User
    {
        public Dictionary<string, int> CharacterPoints;

        public static Dictionary<string, string> CharacterFullNames = new Dictionary<string, string>
        {
            {"D", "Dean Winchester"},
            {"S", "Sam Winchester"},
            {"B", "Bobby Singer"},
            {"L", "Lucifer"},
            {"F", "Crowley"},
            {"C", "Castiel"}
        };


        public int TotalPointsEarned;

        public User()
        {
            CharacterPoints = new Dictionary<string, int>
            {
                {"D", 0},
                {"S", 0},
                {"B", 0},
                {"L", 0},
                {"F", 0},
                {"C", 0}
            };

            TotalPointsEarned = 0;

        }

        public void AddPoints(List<string> charactersToAddPoints)
        {
            //loops through list of characters in answer key to add points to and is stored in the points dictionary
            for (int i = 0; i < charactersToAddPoints.Count; i++)
            {
                CharacterPoints[charactersToAddPoints[i].Trim()] += 1;
                TotalPointsEarned +=  1;
            }
        }

        public string HighestPointCharacter()
        {
            string returnCharacter = "";
            int highestPoints = 0;

            foreach (KeyValuePair<string, int> kvp in CharacterPoints)
            {
                if (kvp.Value > highestPoints)
                {
                    highestPoints = kvp.Value;
                    returnCharacter = kvp.Key;
                }
            }

            return CharacterFullNames[returnCharacter];
        }

        public string CharacterReport()
        {
            string returnMessage = "";

            foreach (KeyValuePair<string, int> kvp in CharacterPoints)
            {

                string characterName = CharacterFullNames[kvp.Key];
                decimal characterPercent = (decimal) kvp.Value / (decimal) TotalPointsEarned;
                returnMessage += $"{characterName} : {(Math.Round(characterPercent*100, 2))}% \n";

            }

            return returnMessage;
        }
    }


}
