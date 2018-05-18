pragma solidity 0.4.24;

contract NatCoin {
    struct UserBalance {
        uint natcoins;
        string email;
        string login;
    }

    mapping (uint => UserBalance) usersBalances;

    function createUserNatCoins(uint id, string _login, uint _natcoin, string _email) public {
        usersBalances[id].login = _login;
        usersBalances[id].natcoins = _natcoin;
        usersBalances[id].email = _email;
    }

    function getUserBalance(uint id) view public returns (uint) {
        return usersBalances[id].natcoins;
    }
}