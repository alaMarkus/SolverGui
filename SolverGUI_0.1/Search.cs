using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace SolverGUI_0._1
{
    class Search
    {
        private string Word;
        private List<string> found;
        private int retval;

        public Search()
        {
            found = new List<string>();
            //Word = File.ReadAllText(@"C:\Users\Marku\source\repos\SolverGUI_0.1\SolverGUI_0.1\sanalista.txt");
            Word = Properties.Resources.sanalista;
        }

        public List<string> getFound()
        {
            return found;
        }

        public int getRetval()
        {
            return retval;
        }

        public string getLatesFound()
        {
            return found.Last<string>();
        }

        public int find(string toSearch)
        {
            if (Word.Contains("<s>" + toSearch))
            {
                retval = 1;
                if (Word.Contains("<s>" + toSearch + "</s>"))
                {
                    //System.out.println("found word: "+toSearch);
                    if (found.Contains(toSearch)==false)
                    {
                        Console.WriteLine("found word: " + toSearch);
                        found.Add(toSearch);
                        retval = 2;
                    }
                }
                
            }
            else
            {
                retval = 0;
            }
            //Console.WriteLine(retval);
            return retval;
        }
    }
}
