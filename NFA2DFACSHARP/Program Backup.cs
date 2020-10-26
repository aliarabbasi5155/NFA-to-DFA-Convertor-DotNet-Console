using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NFA2DFACSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            Machine vahid= new Machine();
            List<string> first = new List<string>() { "A", "C", "D", "E" };
            List<string> second = new List<string>() { "A", "C", "D", "D" };
            first.Sort();
            second.Sort();
            if (first.Contains("A"))
            {
                Console.WriteLine("Contains A");
            }
            if (first.Contains("F"))
            {
                Console.WriteLine("Contains F");
            }
            if (first.Aggregate((i, j) => i + j) == second.Aggregate((i, j) => i + j))
            {
                Console.WriteLine(first.Aggregate((i, j) => i + "," + j));
                Console.WriteLine(second.ToString());
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(first.Aggregate((i, j) => i + "," + j));
                Console.WriteLine("No");
            }
            vahid.Convert();
            //Console.WriteLine(vahid.alphabet[0]);
            Console.Read();
        }
    }
    class Machine
    {

        private List<char> alphabet;
        private List<string> states;
        private List<string> pstates;
        private List<string> fstates;
        private List<string> functions;
        public Machine()
        {
            alphabet = new List<char>() { 'a', 'b' };
            states = new List<string>() { "A", "C", "D", "E" };
            pstates = new List<string>() { "A", "C" };
            fstates = new List<string>() { "C", "D" };
            functions = new List<string>()
            {
                "A,a,D",
                "A,b,D",
                "A,b,C",
                "D,a,C",
                "D,b,E",
                "E,a,C",
                "C,b,E",
                "C,b,D"
            };

        }
        public void Convert()
        {
            Machine DFA=new Machine();
            List<List<string>> processed = new List<List<string>>();
            List<List<string>> processing = new List<List<string>>();
            processing.Add(pstates);//-----

            for (int a=0; processing[a]!=null;a++ )
            {
                int s = 0;
                Console.WriteLine("Ali");
                for (int b= 0; processed.Any();b++)
                {
                    Console.WriteLine("Ali");
                    processing[a].Sort();
                    processed[b].Sort();
                    if (processing[a].Aggregate((i, j) => i + j) == processed[b].Aggregate((i, j) => i + j))
                    {
                        s++;
                    }
                }
                if (s == 0)
                {
                    for (int c=0;alphabet[c] != 0;c++)//-----
                    {
                        List<string> dest = new List<string>();
                        for (int d=0;processing[a]!=null;d++)
                        {
                            if (pstates.Contains(processing[a][d]))//-----
                            {
                                if (!(DFA.pstates.Contains(processing[a].Aggregate((i, j) => i + j))))
                                { DFA.pstates.Add(processing[a].Aggregate((i, j) => i + j)); }
                            }
                            else if (fstates.Contains(processing[a][d]))//-----
                            {
                                if(!(DFA.fstates.Contains(processing[a].Aggregate((i, j) => i + j))))
                                {
                                    DFA.fstates.Add(processing[a].Aggregate((i, j) => i + j));
                                }
                            }
                            for (int e= 0; functions[e]!=null;e++)//-----
                            {
                                String[] substrings = functions[e].Split(',');
                                if (processing[a][d] == substrings[0])
                                {
                                    dest.Add(substrings[2]);
                                }
                            }
                            
                        }
                        if (dest.Count == 0) { dest.Add("DAM"); }
                        string func = processing[a].Aggregate((i, j) => i + j) + alphabet[c] + dest.Aggregate((i, j) => i + j);
                        DFA.functions.Add(func);
                        processing.Add(dest);
                        processed.Add(processing[a]);


                    }
                }
            }
            Console.WriteLine(DFA.alphabet);
            Console.WriteLine(DFA.fstates);
            Console.WriteLine(DFA.functions);
            Console.WriteLine(DFA.pstates);
            Console.WriteLine(DFA.states);
        }
    }
}
