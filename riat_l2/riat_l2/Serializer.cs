using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riat_l2
{
    public interface Serializer
    {
        byte[] Serialize<T>(T obj);
        T Deserialize<T>(byte[] data);
    }
}
