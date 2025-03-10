namespace Solution.Communication.Responses
{
    public class ResponseErrorJson
    {
        public IList<string> ErrorsMsg { get; set; }

        public ResponseErrorJson(IList<string> Errors) => ErrorsMsg = Errors;

        public ResponseErrorJson(string Error)
        {
            ErrorsMsg = new List<string>() { Error };
        }
    }
}
