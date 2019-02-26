using Net.Issues.Console.CallAnotherContractSample;
using Net.Issues.Console.Events;
using Net.Issues.Console.LoadKeyStoreFile;
using Net.Issues.Console.NatCoin;
using Net.Issues.Console.StructReturnData;

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
            new EventsSample().RunAsync().Wait();
        }
    }
}
