using System;

namespace Test.App
{
    internal class QuestionPosted
    {
        public QuestionPosted(Guid questionTitle, string description)
        {
            QuestionTitle = questionTitle;
            Description = description;
        }

        public object QuestionTitle { get; internal set; }
        public object Description { get; internal set; }
    }
}