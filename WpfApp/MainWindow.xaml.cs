using ClassLibrary;
using ClassLibrary.Shapes;
using ClassLibrary.Sheets;
using System;
using System.Collections.Generic;
using System.Windows;
using static ClassLibrary.Colors;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var Alcoholic = new Alcohol("Vodka", 56.43, 47);
            Alcoholic.Add(new Liquid(3.32));
            Alcoholic.Add(new Liquid(3.35));
            Alcoholic.Add(new Liquid(3.42));
            Alcoholic.Add(new Liquid(3.62));
            Alcoholic[2] = new Liquid(5.43);

            Girl Anny = new Girl();

            TriangleShape triangleBase = new TriangleShape(2, 2, 2, Materials.Paper);
            string str = triangleBase.Material.ToString();
            triangleBase.Paint(Palette.Blue);
            try
            {
                triangleBase.Paint(Palette.Yellow);
            }
            catch
            {

            }
            TriangleShape triangle1 = new TriangleShape(1, 1, 1, triangleBase);
            TriangleShape triangle2 = new TriangleShape(1, 1, 1, triangleBase);
            TriangleShape triangle3 = new TriangleShape(1, 1, 1, triangleBase);



        }
    }


    //Создать класс Liquid(жидкость), имеет поля «имя» и «плотность». определить методы
    //переназначения и изменения плотности.
    //Создать класс-контейнер Alcohol (спирт), содержащий поле «жидкость» и поле
    //«Прочность». Определить методы пере-присвоения и изменения прочности.
    //Есть код унаследования этих классов:
    public class Liquid
    {
        public Liquid(string name, double density)
        {
            _name = name;
            this.Density = density;
        }
        public Liquid(double density)
        {
            this.Density = density;
            _name = string.Empty;
        }

        private string _name;
        public string Name { get { return _name; } }

        private double _density;
        public double Density { get { return _density; } set { _density = value; } }

        public override string ToString() => $"Liquid \tname: {Name}\n\tdensity: {Density}";
    }

    public class Alcohol : Liquid
    {
        public Alcohol(string name, double density, int strength)
            : base(name, density)
        {
            this.Strength = strength;
            _container = new List<Liquid>();
        }

        private List<Liquid> _container;
        public Liquid this[int index]
        {
            get { return _container[index]; }
            set { _container[index] = value; }
        }
        public void Add(Liquid liquid) => _container.Add(liquid);

        private int _strength;
        public int Strength { get { return _strength; } set { _strength = value; } }

        public override string ToString() => base.ToString() + $"\nAlcohol\tstrength: {Strength}";
    }

    abstract class GeomFigure
    {

        abstract public double sFigure();
        abstract public double pFigure();
    }
    class Triangle : GeomFigure
    {
        double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double sFigure()
        {
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }
        public override double pFigure()
        {
            return (a + b + c);

        }
    }

    class Square : GeomFigure
    {
        double a;
        public Square(double a)
        {
            this.a = a;

        }
        public override double sFigure()
        {
            return a * a;
        }
        public override double pFigure()
        {
            return 4 * a;
        }
    }

    class Rhombus : GeomFigure
    {
        double a, b, c;
        public Rhombus(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double sFigure()
        {

            return b * c / 2;
        }
        public override double pFigure()
        {
            return 4 * a;
        }
    }

    class Rectangle : GeomFigure
    {
        double a, b;
        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override double sFigure()
        {
            return a * b;
        }
        public override double pFigure()
        {
            return (a + b) * 2;
        }
    }

    class Parallel : GeomFigure
    {
        double a, h, b;
        public Parallel(double a, double h, double b)
        {
            this.a = a;
            this.h = h;
            this.b = b;
        }
        public override double pFigure()
        {
            return 2 * (a + b);
        }
        public override double sFigure()
        {
            return a * h;
        }
    }

    class Trapezium : GeomFigure
    {
        double a, b, c, d, h;
        public Trapezium(double a, double b, double c, double d, double h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.h = h;
        }
        public override double sFigure()
        {
            return ((a + b) / 2) * h;
        }
        public override double pFigure()
        {
            return a + b + c + d;
        }
    }

    class Circle : GeomFigure
    {
        double r;
        public Circle(double r)
        {
            this.r = r;
        }
        public override double sFigure()
        {
            return 3.14 * (r * r);
        }
        public override double pFigure()
        {
            return 2 * 3.14 * r;
        }
    }

    class Ellipse : GeomFigure
    {
        int a, b;
        public Ellipse(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override double sFigure()
        {
            return 3.14 * a * b;
        }
        public override double pFigure()
        {
            return a + b;
        }

    }


}
