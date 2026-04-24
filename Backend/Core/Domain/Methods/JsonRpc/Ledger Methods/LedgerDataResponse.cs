namespace XRPL.Core.Domain.Methods.JsonRpc.LedgerMethods
{
    public record LedgerDataResponse: Response
    {

    }

    public record LedgerDataResult: Result
    {
        public required LedgerHeader Ledger { get; init; }

        public required uint LedgerIndex { get; init; }

        public required string LedgerHash { get; init; }

        public LedgerState[] State { get; init; } 

        public object? Marker { get; init; }
    }

    public record LedgerState
    {

    }
}