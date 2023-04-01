namespace Task_1
{
    internal class Matrix
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
// Порушення інкапсуляції. Ви повертаєте посилання, через яке можна доступитись до поля.
        
        public Point[,] Cells { get; private set; }

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

            int topLimit = 0,
             bottomLimit = Height - 1,
             leftLimit = 0,
             rightLimit = Width - 1;

            for (int col = 0, row = 0, matrixLength = 1; matrixLength < Height * Width;)
            {
                switch (direction)
                {// Завелика кількість умов на кожному кроці.
                    case Direction.Right:
                        if (col == rightLimit || Cells[row, col + 1] != null)
                        {
                            direction = Direction.Down;
                            topLimit++;
                        }
                        else
                        {
                          
                            Cells[row, ++col] = new Point(Direction.Right, value++);
                            matrixLength++;
                        }
                        break;

                    case Direction.Down:
                        if (row == bottomLimit || Cells[row + 1, col] != null)
                        {
                            direction = Direction.Left;
                        }
                        else
                        {
                            Cells[++row, col] = new Point(Direction.Down, value++);
                            matrixLength++;
                        }
                        break;

                    case Direction.Left:
                        if (col == leftLimit || Cells[row, col - 1] != null)
                        {
                            direction = Direction.Up;
                            bottomLimit--;
                        }
                        else
                        {
                            Cells[row, --col] = new Point(Direction.Left, value++);
                            matrixLength++;
                        }
                        break;

                    case Direction.Up:
                        if (row == topLimit || Cells[row - 1, col] != null)
                        {
                            direction = Direction.Right;
                            leftLimit++;
                        }
                        else
                        {
                            Cells[--row, col] = new Point(Direction.Up, value++);
                            matrixLength++;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
