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

namespace SolidityTests.Contracts.UpgradeabilityProxy.ContractDefinition
{


    public partial class UpgradeabilityProxyDeployment : UpgradeabilityProxyDeploymentBase
    {
        public UpgradeabilityProxyDeployment() : base(BYTECODE) { }
        public UpgradeabilityProxyDeployment(string byteCode) : base(byteCode) { }
    }

    public class UpgradeabilityProxyDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405260405160208061043b8339810180604052602081101561002357600080fd5b505160405180602361041882396040519081900360230190206000805160206103f883398151915214905061005457fe5b6100668164010000000061006c810204565b5061007e565b6000805160206103f883398151915255565b61036b8061008d6000396000f3fe608060405260043610610045577c0100000000000000000000000000000000000000000000000000000000600035046317f7edf1811461004f5780635c60da1b1461008f575b61004d6100cd565b005b34801561005b57600080fd5b5061004d6004803603602081101561007257600080fd5b503573ffffffffffffffffffffffffffffffffffffffff166100e7565b34801561009b57600080fd5b506100a461014b565b6040805173ffffffffffffffffffffffffffffffffffffffff9092168252519081900360200190f35b6100d56100e5565b6100e56100e061014b565b610170565b565b33301461013f576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602d815260200180610313602d913960400191505060405180910390fd5b610148816102a1565b50565b7f7050c9e0f4ca769c69bd3a8ef740bc37934f8e2c036e5a723fd8ee048ed3f8c35490565b600060608273ffffffffffffffffffffffffffffffffffffffff166000366040518083838082843760405192019450600093509091505080830381855af49150503d80600081146101dd576040519150601f19603f3d011682016040523d82523d6000602084013e6101e2565b606091505b50915091507f7b055ed31fdae359f2c7cf173dcb0feecede9bc15ae2020db243e3a3323487e28282604051808315151515815260200180602001828103825283818151815260200191508051906020019080838360005b83811015610251578181015183820152602001610239565b50505050905090810190601f16801561027e5780820380516001836020036101000a031916815260200191505b50935050505060405180910390a180516020820183801561029d578282f35b8282fd5b6102aa816102ee565b60405173ffffffffffffffffffffffffffffffffffffffff8216907fbc7cd75a20ee27fd9adebab32041f755214dbc6bffa90cc0225b39da2e5c2d3b90600090a250565b7f7050c9e0f4ca769c69bd3a8ef740bc37934f8e2c036e5a723fd8ee048ed3f8c35556fe546869732063616e206f6e6c792062652063616c6c656420627920746865206c6f67696320636f6e7472616374a165627a7a72305820e3b445e1f727fd6bb25592ae71a679689ac29f21dc73c00b4a7fca5904e30d4000297050c9e0f4ca769c69bd3a8ef740bc37934f8e2c036e5a723fd8ee048ed3f8c36f72672e7a657070656c696e6f732e70726f78792e696d706c656d656e746174696f6e";
        public UpgradeabilityProxyDeploymentBase() : base(BYTECODE) { }
        public UpgradeabilityProxyDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_implementation", 1)]
        public virtual string Implementation { get; set; }
    }

    public partial class UpgradeToFunction : UpgradeToFunctionBase { }

    [Function("UpgradeTo")]
    public class UpgradeToFunctionBase : FunctionMessage
    {
        [Parameter("address", "newImplementation", 1)]
        public virtual string NewImplementation { get; set; }
    }

    public partial class ImplementationFunction : ImplementationFunctionBase { }

    [Function("implementation", "address")]
    public class ImplementationFunctionBase : FunctionMessage
    {

    }

    public partial class UpgradedEventDTO : UpgradedEventDTOBase { }

    [Event("Upgraded")]
    public class UpgradedEventDTOBase : IEventDTO
    {
        [Parameter("address", "implementation", 1, true )]
        public virtual string Implementation { get; set; }
    }

    public partial class LogAttemptEventDTO : LogAttemptEventDTOBase { }

    [Event("LogAttempt")]
    public class LogAttemptEventDTOBase : IEventDTO
    {
        [Parameter("bool", "success", 1, false )]
        public virtual bool Success { get; set; }
        [Parameter("bytes", "data", 2, false )]
        public virtual byte[] Data { get; set; }
    }



    public partial class ImplementationOutputDTO : ImplementationOutputDTOBase { }

    [FunctionOutput]
    public class ImplementationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "impl", 1)]
        public virtual string Impl { get; set; }
    }
}
