using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var provider = new DefaultObjectPoolProvider();
            var policy = new StringBuilderPooledObjectPolicy();
            var pool = provider.Create(policy);


            var stringBuilder = pool.Get();
            stringBuilder.Append("hello");
            stringBuilder.Append("world");
            Console.WriteLine(stringBuilder.ToString());
            pool.Return(stringBuilder);

            var stringBuilder2 = pool.Get();
            stringBuilder2.Append("bye");
            Console.WriteLine(stringBuilder2.ToString());
            pool.Return(stringBuilder2);
            Console.ReadKey();
        }
    }
}
