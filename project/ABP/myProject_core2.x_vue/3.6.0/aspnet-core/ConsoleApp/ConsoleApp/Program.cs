using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            student_a entity1 = new student_a();

            #region 字段属性，抽象方法，虚方法

            //entity1.Test(); // 普通方法
            //entity1.Abstract_Test(); // 抽象方法 
            //entity1.Abstract_Test1(); // 抽象方法

            //entity1.Virtual_Test();// 虚方法
            //entity1.Virtual_Test1();// 重写虚方法

            // entity1.Name = "北京欢迎你";
            // Console.WriteLine(entity1.Name);

            //entity1.setAge(11);
            //Console.WriteLine(entity1.getAge().ToString());

            #endregion

            #region  委托

            //delegate_test dt = new delegate_test();
            //dt.main();

            #endregion

            #region 泛型

            #region ArrayList
            //System.Collections.ArrayList list = new System.Collections.ArrayList();
            //// Add an integer to the list.
            //list.Add(3);
            //// Add a string to the list. This will compile, but may cause an error later.
            //list.Add("It is raining in Redmond.");

            //int t = 0;
            //// This causes an InvalidCastException to be returned.
            //foreach (int x in list)
            //{
            //    t += x;
            //}

            //List<int> listtt = new List<int> {1,2,3,4,5 };

            #endregion




            #endregion


            #region 元组
            if (1 > 3)
            {
                var ToString = "This is some text";
                var one = 1;
                var Item1 = 5;
                var projections = (ToString, one, Item1);
                // Accessing the first field:
                Console.WriteLine(projections.Item1);
                //Console.WriteLine(projections.ToStrings);
                // There is no semantic name 'ToString'
                // Accessing the second field:
                Console.WriteLine(projections.one);
                Console.WriteLine(projections.Item2);
                // Accessing the third field:
                Console.WriteLine(projections.Item3);
                // There is no semantic name 'Item`.

                var pt1 = (X: 3, Y: 0);
                var pt2 = (X: 3, Y: 4);

                var xCoords = (pt1.X, pt2.X);
                // There are no semantic names for the fields
                // of xCoords. 

                // Accessing the first field:
                Console.WriteLine(xCoords.Item1);
                // Accessing the second field:
                Console.WriteLine(xCoords.Item2);
            }
            if (1> 3)
            {
                // The 'arity' and 'shape' of all these tuples are compatible. 
                // The only difference is the field names being used.
                var unnamed = (42, "The meaning of life");
                var anonymous = (16, "a perfect square");
                var named = (Answer: 42, Message: "The meaning of life");
                var differentNamed = (SecretConstant: 42, Label: "The meaning of life 123456");

               
                unnamed = named;
               //  Console.WriteLine($"{unnamed.Item1}, {unnamed.Message}");

                named = unnamed;
                // 'named' still has fields that can be referred to
                // as 'answer', and 'message':
                Console.WriteLine($"{named.Answer}, {named.Message}");

                // unnamed to unnamed:
                anonymous = unnamed;

                // named tuples.
                named = differentNamed;
                // The field names are not assigned. 'named' still has 
                // fields that can be referred to as 'answer' and 'message':
                Console.WriteLine($"{named.Answer}, {named.Message}");
                (long, string) conversion = named;

                Console.WriteLine($"{conversion.Item1}, {conversion.Item2}");
            }

            #endregion


            #region

            if (1 > 3)
            {

                string[] arrNum = { "zero", "one", "two", "three", "four", "five", "six", "seven" };
             
                var shortDig = arrNum.Where((a,index) => a.Length < index);

                foreach ( var sd in shortDig)
                {
                    Console.WriteLine(sd);
                }

            }
             

            #endregion 



            Console.ReadLine();

        }
    }
}
