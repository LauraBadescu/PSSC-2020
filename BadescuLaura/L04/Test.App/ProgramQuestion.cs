using System;
using System.Collections.Generic;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            var cmd = new CreateQuestionCmd("titlu intrebare", string.Empty, "continutul intrebarii");
            var result = CreateQuestion(cmd);

            var createQuestionEvent = result.Match(ProcessQuetionPosted, ProcessQuestionNotPosted, ProcessInvalidQuestion);

            Console.ReadLine();
        }

        private static object CreateQuestion(CreateQuestionCmd cmd)
        {
            throw new NotImplementedException();
        }

        private static ICreateQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return (ICreateQuestionResult)validationErrors;
        }

        private static ICreateQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotPosted)
        {
            Console.WriteLine($"Question wasn't posted: {questionNotPosted.Reason}");
            return (ICreateQuestionResult)questionNotPosted;
        }

        private static ICreateQuestionResult ProcessQuetionPosted(QuestionPosted new_question)
        {
            Console.WriteLine($"Question {new_question.QuestionTitle}");
            Console.WriteLine($"Description {new_question.Description}");
            return (ICreateQuestionResult)new_question;
        }

        public static ICreateQuestionResult CreateNewQuestion(CreateNewQuestionCmd createQuestion)
        {
            if (string.IsNullOrWhiteSpace(createQuestion.Description))
            {
                var errors = new List<string>() { "Your question wasn't passed " };
                return new QuestionValidationFailed(errors);
            }

            if (string.IsNullOrEmpty(createQuestion.Title))
            {
                return new QuestionNotPosted("Question couldn't be verified");
            }

            var questionTitle = Guid.NewGuid();
            var result = new QuestionPosted(questionTitle, createQuestion.Description);

            return (ICreateQuestionResult)result;
        }

        internal class Domain
        {
            internal class CreateQuestionWorkflow
            {
                internal class CreateQuestionResult
                {
                }
            }
        }
    }
}

