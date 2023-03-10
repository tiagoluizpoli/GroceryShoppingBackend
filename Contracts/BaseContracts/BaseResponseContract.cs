namespace Contracts.BaseContracts;

public abstract class BaseResponseContract
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}