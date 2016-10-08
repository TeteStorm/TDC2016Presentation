using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctions
{
    class Program
    {
        //Local Functions

        static void Main(string[] args)
        {
            void Local()
            {
                Console.WriteLine("Hello TDC");
            }
            Local();
            var result = Filter(new List<int> { 1, 2, 3 }, (x => x == 1));
            Console.WriteLine(result.FirstOrDefault());
            Console.ReadKey();

        }

        //São úteis num cenário como a utilização do IEnumerable (a checagem se está nula será postergada até sua execução)

        public static IEnumerable<T> Filter<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (filter == null) throw new ArgumentNullException(nameof(filter));


            IEnumerable<T> Iterator()
            {
                foreach (var element in source)
                {
                    if (filter(element)) { yield return element; }
                }
            }

            return Iterator();
        }
    }
}
