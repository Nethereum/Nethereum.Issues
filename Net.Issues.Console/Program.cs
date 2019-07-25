using Net.Issues.Console.CallAnotherContractSample;
using Net.Issues.Console.Events;
using Net.Issues.Console.LoadKeyStoreFile;
using Net.Issues.Console.NatCoin;
using Net.Issues.Console.StructReturnData;
using Net.Issues.Console.Erc20BalanceCheckerSample;
using Net.Issues.Console.FindTransactionsForAddress;
using Net.Issues.Console.PayableEtherTransferSample;
using Net.Issues.Console.CallingOnlyOwnerFunction;
using Net.Issues.Console.Bytes32ArraySample;

namespace Net.Issues.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //new NatCoinIssue().RunAsync().Wait();
            //new CallAnotherContract().RunAsync().Wait();
            //new ConstructorSample().RunAsync().Wait();
            //new LoadAccountFromKeyStoreSample().GethAccount().Wait();
            //new ArrayUint256DynamicSample().RunAsync().Wait();
            //new PendingTransactionsSample().RunAsync().Wait();
            //new StructReturnDataSample().RunAsync().Wait();
            //new ProxySample().RunAsync().Wait();
            //new EventsSample().RunAsync().Wait();
            //new Erc20BalanceChecker().RunAsync().Wait();
            //new FindTransacactionsForAddress().RunAsync().Wait();
            //new CallingOnlyOwnerFunctionSample().RunAsync().Wait();
            //new PayableEtherTransfer().RunAsync().Wait();            
            //new RetrievingAFailedTransaction.RetrievingAFailedTransactionSample().RunAsync().Wait();
            new Bytes32Array().RunAsync().Wait();
        }
    }
}
