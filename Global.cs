using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typing_Test
{
    public static class Global
    {
        public static readonly string DbPath = Path.Combine(
            Environment.CurrentDirectory,
            "Typing_Test.db");
    }
}
