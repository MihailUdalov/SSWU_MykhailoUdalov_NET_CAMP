using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class SquareMatrix : IEnumerable<int>
    {// вже замучилась це коментувати. Зрізаю бали.
        public int[,] Values { get; set; }

        public SquareMatrix(int n)
        {
            Values = new int[n, n];
            InitValues();
        }

        public SquareMatrix(int[,] array)
        {
            Values = array;
        }
        private void InitValues()
        {
            Random random = new Random();
            int size = Values.GetLength(0);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    Values[i, j] = random.Next(0, 30);
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (Values.GetLength(0) == 0)
                yield break;

            if (Values.GetLength(0) == 1)
            {
                yield return Values[0, 0];
                yield break;
            }
// у нас весь час буде генеруватись верхній лівий елемент!!!!
            yield return Values[0, 0];

            int i =0,
                j = 0;
            bool isUpAction = true;
            int step = 1;

            void DiagonalStep(ref int x, ref int y)
            {
                x--;
                y++;
            }

            int Step(bool isOddRow, ref int x, ref int y)
            {
                step += isUpAction ? 1 : -1;
                return isOddRow ? x++ : y++;
            }

            do
            {
                bool isOddRow = step % 2 == 1;
                if (isUpAction)
                {
                    Step(isOddRow, ref i, ref j);
                }
                else
                {
                    Step(isOddRow, ref j, ref i);
                }

                yield return Values[i, j];

                for (int ii = 0; ii < step - 1; ii++)
                {
                    if (isOddRow)
                        DiagonalStep(ref i, ref j);
                    else
                        DiagonalStep(ref j, ref i);
                    yield return Values[i, j];
                }

                if (step == Values.GetLength(0))
                    isUpAction = false;

            } while (step > 1);

            yield break;

        }

        //public IEnumerator<int> GetEnumerator()
        //{
        //     method with class when IEnumerator is implemented
        //     return new SquareMatrixEnumerator(Values);
        //}
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
