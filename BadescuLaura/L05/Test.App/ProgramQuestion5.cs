using System;
using System.Collections.Generic;

namespace Test.App
{
    class ProgramQuestion5
    {
        public static object UnpostedQuestion { get; private set; }

        static void Main(string[] args)
        {
            var questionResult = UnpostedQuestion.Create("How to make a console application c#?", new List<string>() { "console", "neu" });


            questionResult.Match(
                    Succ: question =>
                    {
                        VoteQuestion(question);
                        Console.WriteLine("Vote");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Question couldn't be posted. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );
            Console.ReadLine();
        }
        private static void VoteQuestion(UnpostedQuestion question)
        {
            var publishedQuestionResult = new PublishQuestionService().PublishQuestion(question);
            publishedQuestionResult.Match(
                    QuestionVote =>
                    {
                        new VoteQuestionService().SendPermisiuneToVote(QuestionVote);
                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("Can't vote");
                        return Unit.Default;
                    }
                );
        }

    }
}
