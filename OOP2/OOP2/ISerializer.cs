using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public interface ISerializer
    {
         void Serialize(Stream serializationStream, Object obj);

    }

    public class SerializationException : Exception
    {
        public SerializationException(string message) : base(message) { }
    }
}