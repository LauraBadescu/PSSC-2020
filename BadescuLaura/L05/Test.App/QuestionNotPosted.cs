namespace Test.App
{
    internal class QuestionNotPosted
    {
        private string v;

        public QuestionNotPosted(string v)
        {
            this.v = v;
        }

        public object Reason { get; internal set; }
    }
}