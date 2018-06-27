using Net.Issues.Console.CallAnotherContractSample;
using Net.Issues.Console.NatCoin;

namespace Net.Issues.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //new NatCoinIssue().RunAsync().Wait();
            //new CallAnotherContract().RunAsync().Wait();
            new ConstructorSample().RunAsync().Wait();
        }
    }
}
