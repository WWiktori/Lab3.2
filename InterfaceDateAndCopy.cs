using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1
{
    internal interface InterfaceDateAndCopy
    {
        Object DeepCopy();
        bool Equals(object obj);

        DateTime Date { get; set; }
    }
}
