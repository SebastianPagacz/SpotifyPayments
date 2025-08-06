namespace SpotifyPayment.Domain.Exceptions;

public class AmountPaidException : Exception
{
    public AmountPaidException() : base() { }
    public AmountPaidException(string message) : base(message) { }
    public AmountPaidException(string message, Exception innerException) : base(message, innerException) { }
}
