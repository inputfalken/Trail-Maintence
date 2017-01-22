using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimesCow {
    internal class Program {
        public static void Main(string[] args) {
            RandomInput();
            Console.WriteLine("Finished");
        }

        private static void UserInput() {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var fields = input[0];
            var weeks = input[1];
            var history = new HashSet<int[]>();

            for (var i = 0; i < weeks; i++) {
                input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                history.Add(new[] {input[0], input[1], input[2]});
                Console.WriteLine(Algorithm.Prims(fields, history));
            }
        }

        private static void AssignmentExampleInput() {
            var inputs = new List<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8},
                new[] {3, 2, 3},
                new[] {1, 4, 3},
                new[] {1, 3, 6},
                new[] {2, 1, 2}
            };
            const int fields = 4;
            var weeks = inputs.Count;
            var history = new HashSet<int[]>();

            for (var i = 0; i < weeks; i++) {
                history.Add(inputs[i]);

                var res = Algorithm.Prims(fields, history);
                Console.WriteLine($"{i}: {res}");
            }
        }


        private static void RandomInput() {
            var random = new Random();
            const int fields = 200;
            const int weeks = 6000;
            var history = new HashSet<int[]>();
            var lastRes = 0;
            for (var i = 0; i < weeks; i++) {
                history.Add(new[] {
                    random.Next(1, fields + 1),
                    random.Next(1, fields + 1),
                    random.Next(1, 100)
                });

                var res = Algorithm.Prims(fields, history);
                if (res > 0 && lastRes != res) {
                    Console.WriteLine($"{i}: {res}");
                }
                lastRes = res;
            }
        }
    }
}