using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp
{
   

    // 多播委托


    delegate void CustomDel(string msg);   // 定义一个带参，返回值为空的委托
    public class delegate_test
    {
        // 为委托创建方法
        static void Hello(string s)
        {
            Console.WriteLine(" Hello ，{0}", s);
        }

        static void Goodbye(string s)
        {

             
            Console.WriteLine(" Goodbye ，{0}", s);
        }

        public void main()
        {
            // 调用委托

            CustomDel hiDel, byeDel, multiDel, multiDel1;

            hiDel = Hello;
            byeDel = Goodbye;
            multiDel = Hello + byeDel;
            multiDel1 = multiDel - Hello;

            Console.WriteLine("Invoking delegate hiDel:");
            hiDel("A");
            Console.WriteLine("Invoking delegate byeDel:");
            byeDel("B");
            Console.WriteLine("Invoking delegate multiDel:");
            multiDel("C");
            Console.WriteLine("Invoking delegate multiMinusHiDel:");
            multiDel1("D");

        }
    }
    

    /// <summary>
    ///  event 示例
    /// </summary>
    public class FileFoundArgs : EventArgs
    {
        public event EventHandler<FileFoundArgs> FileFound;
        public string FoundFile { get; }
        public bool CancelRequested { get; set; }

        public FileFoundArgs(string fileName)
        {
            FoundFile = fileName;
        }

        public void List(string dir, string searchPattern)
        {
            foreach (var file in Directory.EnumerateFiles(dir, searchPattern))
            {
                var args = new FileFoundArgs(file);
                FileFound?.Invoke(this, new FileFoundArgs(file));
                
            }
        }

    }

}
