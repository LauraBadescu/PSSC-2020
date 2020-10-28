namespace Test.App
{
    internal class CreateQuestionCmd
    {
        private string v1;
        private string empty;
        private string v2;

        public CreateQuestionCmd(string v1, string empty, string v2)
        {
            this.v1 = v1;
            this.empty = empty;
            this.v2 = v2;
        }
    }
}