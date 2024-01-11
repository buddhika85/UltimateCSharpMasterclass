namespace OtherTests.CustomExceptionTesting
{
    public class InvalidTransactionException : Exception
    {
        public TransactionData TransactionData { get; }

        // constructors to match with parent exception constructors 
        public InvalidTransactionException() : base() { }
        public InvalidTransactionException(string message) : base(message) { }
        public InvalidTransactionException(string message, Exception innerException) : base(message, innerException) { }

        // two extra
        // One setting the message and the TransactionData and
        public InvalidTransactionException(string message, TransactionData transactionData) : base(message)
        {
            TransactionData = transactionData;
        }
        // one setting the message, TransactionData and InnerException(keep the parameters of the constructors in the given order)
        public InvalidTransactionException(string message, TransactionData transactionData, Exception innerException) : base(message, innerException)
        {
            TransactionData = transactionData;
        }
    }


    public class TransactionData
    {
        public string Sender { get; init; }
        public string Receiver { get; init; }
        public decimal Amount { get; init; }
    }
}
