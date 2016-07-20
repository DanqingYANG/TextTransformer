using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string test= "这次句号在中间试试．全角很重要．";
            for (int i = 0; i < 2;i++)
            {
                test = test + test;
            }
            Transformer t = new Transformer(test);
            Console.WriteLine();
            Console.Write(t.result);
        }
    }

    public class Transformer
    {
        public string result;
        private int count;
        private const int ROW    = 7;
        private const int COLUMN = 9;

        public Transformer(string text)
        {
            count = text.Length;
            int capacity = ROW * COLUMN;
            //check the length of input string, if longer than capacity, divide.
            if (count < capacity)
                transform(text);
            else
            {
                Console.Write("divide message");
                int components = (int)Math.Ceiling((double)count / capacity);
                for (int i = 0; i < components; i++)
                {
                    string textPart = text.Substring(i * capacity, capacity);
                    transform(textPart);
                }
            }
        }

        public void transform(string text)
        {
            List<string> inputStrList = new List<string>();
            //init charList
            for (int i = 0; i < count; i++)
            {
                inputStrList.Add(text.Substring(i, 1));
            }
            print(inputStrList);

            result = tranposMatrix(inputStrList);

            return;
        }

        private string tranposMatrix(List<string> list)
        {
            string[,] matrix = new string[ROW,COLUMN];
            for (int i = 0; i<ROW;i++)
            {
                for(int j= 0;j<COLUMN;j++)
                {
                    int currChar = i*COLUMN +j;
                    if (currChar < count)
                    {
                        matrix[i,j] = list[currChar];
                        Console.Write(matrix[i,j]);
                    }
                    else
                    {
                        string temp = "　";
                        matrix[i,j] = temp;
                    }
                    
                }
                Console.WriteLine();
            }
            
            List<string> outputStrList = new List<string>();
            Console.Write("\n test: \n");
            for (int i= 0; i<COLUMN;i++)
            {
                for (int j= ROW;j>0;j-- )
                {
                    outputStrList.Add(matrix[j-1,i]);
                    Console.Write(matrix[j - 1, i]+" ");
                }
                outputStrList.Add("\n");
                //Console.WriteLine();
            }
            
            return outPutString(outputStrList);
        }

        private string outPutString(List<string> l)
        {
            string s = "" ;
            for(int i = 0; i<l.Count(); i++)
            {
                s = s + l[i];
            }

            return s;
        }

        public void print(List<string> stringList)
        {
            for (int i = 0; i < stringList.Count; i++)
            {
                Console.Write(stringList[i]+" ");
            }
            Console.WriteLine();
        }

    }
}