using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Question
{
    class QuestionModel
    {
        public int Id { get; set; }
        public string Enonce { get; set; }
        public string BonneReponse { get; set; }
        public List<MauvaiseReponseModel> MauvaiseReponses { get; set; }

    }
}
