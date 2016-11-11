using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riat_l2
{
    class Program
    {
        private static readonly Serializer[] serializers = { new JsonSerializer(), new XmlSerializerMy() };
        public static Serializer getSerializer(string type)
        {
            if (type != "Json" && type != "Xml")
            {
                throw new System.ArgumentException("Wrong type.", type);
            }
            return (type == "Json" ? serializers[0] : serializers[1]);
        }

        static void Main(string[] args)
        {
            var serializingType = Console.ReadLine();
            var serializer = Program.getSerializer(serializingType);
            var inputData = Encoding.UTF8.GetBytes(Console.ReadLine());
            var input = serializer.Deserialize<Input>(inputData);
            var output = input.createOutput();
            Console.WriteLine(Encoding.UTF8.GetString(serializer.Serialize(output)));
        }
    }
}
