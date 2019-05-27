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
            public void DijkstraFrom0() => NS.Dijkstra(0);

            [TestMethod]
            public void DijkstraFrom2() => NS.Dijkstra(2);

            [TestMethod]
            public void DijkstraRandomGraph() => NS.Dijkstra(0, 6, 10);
        };


        [TestClass]
        public class Big
        {
            [TestMethod]
            public void DijkstraRandomGraph() => NS.Dijkstra(0, 1000, 100);

            [TestMethod]
            public void DijkstraRandomGraphLowDistribution() => NS.Dijkstra(0, 15000, 100, 0.4f);

            [TestMethod]
            public void DijkstraRandomGraphHightDistribution() => NS.Dijkstra(0, 15000, 100, 0.8f);
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
            public void DijkstraRandomGraphLowDistribution() => NS.DijkstraPath(0, 15000, 100, 0.4f);

            [TestMethod]
            public void DijkstraRandomGraphHightDistribution() => NS.DijkstraPath(0, 15000, 100, 0.8f);
        }
    }
}

