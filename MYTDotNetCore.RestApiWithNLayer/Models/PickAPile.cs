namespace MYTDotNetCore.RestApiWithNLayer.Models
{
    public class PickAPile
    {
        public class MainDto
        {
            public Question[] Questions { get; set; }
            public Answer[] Answers { get; set; }
        }

        public class Question
        {
            public int QuestionId { get; set; }
            public string QuestionName { get; set; }
            public string QuestionDesp { get; set; }
        }

        public class Answer
        {
            public int AnswerId { get; set; }
            public string AnswerImageUrl { get; set; }
            public string AnswerName { get; set; }
            public string AnswerDesp { get; set; }
            public int QuestionId { get; set; }
        }

    }
}
