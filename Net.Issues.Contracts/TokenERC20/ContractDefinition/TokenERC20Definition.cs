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

namespace SolidityTests.Contracts.TokenERC20.ContractDefinition
{


    public partial class TokenERC20Deployment : TokenERC20DeploymentBase
    {
        public TokenERC20Deployment() : base(BYTECODE) { }
        public TokenERC20Deployment(string byteCode) : base(byteCode) { }
    }

    public class TokenERC20DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040526002805460ff191660121790553480156200001e57600080fd5b5060405162000ce438038062000ce4833981018060405260808110156200004457600080fd5b8151602083018051919392830192916401000000008111156200006657600080fd5b820160208101848111156200007a57600080fd5b81516401000000008111828201871017156200009557600080fd5b50509291906020018051640100000000811115620000b257600080fd5b82016020810184811115620000c657600080fd5b8151640100000000811182820187101715620000e157600080fd5b50506020918201516003879055600160a060020a038116600090815260048452604081208890558651929550909350620001219290919086019062000142565b5081516200013790600190602085019062000142565b5050505050620001e7565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106200018557805160ff1916838001178555620001b5565b82800160010185558215620001b5579182015b82811115620001b557825182559160200191906001019062000198565b50620001c3929150620001c7565b5090565b620001e491905b80821115620001c35760008155600101620001ce565b90565b610aed80620001f76000396000f3fe608060405234801561001057600080fd5b50600436106100ec576000357c010000000000000000000000000000000000000000000000000000000090048063434cc0a9116100a957806395d89b411161008357806395d89b41146103cc578063a9059cbb146103d4578063cae9ca5114610400578063dd62ed3e146104bb576100ec565b8063434cc0a91461023957806370a082311461037a57806379cc6790146103a0576100ec565b806306fdde03146100f1578063095ea7b31461016e57806318160ddd146101ae57806323b872dd146101c8578063313ce567146101fe57806342966c681461021c575b600080fd5b6100f96104e9565b6040805160208082528351818301528351919283929083019185019080838360005b8381101561013357818101518382015260200161011b565b50505050905090810190601f1680156101605780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b61019a6004803603604081101561018457600080fd5b50600160a060020a038135169060200135610577565b604080519115158252519081900360200190f35b6101b66105dd565b60408051918252519081900360200190f35b61019a600480360360608110156101de57600080fd5b50600160a060020a038135811691602081013590911690604001356105e3565b610206610653565b6040805160ff9092168252519081900360200190f35b61019a6004803603602081101561023257600080fd5b503561065c565b6103786004803603608081101561024f57600080fd5b8135919081019060408101602082013564010000000081111561027157600080fd5b82018360208201111561028357600080fd5b803590602001918460018302840111640100000000831117156102a557600080fd5b91908080601f01602080910402602001604051908101604052809392919081815260200183838082843760009201919091525092959493602081019350359150506401000000008111156102f857600080fd5b82018360208201111561030a57600080fd5b8035906020019184600183028401116401000000008311171561032c57600080fd5b91908080601f01602080910402602001604051908101604052809392919081815260200183838082843760009201919091525092955050509035600160a060020a031691506106d49050565b005b6101b66004803603602081101561039057600080fd5b5035600160a060020a0316610720565b61019a600480360360408110156103b657600080fd5b50600160a060020a038135169060200135610732565b6100f9610803565b61019a600480360360408110156103ea57600080fd5b50600160a060020a03813516906020013561085d565b61019a6004803603606081101561041657600080fd5b600160a060020a038235169160208101359181019060608101604082013564010000000081111561044657600080fd5b82018360208201111561045857600080fd5b8035906020019184600183028401116401000000008311171561047a57600080fd5b91908080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250929550610873945050505050565b6101b6600480360360408110156104d157600080fd5b50600160a060020a0381358116916020013516610991565b6000805460408051602060026001851615610100026000190190941693909304601f8101849004840282018401909252818152929183018282801561056f5780601f106105445761010080835404028352916020019161056f565b820191906000526020600020905b81548152906001019060200180831161055257829003601f168201915b505050505081565b336000818152600560209081526040808320600160a060020a038716808552908352818420869055815186815291519394909390927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925928290030190a350600192915050565b60035481565b600160a060020a038316600090815260056020908152604080832033845290915281205482111561061357600080fd5b600160a060020a03841660009081526005602090815260408083203384529091529020805483900390556106488484846109ae565b5060015b9392505050565b60025460ff1681565b3360009081526004602052604081205482111561067857600080fd5b3360008181526004602090815260409182902080548690039055600380548690039055815185815291517fcc16f5dbb4873280815c1ee09dbd06736cffcc184412cf7a71a0fdb75d397ca59281900390910190a2506001919050565b6003849055600160a060020a0381166000908152600460209081526040822086905584516107059291860190610a26565b508151610719906001906020850190610a26565b5050505050565b60046020526000908152604090205481565b600160a060020a03821660009081526004602052604081205482111561075757600080fd5b600160a060020a038316600090815260056020908152604080832033845290915290205482111561078757600080fd5b600160a060020a0383166000818152600460209081526040808320805487900390556005825280832033845282529182902080548690039055600380548690039055815185815291517fcc16f5dbb4873280815c1ee09dbd06736cffcc184412cf7a71a0fdb75d397ca59281900390910190a250600192915050565b60018054604080516020600284861615610100026000190190941693909304601f8101849004840282018401909252818152929183018282801561056f5780601f106105445761010080835404028352916020019161056f565b600061086a3384846109ae565b50600192915050565b6000836108808185610577565b15610989576040517f8f4ffcb10000000000000000000000000000000000000000000000000000000081523360048201818152602483018790523060448401819052608060648501908152875160848601528751600160a060020a03871695638f4ffcb195948b94938b939192909160a490910190602085019080838360005b83811015610918578181015183820152602001610900565b50505050905090810190601f1680156109455780820380516001836020036101000a031916815260200191505b5095505050505050600060405180830381600087803b15801561096757600080fd5b505af115801561097b573d6000803e3d6000fd5b50505050600191505061064c565b509392505050565b600560209081526000928352604080842090915290825290205481565b600160a060020a038083166000818152600460209081526040808320805495891680855282852080548981039091559486905281548801909155815187815291519390950194927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef929181900390910190a350505050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f10610a6757805160ff1916838001178555610a94565b82800160010185558215610a94579182015b82811115610a94578251825591602001919060010190610a79565b50610aa0929150610aa4565b5090565b610abe91905b80821115610aa05760008155600101610aaa565b9056fea165627a7a723058207c28d380e6c503f051922eae704acf145d9e213e4c7f5014caa9fa3a98ec7c650029";
        public TokenERC20DeploymentBase() : base(BYTECODE) { }
        public TokenERC20DeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint256", "initialSupply", 1)]
        public virtual BigInteger InitialSupply { get; set; }
        [Parameter("string", "tokenName", 2)]
        public virtual string TokenName { get; set; }
        [Parameter("string", "tokenSymbol", 3)]
        public virtual string TokenSymbol { get; set; }
        [Parameter("address", "owneraddress", 4)]
        public virtual string Owneraddress { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 3)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn", "bool")]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_value", 1)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class InitialiseFunction : InitialiseFunctionBase { }

    [Function("initialise")]
    public class InitialiseFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "initialSupply", 1)]
        public virtual BigInteger InitialSupply { get; set; }
        [Parameter("string", "tokenName", 2)]
        public virtual string TokenName { get; set; }
        [Parameter("string", "tokenSymbol", 3)]
        public virtual string TokenSymbol { get; set; }
        [Parameter("address", "owneraddress", 4)]
        public virtual string Owneraddress { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class BurnFromFunction : BurnFromFunctionBase { }

    [Function("burnFrom", "bool")]
    public class BurnFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public virtual string From { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class ApproveAndCallFunction : ApproveAndCallFunctionBase { }

    [Function("approveAndCall", "bool")]
    public class ApproveAndCallFunctionBase : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
        [Parameter("bytes", "_extraData", 3)]
        public virtual byte[] ExtraData { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "_owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "_spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BurnEventDTO : BurnEventDTOBase { }

    [Event("Burn")]
    public class BurnEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("uint256", "value", 2, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }





    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
