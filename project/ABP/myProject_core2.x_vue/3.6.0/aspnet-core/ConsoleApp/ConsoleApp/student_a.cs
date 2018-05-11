using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class student_a : student
    {

        private int age;
        public void setAge(int age)
        {
            this.age = age;
        }
        public int getAge()
        {

            return age;
        }

        // 私有字段，外键无法访问
        private string name;
        //公共属性
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        //public void Test1()
        //{
        //    Console.WriteLine("-----重新test1------");
        //}

        public override void Abstract_Test()
        {

            Console.WriteLine("-----抽象方法--重写----test()------");
        }


        public override string Abstract_Test1()
        {

            Console.WriteLine("-----抽象方法--重写----test2()------");
            return "";
        }

        public override void Virtual_Test1()
        {
            Console.WriteLine("---基类----虚方法已经被子类重写---");

        }
    }
}
