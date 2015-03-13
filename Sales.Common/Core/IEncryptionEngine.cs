using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Common.Core
{
    interface IEncryptionEngine
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
        bool IsEncrypt(string text);
    }
}
