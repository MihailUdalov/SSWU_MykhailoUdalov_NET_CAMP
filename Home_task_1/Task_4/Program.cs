namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tensor scalar = new Tensor();
            scalar[0] = 5;

            Tensor vector = new Tensor(10);
            vector[0] = 5;
            vector[1] = 5;
            vector[2] = 5;
            
            Tensor matrix = new Tensor(2, 2);
            matrix[0, 0] = 5;
            matrix[1, 0] = 5;
            matrix[0, 1] = 5;
            matrix[1, 1] = 5;
            Tensor tensor3D = new Tensor(2, 2, 2);
            tensor3D[0, 0, 0] = 5;
            tensor3D[1, 0, 0] = 5;
            tensor3D[0, 1, 0] = 5;
            tensor3D[1, 1, 0] = 5;

        }
    }
}
