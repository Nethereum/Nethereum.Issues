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

namespace Net.Contracts.CallingOnlyOwnerFunction.ContractDefinition
{

    public partial class AssetDeployment : AssetDeploymentBase
    {
        public AssetDeployment() : base(BYTECODE) { }
        public AssetDeployment(string byteCode) : base(byteCode) { }
    }

    public class AssetDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50600080546001600160a01b0319163317905561036c806100326000396000f3fe608060405234801561001057600080fd5b50600436106100365760003560e01c806358d932c91461003b5780638da5cb5b14610183575b600080fd5b61016f6004803603606081101561005157600080fd5b8135919081019060408101602082013564010000000081111561007357600080fd5b82018360208201111561008557600080fd5b803590602001918460018302840111640100000000831117156100a757600080fd5b91908080601f01602080910402602001604051908101604052809392919081815260200183838082843760009201919091525092959493602081019350359150506401000000008111156100fa57600080fd5b82018360208201111561010c57600080fd5b8035906020019184600183028401116401000000008311171561012e57600080fd5b91908080601f0160208091040260200160405190810160405280939291908181526020018383808284376000920191909152509295506101a7945050505050565b604080519115158252519081900360200190f35b61018b610331565b604080516001600160a01b039092168252519081900360200190f35b60405160009033907ff89f11557956b484c3b818a0f60a64137b4909a3f19b275c9aca64dd8d1b2ae7908390a26000546001600160a01b031633146102365760408051600160e51b62461bcd02815260206004820152601760248201527f73656e646572206973206e6f7420746865206f776e6572000000000000000000604482015290519081900360640190fd5b826040518082805190602001908083835b602083106102665780518252601f199092019160209182019101610247565b51815160209384036101000a60001901801990921691161790526040805192909401829003822081835288518383015288519096508a955033947ecf5142520c79d46e645309182c8098d98434f0103e1deab65ca9d443008bcc94508993928392918301919085019080838360005b838110156102ed5781810151838201526020016102d5565b50505050905090810190601f16801561031a5780820380516001836020036101000a031916815260200191505b509250505060405180910390a45060019392505050565b6000546001600160a01b03168156fea165627a7a72305820e0051d0f686ba5259c4239a0a26fb442d1eed2264145dc7852a28069de6391190029";
        public AssetDeploymentBase() : base(BYTECODE) { }
        public AssetDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CreateAssetFunction : CreateAssetFunctionBase { }

    [Function("createAsset", "bool")]
    public class CreateAssetFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "price", 3)]
        public virtual string Price { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class AssetCreationAttemptEventDTO : AssetCreationAttemptEventDTOBase { }

    [Event("assetCreationAttempt")]
    public class AssetCreationAttemptEventDTOBase : IEventDTO
    {
        [Parameter("address", "sender", 1, true )]
        public virtual string Sender { get; set; }
    }

    public partial class AssetCreatedEventDTO : AssetCreatedEventDTOBase { }

    [Event("assetCreated")]
    public class AssetCreatedEventDTOBase : IEventDTO
    {
        [Parameter("address", "sender", 1, true )]
        public virtual string Sender { get; set; }
        [Parameter("uint256", "id", 2, true )]
        public virtual BigInteger Id { get; set; }
        [Parameter("string", "name", 3, true )]
        public virtual string Name { get; set; }
        [Parameter("string", "price", 4, false )]
        public virtual string Price { get; set; }
    }



    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
