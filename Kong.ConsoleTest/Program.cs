using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kong.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var properties = typeof(Browser).GetRuntimeProperties().Select(p => new
            {
                p.Name,
                Getter = p.GetGetMethod()
            }).Where(p => p.Getter.IsPublic && !p.Getter.IsStatic).OrderBy(p => p.Name);
            foreach (var kv in new Dictionary<string, string>
            {
                {
                    "Microsoft Edge on Windows 10 Anniversary Edition",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393"
                },
                {
                    "Chrome on Windows 10 Anniversary Edition",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36"
                },
                {
                    "iPhone 6",
                    "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1"
                },
                {
                    "iPad Pro",
                    "Mozilla/5.0 (iPad; CPU OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1"
                },
                {
                    "Google Nexus 6P",
                    "Mozilla/5.0 (Linux; Android 5.1.1; Nexus 6 Build/LYZ28E) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Mobile Safari/537.36"
                },
                {
                    "Samsung Galaxy S5",
                    "Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Mobile Safari/537.36"
                }
            })
            {
                Console.WriteLine("USER AGENT");
                Console.WriteLine("Name: {0}", kv.Key);
                Console.WriteLine("User Agent String: {0}", kv.Value);
                Console.WriteLine();
                Console.WriteLine("IDENTIFIED CHARACTERISTICS");
                var kong = new Browser(kv.Value);
                foreach (var property in properties)
                {
                    var value = property.Getter.Invoke(kong, new object[] { });
                    if (value != null)
                    {
                        var valueType = value.GetType();
                        if (valueType == typeof(bool))
                        {
                            if ((bool)value)
                                Console.WriteLine("{0}", property.Name);
                        }
                        else
                        {
                            var str = Convert.ToString(value);
                            if (!string.IsNullOrEmpty(str))
                                Console.WriteLine("{0}: {1}", property.Name, str);
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
