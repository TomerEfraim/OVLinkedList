using Microsoft.VisualStudio.TestTools.UnitTesting;
using OVLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVLinkedList.Tests
{
    [TestClass()]
    public class OVLinkedListTests
    {
        [TestMethod()]
        public void Test1()
        {
            OVLinkedList<int> list = new OVLinkedList<int>();

            list.Enqueue(1);
            list.Enqueue(2);
            list.Enqueue(3);

            bool b0 = list.TryGetNext(out int n0);
            Assert.AreEqual(true, b0);
            Assert.AreEqual(2, n0);

            bool b1 = list.TryGetNext(out int n1);
            Assert.AreEqual(true, b1);
            Assert.AreEqual(3, n1);

            bool b2 = list.TryGetNext(out int n2);
            Assert.AreEqual(false, b2);
            Assert.AreEqual(0, n2);

            bool b3 = list.TryDequeue(out int d0);
            Assert.AreEqual(true, b3);
            Assert.AreEqual(1, d0);

            bool b4 = list.TryDequeue(out int d1);
            Assert.AreEqual(true, b4);
            Assert.AreEqual(2, d1);

            list.Enqueue(4);

            bool b5 = list.TryGetNext(out int n3);
            Assert.AreEqual(true, b5);
            Assert.AreEqual(4, n3);

            bool b6 = list.TryDequeue(out int d2);
            Assert.AreEqual(true, b6);
            Assert.AreEqual(3, d2);

            bool b7 = list.TryGetNext(out int n4);
            Assert.AreEqual(false, b7);
            Assert.AreEqual(0, n4);

            bool b8 = list.TryGetPrev(out int p0);
            Assert.AreEqual(false, b8);
            Assert.AreEqual(0, p0);

            list.Enqueue(5);

            bool b9 = list.TryGetPrev(out int p1); // 0 (default), iter = 1
            Assert.AreEqual(false, b9);
            Assert.AreEqual(0, p1);

            bool b10 = list.TryGetNext(out int n5);//5 
            Assert.AreEqual(true, b10);
            Assert.AreEqual(5, n5);

            bool b12 = list.TryGetPrev(out int n6);//4 (default), iter = 1
            Assert.AreEqual(true, b12);
            Assert.AreEqual(4, n6);

            bool b17 = list.TryGetPrev(out int n11);//0 (default), iter = 1
            Assert.AreEqual(false, b17);
            Assert.AreEqual(0, n11);

            bool b15 = list.TryGetNext(out int n9);//5
            Assert.AreEqual(true, b15);
            Assert.AreEqual(5, n9);

            bool b16 = list.TryGetNext(out int n10);//0 (default), iter = 1
            Assert.AreEqual(false, b16);
            Assert.AreEqual(0, n10);

            bool b20 = list.TryGetPrev(out int n14);//4 
            Assert.AreEqual(true, b20);
            Assert.AreEqual(4, n14);

            bool b18 = list.TryDequeue(out int n12); //4
            Assert.AreEqual(true, b18);
            Assert.AreEqual(4, n12);

            bool b19 = list.TryGetPrev(out int n13);//0 (default), iter = 1
            Assert.AreEqual(false, b19);
            Assert.AreEqual(0, n13);

            bool b21 = list.TryGetNext(out int n15);//0 (default), iter = 1
            Assert.AreEqual(false, b21);
            Assert.AreEqual(0, n15);
        }

        [TestMethod()]
        public void Test2()
        {
            OVLinkedList<int> list = new OVLinkedList<int>();

            list.Enqueue(1);
            list.Enqueue(2);
            list.Enqueue(3);

            bool b0 = list.TryGetNext(out int n0);
            Assert.AreEqual(true, b0);
            Assert.AreEqual(2, n0);

            bool b1 = list.TryGetCurrent(out int n1);
            Assert.AreEqual(true, b1);
            Assert.AreEqual(2, n1);

            bool b2 = list.TryRemoveCurrent(out int n2);
            Assert.AreEqual(true, b2);
            Assert.AreEqual(2, n2);

            bool b3 = list.TryGetNext(out int n3);
            Assert.AreEqual(false, b3);
            Assert.AreEqual(0, n3);

            bool b4 = list.TryGetPrev(out int n4);
            Assert.AreEqual(true, b4);
            Assert.AreEqual(1, n4);
        }

        [TestMethod()]
        public void Test3()
        {
            OVLinkedList<int> list = new OVLinkedList<int>();

            bool b0 = list.TryGetCurrent(out int n0);
            Assert.AreEqual(false, b0);
            Assert.AreEqual(0, n0);

            list.Enqueue(1);
            list.Enqueue(2);
            list.Enqueue(3);
            list.Enqueue(4);

            bool b1 = list.TryGetCurrent(out int n1);
            Assert.AreEqual(true, b1);
            Assert.AreEqual(1, n1);

            bool b2 = list.TryRemoveCurrent(out int n2);
            Assert.AreEqual(true, b2);
            Assert.AreEqual(1, n2);

            bool b3 = list.TryGetCurrent(out int n3);
            Assert.AreEqual(true, b3);
            Assert.AreEqual(2, n3);

            bool b4 = list.TryDequeue(out int n4);
            Assert.AreEqual(true, b4);
            Assert.AreEqual(2, n4);

            bool b5 = list.TryGetCurrent(out int n5);
            Assert.AreEqual(true, b5);
            Assert.AreEqual(3, n5);

            bool b6 = list.TryGetPrev(out int n6);
            Assert.AreEqual(false, b6);
            Assert.AreEqual(0, n6);

            bool b7 = list.TryGetNext(out int n7);
            Assert.AreEqual(true, b7);
            Assert.AreEqual(4, n7);

        }

        [TestMethod()]
        public void Test4()
        {
            OVLinkedList<int> list = new OVLinkedList<int>();

            bool b0 = list.TryGetCurrent(out int n0);
            Assert.AreEqual(false, b0);
            Assert.AreEqual(0, n0);

            list.Enqueue(1);
            list.Enqueue(2);
            list.Enqueue(3);
            list.Enqueue(4);

            bool b1 = list.TryGetNext(out int n1);
            Assert.AreEqual(true, b1);
            Assert.AreEqual(2, n1);

            bool b2 = list.TryGetNext(out int n2);
            Assert.AreEqual(true, b2);
            Assert.AreEqual(3, n2);

            bool b3 = list.TryGetNext(out int n3);
            Assert.AreEqual(true, b3);
            Assert.AreEqual(4, n3);

            bool b4 = list.TryGetNext(out int n4);
            Assert.AreEqual(false, b4);
            Assert.AreEqual(0, n4);

            bool b5 = list.TryRemoveCurrent(out int n5);
            Assert.AreEqual(true, b5);
            Assert.AreEqual(4, n5);

            bool b6 = list.TryGetCurrent(out int n6);
            Assert.AreEqual(true, b6);
            Assert.AreEqual(3, n6);

            bool b7 = list.TryDequeue(out int n7);
            Assert.AreEqual(true, b7);
            Assert.AreEqual(1, n7);

            bool b8 = list.TryGetCurrent(out int n8);
            Assert.AreEqual(true, b8);
            Assert.AreEqual(3, n8);

        }

        [TestMethod()]
        public void Test5()
        {
            OVLinkedList<int> list = new OVLinkedList<int>();

            int[] n0 = list.ToArray();
            CollectionAssert.AreEqual(new int[0] { }, n0);

            list.Enqueue(1);
            list.Enqueue(2);
            list.Enqueue(3);
            list.Enqueue(4);

            int[] n1 = list.ToArray();
            CollectionAssert.AreEqual(new int[4] { 1, 2, 3, 4 }, n1);

            bool b2 = list.TryDequeue(out int n2);
            Assert.AreEqual(true, b2);
            Assert.AreEqual(1, n2);

            int[] n3 = list.ToArray();
            CollectionAssert.AreEqual(new int[3] { 2, 3, 4}, n3);
        }

        [TestMethod]
        public void Test6()
        {
            OVLinkedList<int> list = new OVLinkedList<int>();

            list.ResetCurrent();

            bool b0 = list.TryGetCurrent(out int n0);
            Assert.AreEqual(false, b0);
            Assert.AreEqual(0, n0);

            list.Enqueue(1);
            list.Enqueue(2);
            list.Enqueue(3);

            bool b1 = list.TryGetNext(out int n1);
            Assert.AreEqual(true, b1);
            Assert.AreEqual(2, n1);

            bool b2 = list.TryGetNext(out int n2);
            Assert.AreEqual(true, b2);
            Assert.AreEqual(3, n2);

            bool b3 = list.TryGetNext(out int n3);
            Assert.AreEqual(false, b3);
            Assert.AreEqual(0, n3);

            list.ResetCurrent();

            bool b4 = list.TryGetCurrent(out int n4);
            Assert.AreEqual(true, b4);
            Assert.AreEqual(1, n4);

            list.ResetCurrent();

            bool b5 = list.TryGetCurrent(out int n5);
            Assert.AreEqual(true, b5);
            Assert.AreEqual(1, n5);

            list.TryDequeue(out int n6);

            list.ResetCurrent();

            bool b7 = list.TryGetCurrent(out int n7);
            Assert.AreEqual(true, b7);
            Assert.AreEqual(2, n7);
        }

        [TestMethod]
        public void Test7()
        {
            OVLinkedList<string> list = new OVLinkedList<string>();

            var iterator = list.GetEnumerator();

            bool b0 = iterator.MoveNext();
            string n0 = iterator.Current;
            Assert.AreEqual(false, b0);
            Assert.AreEqual(null, n0);

            list.Enqueue("a");
            list.Enqueue("b");
            list.Enqueue("c");

            iterator = list.GetEnumerator();

            bool b1 = iterator.MoveNext();
            string n1 = iterator.Current;
            Assert.AreEqual(true, b1);
            Assert.AreEqual("a", n1);

            bool b2 = iterator.MoveNext();
            string n2 = iterator.Current;
            Assert.AreEqual(true, b2);
            Assert.AreEqual("b", n2);

            bool b3 = iterator.MoveNext();
            string n3 = iterator.Current;
            Assert.AreEqual(true, b3);
            Assert.AreEqual("c", n3);


        }
    }
}