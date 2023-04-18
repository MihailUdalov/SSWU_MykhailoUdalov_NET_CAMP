using System.Collections.Generic;

namespace Task2
{
    internal interface IBox
    {
        (double width, double height, double length) GetBoxSizes();

        string Name { get; }
    }
}
