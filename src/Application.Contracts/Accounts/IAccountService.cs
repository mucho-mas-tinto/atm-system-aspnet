using AtmSystem.Application.Contracts.Accounts.Operations;

namespace AtmSystem.Application.Contracts.Accounts;

public interface IAccountService
{
    DepositMoney.Response DepositMoney(DepositMoney.Request request);

    WithdrawMoney.Response WithdrawMoney(WithdrawMoney.Request request);

    CheckAccountBalance.Response CheckAccountBalance(CheckAccountBalance.Request request);

    GetOperationHistories.Response GetOperationHistories(GetOperationHistories.Request request);
}