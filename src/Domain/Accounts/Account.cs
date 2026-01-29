using AtmSystem.Domain.Accounts.PinCodes;
using AtmSystem.Domain.Operations.Results;
using AtmSystem.Domain.Operations.Types;
using AtmSystem.Domain.ValueObjects;

namespace AtmSystem.Domain.Accounts;

public class Account
{
    public AccountId AccountId { get; }

    public PinCode PinCode { get; }

    public Money Balance { get; private set; }

    public Account(AccountId id, PinCode pinCode)
    {
        AccountId = id;
        PinCode = pinCode;
        Balance = new(0);
    }

    public Account(AccountId id, PinCode pinCode, Money balance)
    {
        AccountId = id;
        PinCode = pinCode;
        Balance = balance;
    }

    public OperationResult Withdraw(Money amount)
    {
        var operationType = new WithdrawOperationType();

        if (operationType.CanOperate(Balance, amount) is false)
        {
            return new OperationResult.Failure("Insufficient balance");
        }

        Balance -= amount;
        return new OperationResult.Success(operationType.Type, amount);
    }

    public OperationResult Deposit(Money amount)
    {
        var operationType = new DepositOperationType();

        if (operationType.CanOperate(Balance, amount) is false)
        {
            return new OperationResult.Failure("It cannot deposit");
        }

        Balance += amount;
        return new OperationResult.Success(operationType.Type, amount);
    }

    public Money CheckBalance()
    {
        return Balance;
    }
}