﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Jurassic;
using Jurassic.Library;
using zxcvbn.net.Properties;


namespace zxcvbn.net
{
    public class ZxcvbnInstance
    {
        public ScriptEngine Engine { get { return LazyLoadEngine.Value; } }
        private static readonly Lazy<ScriptEngine> LazyLoadEngine = new Lazy<ScriptEngine>(ScriptEngine);

        private static ScriptEngine ScriptEngine()
        {
            ScriptEngine engine = new ScriptEngine();

            //The global object 'exports', is needed for the zxcvbn.js lib. Used for scoping.
            engine.Execute("exports = {};");

            var assembly = Assembly.GetAssembly(typeof(ZxcvbnInstance));

            using (Stream resourceStream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".js.zxcvbn.js"))
            using (StreamReader streamReader = new StreamReader(resourceStream))
            {
                string jsString = streamReader.ReadToEnd();
                engine.Execute(jsString);

                return engine;
            }
        }

        private T CallJSzxcvbnFunction<T>(string password, String func)
        {
            const int maxLength = 4096;
            if (password.Length <= maxLength)
                return Engine.Evaluate<T>(String.Format("exports.zxcvbn('{0}').{1}", password, func));

            throw new InvalidDataException(String.Format(Resources.InvalidData_PasswordIsTooLong, maxLength));
        }


        public int Score(String password)
        {
            var result = CallJSzxcvbnFunction<int>(password, "score");
            return result;
        }

        

        public Double Entropy(String password)
        {
            return Engine.Evaluate<Double>("exports.zxcvbn('" + password + "').entropy");
        }




        public int crack_time(String password)
        {
            return CallJSzxcvbnFunction<int>(password, "crack_time");
           
        }
        public String crack_time_display(String password)
        {
            return CallJSzxcvbnFunction<String>(password, "score");
        }

        public List<String> match_sequence(String password)
        {
            return CallJSzxcvbnFunction<List<String>>(password, "match_sequence");
        }

        public int calculation_time(String password)
        {
            return CallJSzxcvbnFunction<int>(password, "calculation_time");
        }

    }
}
