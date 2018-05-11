using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public abstract class student
    {

        public void Test()
        {
            Console.WriteLine("---基类----普通方法---");
        }



        // 抽象方法没有方法体
        // 抽象方法声明必须在抽象类内
        // 派生类必须实现所有抽象方法
        public abstract void Abstract_Test();
        
        public abstract string Abstract_Test1();


        // 虚方法如果被重写调用的是派生类的虚方法
        // 虚方法如果没有被重写调用的是基类的虚方法
        // 虚方法必须要有方法体
        public virtual void Virtual_Test()
        {
            Console.WriteLine("---基类----虚方法---");

        }
        public virtual void Virtual_Test1()
        {
            Console.WriteLine("---基类----虚方法---");

        }
       // public virtual void Virtual_Test2();
        
    }
}
