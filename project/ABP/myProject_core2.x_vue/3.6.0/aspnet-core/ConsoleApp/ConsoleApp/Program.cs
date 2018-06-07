using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            #region 参数委托约束
            if (1 > 3)
            {

                var map = Test2.EnumNameValues<RainBow>();

                foreach (var pair in map)
                    Console.WriteLine($"{pair.Key}:\t{pair.Value}");





            }
            #endregion

            #region 泛型接口

            if (1 > 3)
            {

                //Person is the type argument.
                SortedList<Person> list = new SortedList<Person>();

                //Create name and age values to initialize Person objects.
                string[] names = new string[] { "a", "b", "c" };

                int[] ages = new int[] { 1, 2, 3 };

                //Populate the list.
                for (int x = 0; x < 3; x++)
                {
                    list.AddHead(new Person(names[x], ages[x]));
                }

                //Print out unsorted list.
                foreach (Person p in list)
                {
                    System.Console.WriteLine(p.ToString());
                }
                System.Console.WriteLine("Done with unsorted list");

                //Sort the list.
                list.BubbleSort();

                //Print out sorted list.
                foreach (Person p in list)
                {
                    System.Console.WriteLine(p.ToString());
                }
                System.Console.WriteLine("Done with sorted list");




            }
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
            if (1 > 3)
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

            #region 运算符

            if (1 > 3)
            {

                string[] arrNum = { "zero", "one", "two", "three", "four", "five", "six", "seven" };

                var shortDig = arrNum.Where((a, index) => a.Length < index);

                foreach (var sd in shortDig)
                {
                    Console.WriteLine(sd);
                }

            }


            #endregion

            #region 迭代器
            if (1 > 3)
            {
                DaysOfTheWeek week = new DaysOfTheWeek();
                foreach (string day in week)
                {
                    Console.WriteLine(day + " _ ");
                }

            }

            #endregion

            #region Linq
            if (1 > 3)
            {

                List<students> stl = new List<students>();
                students stu = new students();
                stu.id = 1;
                stu.name = "aa,a";
                stu.remark = "中国";
                stl.Add(stu);

                stu = new students();
                stu.id = 2;
                stu.name = "ab,b";
                stu.remark = "啊打发";
                stl.Add(stu);

                stu = new students();
                stu.id = 3;
                stu.name = "ba,c";
                stu.remark = "认我为";
                stl.Add(stu);

                stu = new students();
                stu.id = 4;
                stu.name = "bb,c";
                stu.remark = "认我按时发为";
                stl.Add(stu);

                stu = new students();
                stu.id = 2;
                stu.name = "bc,b";
                stu.remark = "而微软";
                stl.Add(stu);



                // group 
                var group = from l in stl

                            group l by l.name[0] into g

                            orderby g.Key
                            select g;

                // let 
                var let = from l in stl
                          let frt = l.name.Split(",")[1]
                          select frt;

                // lookup
                var quert = stl.ToLookup(n => n.id);




            }
            if (6 > 3)
            {

                #region 基础数据

                List<scores> list = new List<scores>();
                scores s1 = new scores(1, "语文", 11);
                list.Add(s1);
                scores s2 = new scores(2, "英语", 12);
                list.Add(s2);
                scores s3 = new scores(3, "数学", 13);
                list.Add(s3);

                List<scores> list1 = new List<scores>();
                scores q1 = new scores(1, "语文", 21);
                list1.Add(q1);
                scores q2 = new scores(2, "英语", 22);
                list1.Add(q2);
                scores q3 = new scores(3, "数学", 23);
                list1.Add(q3);

                List<scores> list2 = new List<scores>();
                scores w1 = new scores(1, "语文", 31);
                list2.Add(w1);
                scores w2 = new scores(2, "英语", 32);
                list2.Add(w2);
                scores w3 = new scores(3, "数学", 33);
                list2.Add(w3);


                List<scores> list3 = new List<scores>();
                scores e1 = new scores(1, "语文", 41);
                list3.Add(e1);
                scores e2 = new scores(2, "英语", 42);
                list3.Add(e2);
                scores e3 = new scores(3, "数学", 43);
                list3.Add(e3);


                List<students> stl = new List<students>();
                students stu = new students();
                stu.id = 1;
                stu.name = "aa,a";
                stu.remark = "中国";
                stu.scores = list;
                stl.Add(stu);

                stu = new students();
                stu.id = 2;
                stu.name = "ab,b";
                stu.remark = "啊打发";

                stu.scores = list1;
                stl.Add(stu);

                stu = new students();
                stu.id = 3;
                stu.name = "ba,c";
                stu.remark = "认我为";
                stu.scores = list2;
                stl.Add(stu);

                stu = new students();
                stu.id = 4;
                stu.name = "bb,c";
                stu.remark = "认我按时发为";
                stu.scores = list3;
                stl.Add(stu);

                #endregion


                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                int[] numbers1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
                string[] arrNum = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


                // index
                var ex1 = arrNum.Where((d, index) => d.Length < index);
                //foreach (var p in ex1)
                //    Console.WriteLine(p);


                // select-transformation 选择转化
                var ex2 = from n in numbers
                          select arrNum[n];
                //foreach (var p in ex2)
                //    Console.WriteLine(p);


                // select-Anonymous types 匿名类型
                var ex3 = from n in numbers
                          select new { d = arrNum[n], even = (n % 2 == 0) };
                //foreach (var p in ex3)
                //    Console.WriteLine(p.d + " " + p.even);


                // select - indexed
                var ex4 = numbers.Select((n, index) => new { num = n, inPlace = (n == index) });
                //foreach (var p in ex4)
                //    Console.WriteLine(p.num + " " + p.inPlace);


                // selectMany- compound from 1
                var ex5 =
                       from a in numbers
                       from b in numbers1
                       where a < b
                       select new { a, b };
                //foreach (var p in ex5)
                //    Console.WriteLine(p.a + " " + p.b);

                var ex6 =
                  from a in numbers
                  from b in numbers1
                  where a < 2
                  select new { a, b };
                //foreach (var p in ex6)
                //    Console.WriteLine(p.a + " " + p.b);


                // selectMany - indexed  "custindex " +  custindex + " score " +
                var ext7 = stl.SelectMany((cust, custindex) => cust.scores.Select(o => custindex + "  " + o.id + "  " + o.scoresName + "  " + o.score));

                //foreach (var p in ext7)
                //    Console.WriteLine(p);

                //int i = 0;
                //foreach (students s in stl)
                //{

                //    foreach (scores t in s.scores)
                //    {

                //        Console.WriteLine( "  " + i + "  " + t.id + "  " + t.scoresName + "  " + t.score);
                //    }
                //    i++;
                //}



                // Take 采取
                // 获取数组前三个元素
                var ex21 = numbers.Take(3);
                // foreach(var n in ex21)
                // Console.WriteLine(n);

                // Skip 跳过 
                // 跳过前5个
                var ex22 = numbers.Skip(5);

                // TakeWhile，获取小于6的
                //获取， 依次获取小于6的,大于6的停止循环获取
                var ex23 = numbers.TakeWhile(n => n < 6);
                // foreach (var n in ex23)
                // Console.WriteLine(n);


                // 5, 4, 1, 3, 9, 8, 6, 7, 2, 0
                // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9

                var ex24 = numbers.TakeWhile((n, index) => n >= index);
                //foreach (var n in ex24)
                //    Console.WriteLine(n);


                //跳过， 获取第一个大于6后面的所有序列
                var ex25 = numbers.SkipWhile(n => n < 6);
                //foreach (var n in ex25)
                //Console.WriteLine(n);

                // 5, 4, 1, 3, 9, 8, 6, 7, 2, 0
                // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
                var ex26 = numbers.SkipWhile((n, index) => n >= index);
                 foreach (var n in ex25)
                 Console.WriteLine(n);

            }
            #endregion

            Console.ReadLine();

        }

        [Required(AllowEmptyStrings = true)]
        public string AccTitleCode { get; set; }

    }

    public class students
    {
        public int id;
        public string name;
        public string remark;
        public List<scores> scores;
    }

    public class scores
    {
        public scores(int id, string name, int score)
        {
            this.id = id;
            scoresName = name;
            this.score = score;
        }
        public int id;
        public string scoresName;
        public int score;
    }

    public static class Test
    {
        //public static TDelegate TypeSafeCombine<TDelegate>(this TDelegate source, TDelegate target)
        //   where TDelegate : System.Delegate
        // => Delegate.Combine(source, target) as TDelegate;
        //  https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters

    }

    enum RainBow
    {
        red,
        orange,
        yellow,
        green,
        blue
    }
    public static class Test2
    {
        public static Dictionary<int, string> EnumNameValues<T>() where T : System.Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(T), item));
            return result;
        }
    }




}
