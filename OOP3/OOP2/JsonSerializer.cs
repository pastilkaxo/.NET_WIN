using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemJsonSerializer = System.Text.Json.JsonSerializer;

namespace OOP2
{
    public class JsonSerializer : ISerializer
    {

        public void Serialize(Stream serializationStream, object obj)
        {
            try
            {
               SystemJsonSerializer.Serialize(serializationStream,obj);
            }
            catch(Exception ex)
            {
                throw new SerializationException($"{ex.Message}");
            }


        }

    }
}