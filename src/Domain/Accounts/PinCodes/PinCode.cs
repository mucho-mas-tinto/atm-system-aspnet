namespace AtmSystem.Domain.Accounts.PinCodes;

public readonly record struct PinCode(string Value)
{
    private const long PinCodeLength = 6;

    public bool IsValid => Value.Length == PinCodeLength;
}