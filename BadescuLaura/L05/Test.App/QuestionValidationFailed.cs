using System.Collections.Generic;

namespace Test.App
{
    internal class QuestionValidationFailed
    {
        private List<string> errors;

        public QuestionValidationFailed(List<string> errors)
        {
            this.errors = errors;
        }

        public IEnumerable<object> ValidationErrors { get; internal set; }
    }
}