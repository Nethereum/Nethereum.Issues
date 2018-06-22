pragma solidity ^0.4.24;
pragma experimental "ABIEncoderV2";

contract Test {

    function callManyOtherContracts(address theOther) public view returns (bytes[10] result){
        result[0] = CallAnotherContract(theOther);
        result[1] = CallAnotherContract(theOther);
        result[2] = CallAnotherContract(theOther);
        return result;
    }

    function CallAnotherContract(address theOther) public view returns(bytes result) 
    {
        string memory name = "Solidity";
        string memory greeting = "Welcome something much much biggger jlkjfslkfjslkdfjsldfjasdflkjsafdlkjasdfljsadfljasdfkljasdkfljsadfljasdfldsfaj booh!";

        bytes memory callData = abi.encodeWithSignature("CallMe(string,string)", name, greeting);
        return callContract(theOther, callData);
        //result = string(callContract(theOther, callData));
        //return result;

    }

    function callContract(address contractAddress, bytes memory data) view internal  returns(bytes memory answer) {

        uint256 length = data.length;
        // uint256 size = 0;
        assembly {

            let result := call(gas(), 
                contractAddress, 
                0, 
                add(data, 0x20), 
                length, 
                //mload(data), 
                0, 
                0)

            let size := returndatasize

            answer := mload(0x40)
            
            returndatacopy(answer, 0, size)
            mstore(answer, size)
            mstore(0x40, add(answer, size))
        }

        return answer;
    }
}

contract TheOther
{
    function CallMe(string name, string greeting) public view returns(bytes test)
    {
        string memory namex = name;
        string memory greetingx = greeting;
        //return 199;

        test = abi.encodePacked("Hello ", namex ," ", greetingx);
        return test;
    }
}