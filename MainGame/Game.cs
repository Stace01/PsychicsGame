﻿using System;
using System.Collections.Generic;
using PsychicsGame.DataService;
using PsychicsGame.Models;

namespace PsychicsGame.MainGame
{
    public class Game
    {
        private PsychicModel psychicModel = new PsychicModel();

        private PsychicsService service = new PsychicsService();

        private List<PsychicModel> psychics = new List<PsychicModel>();

        private List<UserAnswerModel> userValue = new List<UserAnswerModel>();

        public void StartGame()
        {
            if (psychics.Count == 0)
            {
                psychics = service.GetNewPsychics();
            }

            foreach (var psychic in psychics)
            {
                var answer = new PsychicAnswerModel
                {
                    Value = psychicModel.GetRandomValue()
                };
                psychic.AddValue(answer);
                psychic.Value = answer.Value;
            }
        }

        public void AnswerСheck(int userNumber)
        {
            userValue.Add(new UserAnswerModel { Value = userNumber });

            foreach (var psychic in psychics)
            {
                if (psychic.Value == userNumber)
                {
                    psychic.Validity += 10;
                }
                else
                    psychic.Validity -= 10;
            }
        }

       public IReadOnlyList<PsychicModel> Psychics
        {
            get
            {
                return psychics.AsReadOnly();
            }
        }

        public IReadOnlyList<UserAnswerModel> UserValue
        {
            get
            {
                return userValue.AsReadOnly();
            }
        }
    }
}