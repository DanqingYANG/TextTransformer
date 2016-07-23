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
            string text= "有时候竖着也是不错的选择．";
            for (int i = 0; i < 0;i++)
            {
                text = text + text;
            }
            Transformer t = new Transformer();
            t.transform(text);
            Console.WriteLine();
            Console.Write(t.result);
        }
    }

    public class Transformer
    {
        public string result;
        private string text;
        private int count;
        private int row;
        private int column;

        public Transformer()
        {
            count = 0;
        }

        public void setBlockSize(int row, int column)
        {
            this.row = row;
            this.column = column;
            transpose();
        }

        public void transform(string input)
        {
            this.text = input;
            count = input.Length;
            transpose();
        }

        public void transpose()
        {
            text = replaceSymbol(text);
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

        private string replaceSymbol(string word)
        {
            if(word!=null)
            word = word.Replace(',', '，')
                .Replace('.', '．')
                .Replace(':', '：')
                .Replace(';', '；')
                .Replace('?', '？')
                .Replace('1', '１')
                .Replace('2', '２')
                .Replace('3', '３')
                .Replace('4', '４')
                .Replace('5', '５')
                .Replace('6', '６')
                .Replace('7', '７')
                .Replace('8', '８')
                .Replace('9', '９')
                .Replace('0', '０');
            return word;
        }

        private string tranposMatrix(List<string> list)
        {
            string[,] matrix = new string[row,column];
            for (int i = 0; i<row;i++)
            {
                for(int j= 0;j<column;j++)
                {
                    int currChar = i*column +j;
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
            for (int i= 0; i<column;i++)
            {
                for (int j= row;j>0;j-- )
                {
                    outputStrList.Add(matrix[j-1,i]+" ");

                    Console.Write(matrix[j - 1, i]+" ");
                }
                outputStrList.Add("\n");
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