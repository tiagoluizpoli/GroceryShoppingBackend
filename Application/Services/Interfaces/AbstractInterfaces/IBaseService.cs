using Contracts.BaseContracts;
using ErrorOr;

namespace Application.Services.Interfaces.AbstractInterfaces;

public interface IBaseService<ResponseContractType, ResponseSummaryContract> where ResponseContractType : class
    where ResponseSummaryContract : class
{
    Task<ErrorOr<ResponseContractType>> GetById(Guid id);
    Task<ErrorOr<BaseNoContentResonseContract>> Delete(Guid Id);
}