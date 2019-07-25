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

namespace PurchaseContracts.Bytes32Array.ContractDefinition
{


    public partial class Bytes32ArrayDeployment : Bytes32ArrayDeploymentBase
    {
        public Bytes32ArrayDeployment() : base(BYTECODE) { }
        public Bytes32ArrayDeployment(string byteCode) : base(byteCode) { }
    }

    public class Bytes32ArrayDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610263806100206000396000f3fe608060405234801561001057600080fd5b506004361061002b5760003560e01c806364e5cf2114610030575b600080fd5b61003861004e565b60405161004591906101f2565b60405180910390f35b604080516003808252608082019092526060918291906020820183803883390190505090506100a36040518060400160405280600f81526020016e737472696e67206c696e65206f6e6560881b815250610154565b816000815181106100b057fe5b6020026020010181815250506100ec6040518060400160405280600f81526020016e737472696e67206c696e652074776f60881b815250610154565b816001815181106100f957fe5b60200260200101818152505061013760405180604001604052806011815260200170737472696e67206c696e6520746872656560781b815250610154565b8160028151811061014457fe5b6020908102919091010152905090565b80516000908290610169575060009050610171565b505060208101515b919050565b600061018283836101e3565b505060200190565b600061019582610210565b61019f8185610214565b93506101aa8361020a565b8060005b838110156101d85781516101c28882610176565b97506101cd8361020a565b9250506001016101ae565b509495945050505050565b6101ec8161021d565b82525050565b60208082528101610203818461018a565b9392505050565b60200190565b5190565b90815260200190565b9056fea365627a7a72305820f4470bd45e689e5ec9e15c4ca0de9af5a5e3a272769e9cf34ed334723436e43d6c6578706572696d656e74616cf564736f6c634300050a0040";
        public Bytes32ArrayDeploymentBase() : base(BYTECODE) { }
        public Bytes32ArrayDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetStringyFunction : GetStringyFunctionBase { }

    [Function("getStringy", "bytes32[]")]
    public class GetStringyFunctionBase : FunctionMessage
    {

    }

    public partial class GetStringyOutputDTO : GetStringyOutputDTOBase { }

    [FunctionOutput]
    public class GetStringyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32[]", "listOfValues", 1)]
        public virtual List<byte[]> ListOfValues { get; set; }       
    }
}
