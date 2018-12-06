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

namespace Net.Contracts.TestStructOutput.ContractDefinition
{
    public partial class TestStructOutputDeployment : TestStructOutputDeploymentBase
    {
        public TestStructOutputDeployment() : base(BYTECODE) { }
        public TestStructOutputDeployment(string byteCode) : base(byteCode) { }
    }

    public class TestStructOutputDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506103c6806100206000396000f3fe60806040526004361061004b5763ffffffff7c01000000000000000000000000000000000000000000000000000000006000350416633bc5de308114610050578063a898fd701461007b575b600080fd5b34801561005c57600080fd5b5061006561009e565b6040516100729190610336565b60405180910390f35b34801561008757600080fd5b506100906101a3565b60405161007292919061030e565b6100a661027d565b7312890d2cce102216644c59dae5baed380d84830c3314156101335760408051908101604052807f6d7966696c65000000000000000000000000000000000000000000000000000081526020016040805190810160405280600881526020017f307831323334353600000000000000000000000000000000000000000000000081525081525090506101a0565b60408051908101604052807f616e6f7468657246696c6500000000000000000000000000000000000000000081526020016040805190810160405280600681526020017f307831313131000000000000000000000000000000000000000000000000000081525081525090505b90565b600060607312890d2cce102216644c59dae5baed380d84830c33141561022057505060408051808201909152600881527f307831323334353600000000000000000000000000000000000000000000000060208201527f6d7966696c65000000000000000000000000000000000000000000000000000090610279565b505060408051808201909152600681527f307831313131000000000000000000000000000000000000000000000000000060208201527f616e6f7468657246696c65000000000000000000000000000000000000000000905b9091565b60408051808201909152600081526060602082015290565b61029e816101a0565b82525050565b60006102af8261034e565b8084526102c3816020860160208601610352565b6102cc81610382565b9093016020019392505050565b805160009060408401906102ed8582610295565b506020830151848203602086015261030582826102a4565b95945050505050565b6040810161031c8285610295565b818103602083015261032e81846102a4565b949350505050565b6020808252810161034781846102d9565b9392505050565b5190565b60005b8381101561036d578181015183820152602001610355565b8381111561037c576000848401525b50505050565b601f01601f19169056fea265627a7a7230582081ada75bfd7708383d6568f9d78569f338e5e6ab0afddd6a4a8858b66a5b59756c6578706572696d656e74616cf50037";
        public TestStructOutputDeploymentBase() : base(BYTECODE) { }
        public TestStructOutputDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetDataFunction : GetDataFunctionBase { }

    [Function("getData", "tuple")]
    public class GetDataFunctionBase : FunctionMessage
    {

    }

    public partial class GetData2Function : GetData2FunctionBase { }

    [Function("getData2", typeof(GetData2OutputDTO))]
    public class GetData2FunctionBase : FunctionMessage
    {

    }

    public partial class GetDataOutputDTO : GetDataOutputDTOBase { }


    [FunctionOutput]
    public class GetDataOutputDTOBase : IFunctionOutputDTO 
    {
        //Struct return, created manually the type
        [Parameter("tuple", "test", 1)]
        public virtual Test Test { get; set; }
    }

    //This is the struct, created manually
    public class Test 
    {
        [Parameter("bytes32", "fileName", 1)]
        public virtual string FileName { get; set; }
        [Parameter("string", "imageHash", 2)]
        public virtual string ImageHash { get; set; }
    }

    public partial class GetData2OutputDTO : GetData2OutputDTOBase { }

    [FunctionOutput]
    public class GetData2OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "fileName", 1)]
        public virtual string FileName { get; set; }
        [Parameter("string", "imageHash", 2)]
        public virtual string ImageHash { get; set; }
    }
}
