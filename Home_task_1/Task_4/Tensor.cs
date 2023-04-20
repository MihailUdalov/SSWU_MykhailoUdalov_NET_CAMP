using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Tensor
    {
        private int[] size;
        private Dimensions dimensions;
        private Array Values { get; set; }
       
        public Tensor(params int[] dimensions)
        {
            if (dimensions == null || dimensions.Length == 0)
            {
                this.dimensions = Dimensions.Scalar;
                size = new int[1];
                Values = Array.CreateInstance(typeof(int), 1);
            }
            else
            {
                this.dimensions = (Dimensions)dimensions.Length;
                size = dimensions;
                Values = Array.CreateInstance(typeof(int), size);
            }
              
           
        }

        public int this[params int[] index]
        {
            get
            {
                if (index.Length != size.Length)
                {
                    throw new ArgumentException("Incorrect number of indices.");
                }
                return (int)Values.GetValue(index);
            }

            set
            {
                if (index.Length != size.Length)
                {
                    throw new ArgumentException("Incorrect number of indices.");
                }
                Values.SetValue(value, index);
            }
        }
    }
}
