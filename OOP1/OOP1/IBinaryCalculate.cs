using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public interface IBinaryCalculate
    {
        int BinaryAND();
        int BinaryOR();

        int BinaryNOT(int answer);

        int BinaryXOR();


        int OctusAND();
        int OctusOR();

        int OctusNOT(int answer);

        int OctusXOR();

        int DecimalAND();
        int DecimalOR();

        int DecimalNOT(int answer);

        int DecimalXOR();

        int HexAND();
        int HexOR();

        int HexNOT(int answer);

        int HexXOR();

    }
}
