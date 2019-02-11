pragma solidity ^0.5;

import "./Proxy.sol";


/**
 * @title UpgradeabilityProxy
 * @dev This contract implements a proxy that allows to change the
 * implementation address to which it will delegate.
 * Such a change is called an implementation upgrade.
 */
contract UpgradeabilityProxy is Proxy {
  /**
   * @dev Emitted when the implementation is upgraded.
   * @param implementation Address of the new implementation.
   */
  event Upgraded(address indexed implementation);

  /**
   * @dev Storage slot with the address of the current implementation.
   * This is the keccak-256 hash of "org.zeppelinos.proxy.implementation", and is
   * validated in the constructor.
   */
  bytes32 private constant IMPLEMENTATION_SLOT = 0x7050c9e0f4ca769c69bd3a8ef740bc37934f8e2c036e5a723fd8ee048ed3f8c3;

  /**
   * @dev Contract constructor.
   * @param _implementation Address of the initial implementation.
   *  Data to send as msg.data to the implementation to initialize the proxied contract.
   * It should include the signature and the parameters of the function to be called, as described in
   * https://solidity.readthedocs.io/en/v0.4.24/abi-spec.html#function-selector-and-argument-encoding.
   * This parameter is optional, if no data is given the initialization call to proxied contract will be skipped.
   */
    constructor(address _implementation) public payable {
        assert(IMPLEMENTATION_SLOT == keccak256("org.zeppelinos.proxy.implementation"));
        _setImplementation(_implementation);
      //  if(_data.length > 0) {
      //      require(_implementation.delegatecall(_data), "delegate call failed");
      //  }
    }

    /**
    * @dev Returns the current implementation.
    * @return Address of the current implementation
    */
    function _implementation() internal view returns (address impl) {
        bytes32 slot = IMPLEMENTATION_SLOT;
        assembly {
           impl := sload(slot)
        }
    }

    function implementation() public view returns (address impl) {
        bytes32 slot = IMPLEMENTATION_SLOT;
        assembly {
           impl := sload(slot)
        }
    }



    function UpgradeTo(address newImplementation) public
    {
        require(msg.sender == address(this), "This can only be called by the logic contract" );
        _upgradeTo(newImplementation);
    }

  /**
   * @dev Upgrades the proxy to a new implementation.
   * @param newImplementation Address of the new implementation.
   */
    function _upgradeTo(address newImplementation) internal {
        _setImplementation(newImplementation);
        emit Upgraded(newImplementation);
    }

  /**
   * @dev Sets the implementation address of the proxy.
   * @param newImplementation Address of the new implementation.
   */
    function _setImplementation(address newImplementation) private {
       // require(AddressUtils.isContract(newImplementation), "Cannot set a proxy implementation to a non-contract address");

        bytes32 slot = IMPLEMENTATION_SLOT;
        assembly {
            sstore(slot, newImplementation)
        }
    }
}
