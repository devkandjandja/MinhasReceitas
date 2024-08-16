namespace MinhasReceitas.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : MinhasReceitasException
    {
        public IList<string> ErrorMessages { get; set; }
        public ErrorOnValidationException(IList<string> errorMessages)
        {

            ErrorMessages = errorMessages;

        }
    }
}
