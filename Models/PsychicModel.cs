﻿using System;
using System.Collections.Generic;

namespace PsychicsGame.Models
{
    public class PsychicModel
    {
        public string Name { get; set; }

        public int Validity { get; set; }

        public int Value { get; set; }

        Random random;

        public List<PsychicAnswerModel> PsychicValues = new List<PsychicAnswerModel>();

        /// <summary>
        /// Добавить догадку экстрасенса в список догадок
        /// </summary>
        /// <param name="value"></param>
        public void AddValue(PsychicAnswerModel value)
        {
            PsychicValues.Add(value);
        }

        public PsychicModel()
        {
            random = new Random();
        }

        public int GenerateRandomValue()
        {
            var value = random.Next(10, 99);
            return value;

        }
    }
}