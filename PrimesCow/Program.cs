using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimesCow {
    internal class Program {
        private static readonly List<Tuple<int, int, int>> Inputs = new List<Tuple<int, int, int>> {
            new Tuple<int, int, int>(1, 2, 10),
            new Tuple<int, int, int>(1, 3, 8),
            new Tuple<int, int, int>(3, 2, 3),
            new Tuple<int, int, int>(1, 4, 3),
            new Tuple<int, int, int>(1, 3, 6),
            new Tuple<int, int, int>(2, 1, 2)
        };

        private static Random Random = new Random();

        public static void Main(string[] args) {
//            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            var fields = input[0];
//            var weeks = input[1];
//            var history = new List<Tuple<int, int, int>>();
//
//            for (var i = 0; i < weeks; i++) {
//                input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//                history.Add(new Tuple<int, int, int>(input[0], input[1], input[2]));
//                Console.WriteLine(Prims(fields, history));
//            }

            var fields = 200;
            var weeks = 6000;
            var history = new HashSet<Tuple<int, int, int>>();
            var lastRes = 0;
            for (var i = 0; i < weeks; i++) {
                history.Add(new Tuple<int, int, int>(Random.Next(1, fields + 1), Random.Next(1, fields + 1),
                    Random.Next(1, 100)));

                var res = Prims(fields, history);
                if (res > 0 && lastRes != res) {
                    Console.WriteLine($"{i}: {res}");
                }
                lastRes = res;
            }
            Console.WriteLine("Finished");

//            var fields = 4;
//            var weeks = Inputs.Count;
//            var history = new HashSet<Tuple<int, int, int>>();
//
//            for (var i = 0; i < weeks; i++) {
//                history.Add(Inputs[i]);
//
//                var res = Prims(fields, history);
//                Console.WriteLine($"{i}: {res}");
//            }
//            Console.WriteLine("Finished");
        }

        public static int Prims(int fields, HashSet<Tuple<int, int, int>> history) {
            var length = 0;
            var visitedNodes = new HashSet<int> {1};
            var historyQueue = new HashSet<Tuple<int, int, int>>(history);
            for (var i = 1; i < fields; i++) {
                var connectedFields = historyQueue
                    .Where(t => visitedNodes.Contains(t.Item1) ^ visitedNodes.Contains(t.Item2));
                if (!connectedFields.Any()) {
                    break;
                }
                var closestConnectedField = connectedFields
                    .Aggregate((minWeight, item) => item.Item3 < minWeight.Item3 ? item : minWeight);
                historyQueue.Remove(closestConnectedField);
                visitedNodes.Add(visitedNodes.Contains(closestConnectedField.Item1)
                    ? closestConnectedField.Item2
                    : closestConnectedField.Item1
                );
                length += closestConnectedField.Item3;
            }
            return visitedNodes.Count == fields ? length : -1;
        }
    }
}