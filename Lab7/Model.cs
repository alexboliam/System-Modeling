using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    internal class Model
    {
        public List<Element> list { get; set; }

        public Model(List<Element> list)
        {
            this.list = list;
        }

        public void simulate(int coutIterations, bool printState)
        {
            InArcCalculate();
            SortPriority();

           
        }
       
        public void InArcCalculate()
        {
            foreach (var x in list)
            {
                foreach (var y in x.OutArcs)
                {
                    y.NextElement.InArcs.Add(new Arc(y.Multiplicity, x, y.Priority));
                }
            }
        }

        public void SortPriority()
        {
            foreach (var x in list)
            {
                x.InArcs.Sort((x, y) => x.Priority.CompareTo(y.Priority));
                x.OutArcs.Sort((x, y) => x.Priority.CompareTo(y.Priority));
            }
        }
    }
}