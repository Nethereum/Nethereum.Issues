using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Geth;
using Nethereum.Web3.Accounts;

namespace Net.Issues.Console.LoadKeyStoreFile
{
    public class LoadAccountFromKeyStoreSample
    {
        public async Task GethAccount()
        {
            //invalid password
           //var keyStoreJson =
           //    @"{'address':'37dfe826706323e01292b002cf09113f85377b7f','crypto':{'cipher':'aes-128-ctr','ciphertext':'cbd175404554766d1d0248cd74cb69c673c2eebc4af7bef78351b05b904b128b','cipherparams':{'iv':'9b3ef8f2e5c09a6e3c4175bb80de8465'},'kdf':'scrypt','kdfparams':{'dklen':32,'n':262144,'p':1,'r':8,'salt':'4543d3db86f66ccec9388b59de4a5a8f530e3c7ec1e5e0e264b1ebf83c84e495'},'mac':'617e27751ab4d7294651ae70869f091df26ace1146a1332b0f2cdedbc1afa5f9'},'id':'a8e80e2c-78f2-4bc2-8846-eae506b60e66','version':3}";
           //var account1 = Nethereum.Web3.Accounts.Account.LoadFromKeyStore(keyStoreJson, "123456..");

           // var gethWeb3 = new Web3Geth("http://localhost:8545");
            //var newAccount = await gethWeb3.Personal.NewAccount.SendRequestAsync("12345678");

            //Created by Geth using rpc
            var keyStoreJson2 =
                "{'address':'77d1ead27e8ff8bcfc65424d94bcd124a3e5bf85','crypto':{'cipher':'aes-128-ctr','ciphertext':'dfbd51e7b09dadeb6ad8cf09d4222df935a68d9b6aa9834c86269028aa960022','cipherparams':{'iv':'9e7bcfd7d6c1b8b62a38ebb7af66767f'},'kdf':'scrypt','kdfparams':{'dklen':32,'n':262144,'p':1,'r':8,'salt':'84707dfc93304bb3cbc09d03d1ac3cfc54876391925a0c8e98bc3dc3ac0b125c'},'mac':'ae833749652f3cdf53690eca8f76bfef6ff2372f41a6a6bef44163cea074ad05'},'id':'491c026b-3f9c-4af6-a29f-c2d76f6f769c','version':3}";
            var account = Nethereum.Web3.Accounts.Account.LoadFromKeyStore(keyStoreJson2, "12345678");


            //Created by Geth using console
            keyStoreJson2 =
                "{'address':'bf07cfb33e3fb9a7791a5947d1e2d33c30df1261','crypto':{'cipher':'aes-128-ctr','ciphertext':'28ae4c522392a9a43241ac84d8d4d2384712964d297c893af834890341df5e25','cipherparams':{'iv':'0f32d4af0aa93541f0f701ccd2ed5cac'},'kdf':'scrypt','kdfparams':{'dklen':32,'n':262144,'p':1,'r':8,'salt':'3df435da3bdeab7cc40a9670ca238a4e052f1344e0bde8fe8837b19d63964358'},'mac':'7b1cd30c23d07552299963194f6339e189ba36fefe18d7b994297ee560fa8491'},'id':'9580f689-931d-49be-9c5a-f9466c3cd2d9','version':3}";
            account = Nethereum.Web3.Accounts.Account.LoadFromKeyStore(keyStoreJson2, "12345678");

            var anotherJson =
                @"{'address':'a410885fe2f78d53a8ae7eac2381bf9b3bfeb21b','crypto':{'cipher':'aes-128-ctr','ciphertext':'f19b0be6afc69fe73907b5363334e9baabb9de57212e2e9b0cb64259a89efa31','cipherparams':{'iv':'8cffd3fbdbc31e290058c37f656b799e'},'kdf':'scrypt','kdfparams':{'dklen':32,'n':262144,'p':1,'r':8,'salt':'7c7b2a916e53b65a12cf43275990307b553b79dbae44cd15c629e0367160863f'},'mac':'90bb582aa8e3149078688af12f2738d0e405c4d3e6232088111acf4152104e64'},'id':'37d4e7a5-5036-4644-89a4-400333f54862','version':3}";
            var account2 = Account.LoadFromKeyStore(anotherJson, "testtest");
        }
    }
}
