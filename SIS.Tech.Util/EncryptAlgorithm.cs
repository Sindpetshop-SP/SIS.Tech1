using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Util
{
    public sealed class EncryptAlgorithm
    {
        public enum EncryptionAlgorithm
        {
            Des = 1,
            Rc2,
            Rijndael,
            TripleDes
        }
    }
}
