using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;

namespace Net.Contracts.NatCoin.CQS
{
    [Function("createUserNatCoins")]
    public class CreateUserNatCoinsFunction:ContractMessage
    {
        [Parameter("uint256", "id", 1)]
        public BigInteger Id {get; set;}
        [Parameter("string", "_login", 2)]
        public string Login {get; set;}
        [Parameter("uint256", "_natcoin", 3)]
        public BigInteger Natcoin {get; set;}
        [Parameter("string", "_email", 4)]
        public string Email {get; set;}
    }
}
