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
                Console.WriteLine(Prims(fields, history));
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

                var res = Prims(fields, history);
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

                var res = Prims(fields, history);
                if (res > 0 && lastRes != res) {
                    Console.WriteLine($"{i}: {res}");
                }
                lastRes = res;
            }
        }

        public static int Prims(int fields, HashSet<int[]> history) {
            var length = 0;
            var visitedNodes = new HashSet<int> {1};
            var historyQueue = new HashSet<int[]>(history);
            for (var i = 1; i < fields; i++) {
                var connectedFields = historyQueue
                    .Where(t => visitedNodes.Contains(t[0]) ^ visitedNodes.Contains(t[1]));
                if (!connectedFields.Any()) {
                    break;
                }
                var closestConnectedField = connectedFields
                    .Aggregate((minWeight, item) => item[2] < minWeight[2] ? item : minWeight);
                historyQueue.Remove(closestConnectedField);
                visitedNodes.Add(
                    visitedNodes.Contains(closestConnectedField[0])
                        ? closestConnectedField[1]
                        : closestConnectedField[0]
                );
                length += closestConnectedField[2];
            }
            return visitedNodes.Count == fields ? length : -1;
        }
    }
}