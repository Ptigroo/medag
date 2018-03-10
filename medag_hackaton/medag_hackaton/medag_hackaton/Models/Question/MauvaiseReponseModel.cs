using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Question
{
    class MauvaiseReponseModel
    {
        public int Id { get; set; }
        public string Reponse { get; set; }
        public int QuestionId { get; set; }
    }
}
