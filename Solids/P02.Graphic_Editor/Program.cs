using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            Circle circle = new Circle();
            Pentagon newShape = new Pentagon();
            GraphicEditor editor  = new GraphicEditor();
            editor.DrawShape(circle);
            editor.DrawShape(newShape);
        }
    }
}
