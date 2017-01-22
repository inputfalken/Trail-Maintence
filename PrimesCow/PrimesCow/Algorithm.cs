using System.Collections.Generic;
using System.Linq;

namespace PrimesCow {
    public static class Algorithm {
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