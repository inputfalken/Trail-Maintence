using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PrimesCow;

namespace Test {
    [TestFixture]
    public class Tests {
        [Test]
        public void Graph_Size_8_Required_Node_Connections_5() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8},
                new[] {3, 2, 3},
                new[] {1, 4, 3},
                new[] {1, 3, 6},
                new[] {2, 1, 2},
                new[] {1, 4, 1},
                new[] {1, 5, 1}
            };
            const int minConnections = 5;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void Graph_Size_7_Required_Node_Connections_5() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8},
                new[] {3, 2, 3},
                new[] {1, 4, 3},
                new[] {1, 3, 6},
                new[] {2, 1, 2},
                new[] {1, 4, 1}
            };
            const int minConnections = 5;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Graph_Size_7_Required_Node_Connections_4() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8},
                new[] {3, 2, 3},
                new[] {1, 4, 3},
                new[] {1, 3, 6},
                new[] {2, 1, 2},
                new[] {1, 4, 1}
            };
            const int minConnections = 4;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Graph_Size_6_Required_Node_Connections_4() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8},
                new[] {3, 2, 3},
                new[] {1, 4, 3},
                new[] {1, 3, 6},
                new[] {2, 1, 2}
            };
            const int minConnections = 4;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Graph_Size_5_Required_Node_Connections_4() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8},
                new[] {3, 2, 3},
                new[] {1, 4, 3},
                new[] {1, 3, 6}
            };
            const int minConnections = 4;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Graph_Size_4_Required_Node_Connections_4() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8},
                new[] {3, 2, 3},
                new[] {1, 4, 3}
            };
            const int minConnections = 4;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(14, result);
        }

        [Test]
        public void Graph_Size_3_Required_Node_Connections_4() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8},
                new[] {3, 2, 3}
            };
            const int minConnections = 4;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Graph_Size_2_Required_Node_Connections_4() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10},
                new[] {1, 3, 8}
            };
            const int minConnections = 4;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Graph_Size_1_Required_Node_Connections_4() {
            var graph = new HashSet<int[]> {
                new[] {1, 2, 10}
            };
            const int minConnections = 4;
            var result = Algorithm.Prims(minConnections, graph);
            Assert.AreEqual(-1, result);
        }
    }
}