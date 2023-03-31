using System;

namespace Task_2
{
    internal class Matrix
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int[,] Cells { get; private set; }


        public Matrix(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new int[height, width];

            Init();
        }

        private void Init()
        {
            Random random = new Random();

            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    Cells[i, j] = random.Next(0, 16);
        }

        public string GetLongestSequence()
        {
            int color = -1,
                 row = 0,
                 startIndex = 0,
                 endIndex = 0,
                 maxLength = 0;


            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int length = 1;
                    int k = j + 1;

                    while (k < Width)
                    {
                        if (Cells[i, k] != Cells[i, j])
                            break;

                        length++;
                        k++;
                    }

                    if (length > maxLength)
                    {
                        color = Cells[i, j];
                        row = i;
                        startIndex = j;
                        endIndex = j + length - 1;
                        maxLength = length;
                        j = endIndex;
                    }
                }
            }

            return $"Color: {color} \n" + 
                    $"Start: ({row}, {startIndex})\n" + 
                    $"End: ({row}, {endIndex})\n" + 
                    $"Length: {maxLength}";
        }
    }
}