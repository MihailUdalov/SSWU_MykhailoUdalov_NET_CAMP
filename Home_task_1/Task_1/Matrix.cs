namespace Task_1
{
    internal class Matrix
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Point[,] Cells { get; private set; }

        // Порушення інкапсуляції. Ви повертаєте посилання, через яке можна доступитись до поля.

        public Matrix(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Point[height, width];
        }


        public void Init(Direction direction = Direction.Right)
        {
            if (direction == Direction.Left)
                direction = Direction.Down;

            if (direction == Direction.Up)
                direction = Direction.Right;

            int value = 1;
            //init first cell of matrix and increment value
            Cells[0, 0] = new Point(direction, value++);

            for (int col = 0, row = 0, matrixLength = 1, topLimit = 0, bottomLimit = Height - 1; matrixLength < Height * Width;)
            {
                switch (Cells[row, col].Direction)
                { // Завелика кількість умов на кожному кроці.

                    case Direction.Right:
                        if (col + 1 == Width || Cells[row, col + 1] != null)
                        {
                            if (row == topLimit || row != bottomLimit)
                            {
                                Cells[row, col].Direction = Direction.Down;
                                topLimit++;
                            }
                            else
                                Cells[row, col].Direction = Direction.Up;

                            break;
                        }

                        Cells[row, ++col] = new Point(Direction.Right, value);
                        matrixLength++;
                        value++;

                        break;
                    case Direction.Down:
                        if (row == bottomLimit || Cells[row + 1, col] != null)
                        {
                            if (col + 1 == Width || Cells[row, col + 1] != null)
                            {
                                Cells[row, col].Direction = Direction.Left;
                            }
                            else
                                Cells[row, col].Direction = Direction.Right;

                            break;
                        }
                        Cells[++row, col] = new Point(Direction.Down, value);
                        matrixLength++;
                        value++;

                        break;
                    case Direction.Left:
                        if (col == 0 || Cells[row, col - 1] != null)
                        {
                            if (row != topLimit || row == bottomLimit)
                            {
                                Cells[row, col].Direction = Direction.Up;
                                bottomLimit++;
                            }
                            else
                                Cells[row, col].Direction = Direction.Down;

                            break;
                        }
                        Cells[row, --col] = new Point(Direction.Left, value);
                        matrixLength++;
                        value++;

                        break;
                    case Direction.Up:
                        if (row == topLimit || Cells[row - 1, col] != null)
                        {
                            if (col == 0 || Cells[row, col - 1] != null)
                            {
                                Cells[row, col].Direction = Direction.Right;
                            }
                            else
                                Cells[row, col].Direction = Direction.Left;

                            break;
                        }
                        Cells[--row, col] = new Point(Direction.Up, value);
                        matrixLength++;
                        value++;

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
