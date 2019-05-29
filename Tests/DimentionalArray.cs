using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace DimentionalArray
{
    using NS = Utils.Dimentional;
    namespace Distance
    {
        [TestClass]
        public class Little
        {
            [TestMethod]
            public void DijkstraFrom0() => NS.ExecDijkstra(0);

            [TestMethod]
            public void DijkstraFrom2() => NS.ExecDijkstra(2);

            [TestMethod]
            public void DijkstraRandomGraph() => NS.ExecDijkstra(0, 6, 10);
        };


        [TestClass]
        public class Big
        {
            [TestMethod]
            public void DijkstraRandomGraph() => NS.ExecDijkstra(0, 1000, 100);

            [TestMethod]
            public void DijkstraRandomGraphLowDistribution() => NS.ExecDijkstra(0, 10000, 100, 0.4f);

            [TestMethod]
            public void DijkstraRandomGraphHightDistribution() => NS.ExecDijkstra(0, 10000, 100, 0.8f);
        };
    }

    namespace Path
    {
        [TestClass]
        public class Little
        {
            [TestMethod]
            public void DijkstraFrom0() => NS.DijkstraPath(0);
            [TestMethod]
            public void DijkstraFrom2() => NS.DijkstraPath(2);
            [TestMethod]
            public void DijkstraRandomGraph() => NS.DijkstraPath(0, 6, 10);
        }

        [TestClass]
        public class Big
        {
            [TestMethod]
            public void DijkstraRandomGraph() => NS.DijkstraPath(0, 1000, 100);

            [TestMethod]
            public void DijkstraRandomGraphLowDistribution() => NS.DijkstraPath(0, 10000, 100, 0.4f);

            [TestMethod]
            public void DijkstraRandomGraphHightDistribution() => NS.DijkstraPath(0, 10000, 100, 0.8f);
        }
    }
}

