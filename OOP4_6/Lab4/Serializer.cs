using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemJsonSerializer = System.Text.Json.JsonSerializer;

namespace Lab4
{
    public class Serializer : ISerializer
    {
        public void Serialize(Stream stream, object obj)
        {
            try
            {
                SystemJsonSerializer.Serialize(stream, obj);
            }
            catch (Exception ex)
            {
                throw new SerializationException($"{ex.Message}");
            }
        }
    }
}
