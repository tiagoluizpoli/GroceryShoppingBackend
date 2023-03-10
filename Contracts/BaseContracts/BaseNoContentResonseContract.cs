namespace Contracts.BaseContracts;

public class BaseNoContentResonseContract
{
    public BaseNoContentResonseContract(string message)
    {
        Message = message;
    }

    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public string Message { get; set; }
}