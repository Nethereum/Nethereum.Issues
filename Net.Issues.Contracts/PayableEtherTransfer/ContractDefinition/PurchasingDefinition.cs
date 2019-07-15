using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Net.Contracts.PayableEtherTransfer.ContractDefinition
{


    public partial class PurchasingDeployment : PurchasingDeploymentBase
    {
        public PurchasingDeployment() : base(BYTECODE) { }
        public PurchasingDeployment(string byteCode) : base(byteCode) { }
    }

    public class PurchasingDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5060ca8061001f6000396000f3fe60806040526004361060305760003560e01c8063055680f01460355780633b161d16146059578063934d85b4146075575b600080fd5b348015604057600080fd5b5060476087565b60408051918252519081900360200190f35b607360048036036020811015606d57600080fd5b5035608d565b005b348015608057600080fd5b5060476099565b60005481565b50600080546001019055565b60009056fea165627a7a723058200d6959ec3c7d837203202dcd81fc383672d5a49b5f5c6fc3490406fb9a63b2780029";
        public PurchasingDeploymentBase() : base(BYTECODE) { }
        public PurchasingDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class PurchaseCounterFunction : PurchaseCounterFunctionBase { }

    [Function("purchaseCounter", "int256")]
    public class PurchaseCounterFunctionBase : FunctionMessage
    {

    }

    public partial class BuySomethingFunction : BuySomethingFunctionBase { }

    [Function("buySomething")]
    public class BuySomethingFunctionBase : FunctionMessage
    {
        [Parameter("int256", "productId", 1)]
        public virtual BigInteger ProductId { get; set; }
    }

    public partial class GetBalanceOfThisFunction : GetBalanceOfThisFunctionBase { }

    [Function("getBalanceOfThis", "int256")]
    public class GetBalanceOfThisFunctionBase : FunctionMessage
    {

    }

    public partial class PurchaseCounterOutputDTO : PurchaseCounterOutputDTOBase { }

    [FunctionOutput]
    public class PurchaseCounterOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class GetBalanceOfThisOutputDTO : GetBalanceOfThisOutputDTOBase { }

    [FunctionOutput]
    public class GetBalanceOfThisOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
