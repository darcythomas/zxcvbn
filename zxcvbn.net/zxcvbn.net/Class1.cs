using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jurassic;

namespace zxcvbn.net
{
    public class Class1
    {
        static ScriptEngine _engine;
        public ScriptEngine Engine
        {
            get { return _engine ?? (_engine = new ScriptEngine()); }
        }


        private void Run(string lib, string input)
        {

            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            Engine.Execute(lib);

            Engine.Execute("var compile = function (password) " +
                "{ return 10; };");

            var output = Engine.CallGlobalFunction("test", input);
            stopwatch.Stop();
        }

    }
}
