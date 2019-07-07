using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVLinkedList
{
    public class OVLinkedList<T>
    {
        protected LinkedList<T> List { get; set; }
        protected object Lock { get; set; }
        protected LinkedListNode<T> Iter { get; set; }

        public OVLinkedList()
        {
            List = new LinkedList<T>();
            Lock = new object();
            Iter = null;
        }

        public int Count
        {
            get
            {
                return List.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return List.Count == 0;
            }
        }

        public virtual void Enqueue(T result)
        {
            lock (Lock)
            {
                List.AddLast(result);
                if (null == Iter)
                {
                    Iter = List.First;
                }
            }
        }

        public virtual bool TryDequeue(out T result)
        {
            lock (Lock)
            {
                try
                {
                    if (null != List.First)
                    {
                        result = List.First.Value;
                        if (Iter == List.First)
                        {
                            Iter = List.First.Next;
                        }
                        List.RemoveFirst();
                        return true;
                    }
                    result = default;
                    return false;
                }
                catch (Exception)
                {
                    result = default;
                    return false;
                }
            }
        }

        public virtual bool TryPeek(out T result)
        {
            lock (Lock)
            {
                try
                {
                    if (null != List.First)
                    {
                        result = List.First.Value;
                        return true;
                    }
                    result = default;
                    return false;
                }
                catch (Exception)
                {
                    result = default;
                    return false;
                }
            }
        }

        public virtual bool TryGetNext(out T result)
        {
            lock (Lock)
            {
                try
                {
                    if (null != Iter)
                    {
                        if (null != Iter.Next)
                        {
                            result = Iter.Next.Value;
                            Iter = Iter.Next;
                            return true;
                        }
                    }
                    result = default;
                    return false;
                }
                catch (Exception)
                {
                    result = default;
                    return false;
                }
            }
        }

        public virtual bool TryGetPrev(out T result)
        {
            lock (Lock)
            {
                try
                {
                    if (null != Iter)
                    {
                        if (null != Iter.Previous)
                        {
                            result = Iter.Previous.Value;
                            Iter = Iter.Previous;
                            return true;
                        }
                    }
                    result = default;
                    return false;
                }
                catch (Exception)
                {
                    result = default;
                    return false;
                }
            }
        }

        public virtual bool TryRemoveCurrent(out T result)
        {
            lock (Lock)
            {
                try
                {
                    if (null != Iter)
                    {
                        result = Iter.Value;
                        LinkedListNode<T> newIter = null;
                        if (Iter == List.First)
                        {
                            //in beginning
                            newIter = Iter.Next;
                        }
                        else if (Iter == List.Last)
                        {
                            //in end
                            newIter = Iter.Previous;
                        }
                        else
                        {
                            //in middle
                            newIter = Iter.Next;
                        }
                        List.Remove(Iter);
                        Iter = newIter;
                        return true;
                    }
                    result = default;
                    return false;
                }
                catch (Exception)
                {
                    result = default;
                    return false;
                }
            }
        }

        public virtual bool TryGetCurrent(out T result)
        {
            lock (Lock)
            {
                try
                {
                    if (null != Iter)
                    {
                        result = Iter.Value;
                        return true;
                    }
                    result = default;
                    return false;
                }
                catch (Exception)
                {
                    result = default;
                    return false;
                }
            }
        }

        public virtual T[] ToArray()
        {
            lock (Lock)
            {
                return List.ToArray();
            }
        }
    }
}