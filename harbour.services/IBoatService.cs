using System.Collections.Generic;
using harbour.model__views;

namespace harbour.services
{
    public interface IBoatService
    {
        ResponseViewModel<List<TransactionViewModel>> SchedulingEngine();
        ResponseViewModel<List<TransactionViewModel>> GetAllTransactions();
    }
}