/*
  1. Json.NET をダウンロード。
       $ nuget install
  2. 作業ディレクトリにコピー。
       $ cp Newtonsoft.Json.8.0.3/lib/net45/Newtonsoft.Json.dll .
  3. コンパイルして sampleAI.exe を作成。
       $ mcs sampleAI.cs -r:Newtonsoft.Json.dll
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SampleAI {
    static Random random;

    static void mapMode(JObject message)
    {
        var choices = new String[] {"UP","DOWN","RIGHT","LEFT","HEAL"};
        var i = random.Next(0, choices.Length);
        Console.WriteLine(choices[i]);
    }

    static void battleMode(JObject message)
    {
        Console.WriteLine("SWING");
    }

    static void equipMode(JObject message)
    {
        Console.WriteLine("YES");
    }

    static void levelupMode(JObject message)
    {
        Console.WriteLine("HP");
    }

    public static void Main()
    {
        random = new Random();

        Console.WriteLine("C#サンプルAI");

        String line;
        while ((line = Console.ReadLine()) != null )
        {
            JObject message = JObject.Parse(line);
            var d = message as IDictionary<String,JToken>;
            if (d.ContainsKey("map"))
                mapMode(message);
            else if (d.ContainsKey("battle"))
                battleMode(message);
            else if (d.ContainsKey("equip"))
                equipMode(message);
            else if (d.ContainsKey("levelup"))
                levelupMode(message);
            else
            {
                Console.Error.WriteLine("Invalid input: {0}", line);
                Environment.Exit(1);
            }
        }
    }
}
