using System;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.Contracts.CQS;
using Nethereum.ABI.FunctionEncoding.Attributes;
namespace Net.Issues.Contracts.Constructor10.CQS
{
    public class Constructor10Deployment:ContractDeploymentMessage
    {
        
        public static string BYTECODE = "608060405234801561001057600080fd5b50604051610120806100d18339810160405261010001516000556099806100386000396000f300608060405260043610603e5763ffffffff7c010000000000000000000000000000000000000000000000000000000060003504166328811f5981146043575b600080fd5b348015604e57600080fd5b5060556067565b60408051918252519081900360200190f35b600054815600a165627a7a72305820ed677379826a042ce7f5cea3f7886c34ff2aca6e309095738d790581346a27750029";
        
        public Constructor10Deployment():base(BYTECODE) { }
        
        public Constructor10Deployment(string byteCode):base(byteCode) { }
        
        [Parameter("uint256", "a", 1)]
        public BigInteger A {get; set;}
        [Parameter("uint256", "p1", 2)]
        public BigInteger P1 {get; set;}
        [Parameter("uint256", "p2", 3)]
        public BigInteger P2 {get; set;}
        [Parameter("uint256", "p3", 4)]
        public BigInteger P3 {get; set;}
        [Parameter("uint8", "r1", 5)]
        public byte R1 {get; set;}
        [Parameter("uint8", "r2", 6)]
        public byte R2 {get; set;}
        [Parameter("uint8", "r3", 7)]
        public byte R3 {get; set;}
        [Parameter("uint8", "r4", 8)]
        public byte R4 {get; set;}
        [Parameter("uint256", "f", 9)]
        public BigInteger F {get; set;}
    }
}
