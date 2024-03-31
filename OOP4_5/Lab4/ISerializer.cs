using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public interface ISerializer
    {
        void Serialize(Stream stream , Object obj);
    }
}
