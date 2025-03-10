namespace Solution.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : SolutionException
    {
        public IList<string> ErrorsMessage { get; set; }

        public ErrorOnValidationException(IList<string> errors)
        {
            ErrorsMessage = errors;
        }
    }
}
