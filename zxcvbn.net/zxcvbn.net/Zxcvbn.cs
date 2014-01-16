using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Jurassic;

namespace zxcvbn.net
{
    public class Zxcvbn
    {

        public static ScriptEngine Engine { get { return LazyLoadEngine.Value; } }

        private static readonly Lazy<ScriptEngine> LazyLoadEngine = new Lazy<ScriptEngine>(ScriptEngine);

        private static ScriptEngine ScriptEngine()
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\js\";
            ScriptEngine engine = new ScriptEngine();
            engine.ExecuteFile(path + "zxcvbn.js");
            return engine;
        }

      



        public int Score(String password)
        {
            dynamic result = Test(password);
            return result.score;
        }

        //public float entropy(String password)
        //{

        //}
        //result.crack_time         # estimation of actual crack time, in seconds.

        //result.crack_time_display # same crack time, as a friendlier string:
        //                          # "instant", "6 minutes", "centuries", etc.

        //result.score              # [0,1,2,3,4] if crack time is less than
        //                          # [10**2, 10**4, 10**6, 10**8, Infinity].
        //                          # (useful for implementing a strength bar.)

        //result.match_sequence     # the list of patterns that zxcvbn based the
        //                          # entropy calculation on.

        //result.calculation_time   # how long it took to calculate an answer,
        //                          # in milliseconds. usually only a few ms.

        public object Test(string password)
        {

            var stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
         


            // Engine.SetGlobalValue("password", password);

            var q = Engine.GetGlobalValue<string>("password");


            stopwatch.Stop();
            return q;

        }

    }
}
