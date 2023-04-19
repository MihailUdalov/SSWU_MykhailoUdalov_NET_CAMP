using System;
using System.Collections.Generic;

namespace Task2
{
    internal interface IBox
    {
        event EventHandler<bool> SizeUpdated;
        void UpdateSize();
        IBox Parent { get; }
        (double width, double height, double length) GetBoxSizes();
        string Name { get; }
    }
}
