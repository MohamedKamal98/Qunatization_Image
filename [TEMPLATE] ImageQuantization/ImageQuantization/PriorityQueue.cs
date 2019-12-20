using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageQuantization
{
   public class Priority_Queue
    {
        public List<Edge> list;
        public int Count { get { return list.Count; } }

        public Priority_Queue()
        {
            list = new List<Edge>();
        }


        public void Enqueue(Edge e)
        {
            list.Add(e);
            int i = Count - 1;

            while (i > 0)
            {
                int p = (i - 1) / 2;
                if (list[p].weight <= e.weight) break;

                list[i] = list[p];
                i = p;
            }

            if (Count > 0) list[i] = e;
        }

        public Edge Dequeue()
        {
            double min = Peek();
            Edge kmin = list[0];
            Edge root = list[Count - 1];
            list.RemoveAt(Count - 1);

            int i = 0;
            while (i * 2 + 1 < Count)
            {
                int a = i * 2 + 1;
                int b = i * 2 + 2;
                int c = b < Count && list[b].weight < list[a].weight ? b : a;

                if (list[c].weight >= root.weight) break;
                list[i] = list[c];
                i = c;
            }

            if (Count > 0) list[i] = root;
            return kmin;
        }

        public double Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Queue is empty.");
            return list[0].weight;
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}
