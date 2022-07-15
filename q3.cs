using System;
using System.Collections.Generic;
using System.Linq;

namespace q3
{
    class Program
    {
        public static List<string[]> Decode (string deltaTransitions)
        {
            List<string[]> AllTransitions = new List<string[]>();
            string[] sp = deltaTransitions.Split('0');
            int len = sp.Length;
            int i = 0;
            while (i<len)
            {
                AllTransitions.Add(new string[5]{sp[i],sp[i+1],sp[i+2],sp[i+3],sp[i+4]});
                i += 6;
                
            }
            return AllTransitions;
        }
        public static string TestOnTurinMachine(List<string[]> AllTransition, string test, string FinalState)
        {
            if (test == "")
                test = "1";
            List<string> Tape = new List<string>();
            // blank avale tape
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");Tape.Add("1");
            Tape.AddRange(test.Split('0'));
            // blank akhare tape
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");
            Tape.Add("1"); Tape.Add("1"); Tape.Add("1");Tape.Add("1");
            string currState = "1";
            string currTape= Tape[20];
            long len = test.Length;
            long TransitionCount = AllTransition.Count;
            int k = 20;
            for (int i = 0; i < len+20; i++)
            {
                for (int j = 0; j < TransitionCount; j++)
                {
                    if (AllTransition[j][0] == currState && AllTransition[j][1] == Tape[k])
                    {
                        currState = AllTransition[j][2];
                        Tape[k] = AllTransition[j][3];
                        if (AllTransition[j][4] == "1")
                        {
                            k--;
                            currTape = Tape[k];
                        }
                        else
                        {
                            k++;
                            currTape = Tape[k];
                        }
                        break;
                    }
                }
            }
            if (FinalState == currState)
                    return "Accepted";
            return "Rejected";
        }
        static void Main(string[] args)
        {
            string deltaTransitions = Console.ReadLine();
            long n = long.Parse(Console.ReadLine());
            string[] testStrings = new string[n];
            for (int i = 0; i < n; i++)
            {
                testStrings[i] = Console.ReadLine();
            }
            List<string[]> AllTransition = Decode(deltaTransitions);
            List<string> States = new List<string>();
            for (int i = 0; i < AllTransition.Count; i++)
            {
                States.Add(AllTransition[i][2]);
            }
            string FinalState = States.Max();
            List<string> result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                System.Console.WriteLine(TestOnTurinMachine(AllTransition, testStrings[i], FinalState));
            }
        }
    }
}
