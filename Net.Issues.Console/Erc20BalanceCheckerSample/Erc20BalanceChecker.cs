using Nethereum.StandardTokenEIP20;
using Nethereum.Web3;
using System.Threading.Tasks;

namespace Net.Issues.Console.Erc20BalanceCheckerSample
{
    public class Erc20BalanceChecker
    {
        public async Task RunAsync()
        {
            // Ethereum network to connect to
            var ethereumNetworkUrl = "https://mainnet.infura.io/";

            // ERC20 token called Gemini Dollar GUSD deployed on MainNet here:
            // https://etherscan.io/address/0x056Fd409E1d7A124BD7017459dFEa2F387b6d5Cd#contracts
            var erc20TokenContractAddress = "0x056Fd409E1d7A124BD7017459dFEa2F387b6d5Cd";
            var accountWithSomeTokens = "0xdc24703f9210d377951819f2cc1dcc4061b88a67";

            // Setup web3 and token service, to allow us to interact with ERC20 contract
            var web3 = new Web3(ethereumNetworkUrl);
            var tokenService = new StandardTokenService(web3, erc20TokenContractAddress);

            // Check an address balance
            var symbol = await tokenService.SymbolQueryAsync();
            var tokens = await tokenService.BalanceOfQueryAsync(accountWithSomeTokens);
            System.Console.WriteLine($"Address: {accountWithSomeTokens} holds: {tokens} {symbol}");
            System.Console.ReadLine();
        }
    }
}
