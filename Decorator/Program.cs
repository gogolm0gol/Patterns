using System;
using System.Text;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Проста ялинка без прикрас
            FirTree tree = new FirTree();
            Console.WriteLine("--- Проста ялинка ---");
            tree.Show();

            OrnamentDecorator ornaments = new OrnamentDecorator("кульки", 20);
            GarlandDecorator garland = new GarlandDecorator("різнокольорова");

            ornaments.SetTree(tree);
            garland.SetTree(ornaments);

            Console.WriteLine();
            Console.WriteLine("--- Ялинка з прикрасами та гірляндою ---");
            garland.Show();

            Console.Read();
        }
    }

    abstract class Tree
    {
        public abstract void Show();
    }

    class FirTree : Tree
    {
        public override void Show()
        {
            Console.WriteLine("Ялинка");
        }
    }

    // "Decorator"
    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public void SetTree(Tree tree)
        {
            this.tree = tree;
        }

        public override void Show()
        {
            if (tree != null)
            {
                tree.Show();
            }
        }
    }

    // "ConcreteDecoratorA"  ялинкові прикраси
    class OrnamentDecorator : TreeDecorator
    {
        private string ornamentType;
        private int count;

        public OrnamentDecorator(string ornamentType, int count)
        {
            this.ornamentType = ornamentType;
            this.count = count;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Прикраси: " + ornamentType + ", " + count + " шт.");
        }
    }

    // "ConcreteDecoratorB"  гірлянда
    class GarlandDecorator : TreeDecorator
    {
        private string color;

        public GarlandDecorator(string color)
        {
            this.color = color;
        }

        public override void Show()
        {
            base.Show();
            Light();
        }

        void Light()
        {
            Console.WriteLine("Гірлянда (" + color + ") світиться!");
        }
    }
}