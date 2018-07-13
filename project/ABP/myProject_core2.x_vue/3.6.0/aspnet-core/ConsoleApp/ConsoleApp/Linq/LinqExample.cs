using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp.Linq
{
    public class LinqExample : LinqBaseData
    {
        // Lambda 表达式中的变量范围
        delegate bool D();
        delegate bool D2(int i);

        D del;
        D2 del2;

        public void LinqConsole()
        {
            //Begin().Wait();
            //exmple();
            //study();

            //TestMethod(5);
            //bool result = del2(10);
            //Console.WriteLine(result);

            Expression<Func<int, int>> addFive = (num) => num + 5;
            //if (addFive.NodeType == ExpressionType.Lambda)
            //{
            //    var lambdaExp = (LambdaExpression)addFive;
            //    var Parameter = lambdaExp.Parameters.First();

            //    Console.WriteLine(Parameter.Name);
            //    Console.WriteLine(Parameter.Type);
            //}


            //var one = Expression.Constant(1, typeof(int));
            //var two = Expression.Constant(2, typeof(int));

            //var fun = addFive.Compile();
            //var answer = fun(4);
            var constant = 5;
            Expression<Func<int>> add = () => constant + 6;
            var func = add.Compile(); // 创建委托
            var answer2 = func(); // Invoke Delegate 调用委托
            //Console.WriteLine(answer2);

            // 检查不具有子级的表达式
            var constant1 = Expression.Constant(24, typeof(int));
            //Console.WriteLine($"{constant1.NodeType}");
            //Console.WriteLine($"{constant1.Type}");
            //Console.WriteLine($"{constant1.Value}");

            // 检查一个简单的加法表达式
            //Expression<Func<int, int, int>> addition = (a, b) => a + b;
            //Console.WriteLine($"Type: {addition.Type}");
            //Console.WriteLine($"NodeType: {addition.NodeType}");
            //Console.WriteLine($"Name: {addition.Name}");
            //Console.WriteLine($"ReturnType: {addition.ReturnType.ToString()}");
            //Console.WriteLine($"Count: {addition.Parameters.Count}");
            //foreach (var exp in addition.Parameters)
            //{
            //    Console.WriteLine($"Type: { exp.Type} Name: { exp.Name}");
            //}
            //var aitBody = (BinaryExpression)addition.Body;


            //Console.WriteLine($"NodeType: {aitBody.NodeType}");
            //Console.WriteLine($"Left.NodeType: {aitBody.Left.NodeType}");

            //var left = (ParameterExpression)aitBody.Left;
            //Console.WriteLine($"left.Type: {left.Type.ToString()}left.Name: {left.Name}");
            //Console.WriteLine($"aitBody.Right.NodeType: {aitBody.Right.NodeType}");


            // 生成表达式树
            Expression<Func<int>> sum = () => 3 + 4;
            // 创建节点,若要构造表达式树，必须构造叶节点。叶节点时常量，因此可以使用 Expression.Constant 方法创建节点

            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two); // 生成加法表达式
            var lambda = Expression.Lambda(addition); // 创建 Lambda 表达式
            Delegate dg = lambda.Compile(); // 编译表达式树得到委托

            // Console.WriteLine(dg.DynamicInvoke()); // 调用委托

            //var lambda1 = Expression.Lambda(
            //    Expression.Add(
            //        Expression.Constant(2, typeof(int)),
            //        Expression.Constant(3, typeof(int))
            //        )
            //    );

            // 生成树
            // 创建表达式树时创建的其他两个节点类型：参数节点和方法调用节点
            Expression<Func<double, double, double>> distanceCalc =
                (x, y) => Math.Sqrt(x * x + y * y);
            // 创建参数
            var xPara = Expression.Parameter(typeof(double), "x");
            var yPara = Expression.Parameter(typeof(double), "y");
            // 创建乘法和加法表达式
            var xSqu = Expression.Multiply(xPara, xPara); // Multiply 乘法运算符
            var ySqu = Expression.Multiply(yPara, yPara);


            var sum1 = Expression.Add(xSqu, ySqu);
            // 为调用 Math.Sqrt 创建方法调用表达式
            var sqrtMethod = typeof(Math).GetMethod("Sqrt", new[] { typeof(double) });
            var distance = Expression.Call(sqrtMethod, sum1);
            // 将方法调用放入 Lambda 表达式, 并确保定义Lambda表达式参数
            var distanceLambda = Expression.Lambda(
               distance,
               xPara,
               yPara
                );

            //Delegate dg1 = distanceLambda.Compile(); // 编译表达式树得到委托
            //var invo = dg1.DynamicInvoke(1, 2);       // 调用委托
            //Console.WriteLine(invo);


            // 深度生成代码
            Func<int, int> factorialFunc = (n) =>
             {
                 var res = 1;
                 while (n > 1)
                 {
                     res = res * n;
                     n--;
                 }
                 return res;
             };

            var nArgument = Expression.Parameter(typeof(int), "n");
            var result = Expression.Variable(typeof(int), "result");
            // 创建表示返回值的标签
            LabelTarget lable = Expression.Label(typeof(int));

            var initializeResult = Expression.Assign(result, Expression.Constant(1));

            // 这是执行乘法内部块，并且减去 n 的值
            var block = Expression.Block(
                    Expression.Assign(result,
                        Expression.Multiply(result, nArgument)),
                    Expression.PostDecrementAssign(nArgument)
                );

            // 创建一个方法主体
            BlockExpression body = Expression.Block(
                new[] { result },
                initializeResult,
                Expression.Loop(
                    Expression.IfThenElse(
                        Expression.GreaterThan(nArgument, Expression.Constant(1)),
                        block,
                        Expression.Break(lable, result)
                        ),
                        lable)
                  );


            var lambda5 = Expression.Lambda(body, nArgument); // 创建 Lambda 表达式
            Delegate dg5 = lambda5.Compile();
            //Console.WriteLine(dg5.DynamicInvoke(3));

            int it = 42;
            System.Type type = it.GetType();
            //System.Console.WriteLine(type);






































            Console.WriteLine();


        }






        public void TestMethod(int ipt)
        {
            int j = 0;
            del = () => { j = 10; return j > ipt; };
            del2 = (x) => { return x == j; };
            Console.WriteLine("j={0}", j);
            bool boolResult = del();
            Console.WriteLine("j={0},b={1}", j, boolResult);

        }











        private static async Task Begin()
        {
            for (int c = 2; c <= 5; c++)
            {
                var result = await showSquares(c);
                Console.WriteLine("{0}+{0}={1}", c, result);
            }
        }

        private static async Task<int> showSquares(int number)
        {
            return await Task.Factory.StartNew(x => (int)x * (int)x, number);
        }



        public void exmple()
        {
            // https:// code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
            #region Projection Operators

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
            //foreach (Student s in stl)
            //{

            //    foreach (Scores t in s.Scores)
            //    {

            //        Console.WriteLine( "  " + i + "  " + t.id + "  " + t.ScoresName + "  " + t.score);
            //    }
            //    i++;
            //}

            #endregion


            #region Partitioning Operators

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
            //foreach (var n in ex25)
            //Console.WriteLine(n);

            #endregion

            #region Ordering Operators

            // OrderBy - Comparer
            // 此示例使用一个带有自定义比较器的OrderBy子句，对数组中的单词进行区分大小写的排序
            var ex27 = arrNum.OrderBy(a => a, new CaseInsensitiveComparer());
            //foreach (var n in ex27)
            //    Console.WriteLine(n);


            // ThenBy 组合排序
            var ex28 = from d in arrNum
                       orderby d.Length, d
                       select d;
            //foreach (var n in ex28)
            //    Console.WriteLine(n);


            var ex29 = arrNum.OrderBy(a => a.Length)
                             .ThenBy(a => a, new CaseInsensitiveComparer());
            var ex291 = arrNum.OrderBy(a => a.Length)
                                .ThenBy(a => a);
            //foreach (var n in ex29)
            //    Console.WriteLine(n);


            // Reverse 相反
            var ex30 = (from d in arrNum
                        where d[1] == 'i'
                        select d)
                         .Reverse();
            //foreach (var n in ex30)
            //    Console.WriteLine(n);






            #endregion

            #region Grouping Operators

            string[] anagrams = { "from", "salt", "earn", "last", "near", "form", "ormf" };
            var ex31 = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer());
            //foreach (var p in ex31)
            //  Console.WriteLine(p);
            #endregion

            #region Set Operators

            // Union 并集
            var ex32 = numbers.Union(numbers1);
            //Intersect 交集
            var ex33 = numbers.Intersect(numbers1);
            //Except 除了,非交集
            var ex34 = numbers1.Except(numbers);
            //foreach (var p in ex34)
            //    Console.WriteLine(p);

            #endregion

            #region Conversion Operators
            object[] test35 = { null, 2.1, "two", "4our", 1, 2 };

            var ex35 = test35.OfType<int>();
            //foreach (var p in ex35)
            //    Console.WriteLine(p);

            #endregion

            #region  Element Operators 

            /// Element Operators
            int ex36 = (from n in numbers
                        where n >= 5
                        select n).ElementAt(1);

            //Console.WriteLine(ex36);


            /// Generation Operators

            // range(10.20) 生成10后面的20个数字
            var ex37 = from n in Enumerable.Range(10, 20)
                       select n;
            //foreach (var p in ex37)
            //    Console.WriteLine(p);
            // repeat(3,10) 生成3 重复十次

            /// Quantifiers
            bool ex38 = arrNum.Any(n => n.Contains("one"));
            //Console.WriteLine(ex38);
            var ex39 = from s in stl
                       group s by s.remark into g
                       where g.Any(p => p.id > 1)
                       select new { ke = g.Key, stu = g };
            //foreach (var p in ex39)
            //    Console.WriteLine(p.ke + " " + p.stu.Count());

            // All 确定所有元素是否满足条件
            int[] test40 = { 1, 11, 21 };
            var ex40 = test40.All(n => n % 2 == 1);
            //Console.WriteLine(ex40);
            #endregion

            #region Aggregate Operators
            var ex41 = numbers.Count(n => n % 2 == 1);
            var ex42 = numbers.Count(n => n > 3);
            // Console.WriteLine(ex42);

            var ex43 = from p in stl
                       select new { p.name, socreCnt = p.scores.Count() };
            //foreach (var p in ex43)
            //    Console.WriteLine(p.name+" "+p.socreCnt);

            // SUM MIN MAX AVERAGE

            // Aggregate  
            // cutNumAccum 累积值
            double[] test44 = { 2, 3, 4, 3, 1 };
            var ex44 = test44.Aggregate((cutNumAccum, nextNum) => cutNumAccum * nextNum);
            //Console.WriteLine(ex44);

            double test45 = 100;
            var ex45 = test44.Aggregate(test45,
                    (cutNumAccum, nextNum) =>
                            ((nextNum <= cutNumAccum) ? (cutNumAccum - nextNum) : test45));
            //Console.WriteLine(ex45);


            #endregion

            #region Miscellaneous Operators

            // concat 连接两个字符串
            var ex46 = numbers.Concat(numbers1);
            //foreach (var p in ex46)
            //    Console.WriteLine(p);

            // SequenceEqual 序列相等
            var ex47 = numbers.SequenceEqual(numbers1);
            //Console.WriteLine(ex47);



            #endregion

            #region Custom Sequence Operators

            // concat 连接两个字符串
            // var ex46 = numbers.Concat(numbers1);
            //foreach (var p in ex46)
            //    Console.WriteLine(p);





            #endregion


            #region Query Execution 查询执行

            // 下面的示例展示了如何在循环语句中枚举查询之前如何延迟查询执行
            // 序列运算符形成第一个查询，直到枚举他们才执行
            // 注意，在计算每个元素之前，局部变量i增加（作为副作用） 



            int test48 = 0;
            var ex48 = from n in numbers
                       select ++test48;

            //foreach (var v in ex48)
            //{
            //    Console.WriteLine(test48 + "----" + v);
            //}

            // 方法如ToList() 导致查询立即执行，缓存结果
            // 在迭代结果之前，局部变量i 已经被完全递增

            int test49 = 0;
            var ex49 = (from n in numbers
                        select ++test49).ToList();
            //foreach (var v in ex49)
            //{
            //    Console.WriteLine(v + " ---- " + test49);
            //}

            // 延迟执行允许我们定义一次查询，然后再数据更改之后再使用它
            // 再第二次运行期间，同一个查询对象，Lowort ,将迭代心的数字状态[]
            //  产生不同的结果
            var ex50 = from n in numbers
                       where n <= 3
                       select n;
            //foreach (var v in ex50)
            //{
            //    Console.WriteLine(v);
            //}

            //Console.WriteLine("------------");
            //for ( int i = 0; i < 10; i++)
            //{
            //    numbers[i] = -numbers[i];
            //}

            //Console.WriteLine("------------");
            //foreach(int n in ex50)
            //{
            //    Console.WriteLine(n);
            //}



            #endregion


            #region  Join Operators

            #endregion
        }

        public void study()
        {
            // group 
            var group = from l in stl
                        group l by l.name[0] into g
                        orderby g.Key
                        select g;

            // let, 使用let子句可将表达式（如方法调用）的结果存储再新范围变量中
            var let = from l in stl
                      let frt = l.name.Split(",")[1]
                      select frt;

            string[] strings =
        {
            "AB penny saved is a penny earned.",
            "THhe early bird catches the worm.",
            "The pen is mightier than the sword."
        };
            var qu1 = from st in strings
                      let words = st.Split(' ')
                      from word in words
                      let w = word.ToLower()
                      where w[0] == 'a' || w[0] == 'p' || w[0] == 't'
                      select w;




            // lookup
            // 类似字典，不可修改
            var quert = stl.ToLookup(n => n.id);

            // 对查询结果进行分祖
            var q0 = from s in stl
                     group s by s.name[0];

            //foreach(var g in q0)
            //{
            //    Console.WriteLine($"key:{g.Key}");
            //    foreach(var st in g)
            //    {
            //        Console.WriteLine($"Name:{st.name}");
            //    }
            //}

            var q01 = from s in stl
                      let avgSco = GetPercentile(s)
                      group new { s.name, s.remark } by avgSco into sg
                      orderby sg.Key
                      select sg;

            //foreach (var g in q01)
            //{
            //    Console.WriteLine($"key:{g.Key}");
            //    foreach (var st in g)
            //    {
            //        Console.WriteLine($"Name:{st.name}");
            //    }
            //}




            //  简单键联接
            var q1 = from stu in stl
                     join s in sList on stu.SchName equals s
                     select new { stuName = stu.name, schName = s.sName };

            var q2 = from stu in stl
                     join g in gList on stu.gId equals g.id
                     select new { stuName = stu.name, schName = g.gName };
            // 复合键联接
            var q3 = from stu in stl
                     join g in gList
                     on new { Id = stu?.gId ?? 0 }
                     equals new { Id = g.id }
                     select stu;
            var q3a = from stu in stl
                      join g in gList
                      on new { Id = stu.gId }
                      equals new { Id = g?.id }
                      select stu;
            var q3b = from stu in stl
                      join g in gList
                      on new { Id = stu.gId }
                      equals new { Id = (int?)g.id }
                      select stu;


            // 分组联接
            var q4 = from stu in stl
                     join s in sList on stu.SchName equals s into t
                     select new { ownerName = stu.name, ss = t };

            XElement q5 = new XElement("ower",
                 from stu in stl
                 join s in sList on stu.SchName equals s into t
                 select new XElement("person",
                    new XAttribute("ownerName", stu.name),
                    from sc in t
                    select new XElement("schName", sc.sName)));
            //Console.WriteLine(q5);
            // 左外部联接
            var q6 = from stu in stl
                     join s in sList on stu.SchName equals s into t
                     from sub in t.DefaultIfEmpty()
                     select new { stu.name, sch = sub?.sName ?? string.Empty };


            var q7 = from s in stl
                     where s != null
                     join g in gList on s.gId equals g.id
                     select new { s.name, g.gName };


        }


        protected static int GetPercentile(Student s)
        {
            double avg = s.scores.Average(p => p.score);
            return avg > 0 ? (int)avg / 10 : 0;
        }
    }




    //public static class CustomSequenceOperators
    //{
    //    // ,Func func
    //    public static IEnumerable Combine(this IEnumerable first, IEnumerable second , Func<T> func)
    //    {
    //        using (IEnumerator e1 = first.GetEnumerator(), e2 = second.GetEnumerator())
    //        {
    //            while (e1.MoveNext() && e2.MoveNext())
    //            {
    //                yield return func(e1.Current, e2.Current);
    //            }
    //        }
    //    }
    //}


    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return getCanonicalString(x) == getCanonicalString(y);
        }
        public int GetHashCode(string obj)
        {
            return getCanonicalString(obj).GetHashCode();
        }

        public string getCanonicalString(string word)
        {
            char[] wordChars = word.ToCharArray();
            Array.Sort<char>(wordChars);
            return new string(wordChars);
        }



    }

}
