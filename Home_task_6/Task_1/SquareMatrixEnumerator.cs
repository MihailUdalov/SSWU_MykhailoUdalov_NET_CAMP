using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_1
{

    internal class SquareMatrixEnumerator : IEnumerator<int>
    {

        private int[,] values;
        private int size;
        private Direction direction;
        private int currentRow;
        private int currentColumn;

        public SquareMatrixEnumerator(int[,] values)
        {
            this.values = values;
            currentRow = -1;
            currentColumn = -1;
            size = values.GetLength(0);
        }

        public int Current
        {
            get
            {
                try
                {
                    return values[currentRow, currentColumn];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            bool moveNext() => currentRow < size && currentColumn < size;

            if (currentRow == -1 && currentColumn == -1)
            {
                currentRow = 0;
                currentColumn = 0;

                ChangeDirection(currentRow, Direction.Down, Direction.Right);

                return moveNext();
            }

            switch (direction)
            {
                case Direction.Down:
                    currentRow++;
                    ChangeDirection(currentColumn, Direction.UpRight, Direction.DownLeft);

                    break;
                case Direction.Right:
                    currentColumn++;
                    ChangeDirection(currentRow, Direction.DownLeft, Direction.UpRight);

                    break;
                case Direction.DownLeft:
                    currentRow++;
                    currentColumn--;
                    if (currentColumn != 0)
                    {
                        if (currentRow != size - 1)
                            direction = Direction.DownLeft;
                        else
                            ChangeDirection(currentRow, Direction.Down, Direction.Right);   
                    }
                    else
                        ChangeDirection(currentRow, Direction.Down, Direction.Right);

                    break;
                case Direction.UpRight:
                    currentRow--;
                    currentColumn++;
                    if (currentRow != 0)
                    {
                        if (currentColumn != size - 1)
                            direction = Direction.UpRight;
                        else
                            ChangeDirection(currentColumn, Direction.Right, Direction.Down);
                    }
                    else
                        ChangeDirection(currentColumn, Direction.Right, Direction.Down);

                    break;
                default:
                    break;
            }
            return moveNext();

        }

        private void ChangeDirection(int ColumnOrRow, Direction firsDirection, Direction secondDirection)
        {
            if (ColumnOrRow != size - 1)
                direction = firsDirection;
            else
                direction = secondDirection;
        }

        public void Reset()
        {
            currentRow = -1;
            currentColumn = -1;
        }
        public void Dispose()
        {

        }
    }
}
