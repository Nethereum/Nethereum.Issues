pragma solidity ^0.4.24;

contract Constructor10 {
    
    uint256 public F;

    constructor (uint256 a,
               uint256 p1, uint256 p2, uint256 p3,
               uint8 r1, uint8 r2, uint8 r3, uint8 r4,
               uint256 f) public {
        F = f;
    }
}