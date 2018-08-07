using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Contracts.CQS;

namespace Net.Contracts.NatCoin.CQS
{
    [Function("getUserBalance", "uint256")]
    public class GetUserBalanceFunction: FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public BigInteger Id {get; set;}
    }
}
