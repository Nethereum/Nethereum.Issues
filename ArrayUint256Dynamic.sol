pragma solidity ^0.4.24;

contract ArrayUint256Dynamic {
    
    function GiveMeTheArray() pure public returns (uint256[] result) {
        result = new uint256[](2);
        result[0] = 1;
        result[1] = 2;
        return result;
    }
}