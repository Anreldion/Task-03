using ClassLibrary.Sheets;
using System;
using System.Xml;
using static ClassLibrary.ExceptionsClass;

namespace ClassLibrary.Shapes
{
    public class TriangleShape : ShapeBase
    {

        private double a, b, c;   // Стороны треугольника

        private Material material; //Материал 

        private string type = "TriangleShape"; //Тип фигуры

        public override string Type => type;
        public override Material Material => material;

        /// <summary>
        /// Конструктор фигуры из материала
        /// </summary>
        /// <param name="a">Сторона треугольника</param>
        /// <param name="b">Сторона треугольника</param>
        /// <param name="c">Сторона треугольника</param>
        /// <param name="material">Материал для создания новой фигуры</param>
        public TriangleShape(double a, double b, double c, Material material)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.material = material;
        }
        /// <summary>
        /// Конструктор фигуры из другой фигуры
        /// </summary>
        /// <param name="a">Сторона треугольника</param>
        /// <param name="b">Сторона треугольника</param>
        /// <param name="c">Сторона треугольника</param>
        /// <param name="cutting_shape">Фигура для вырезания</param>
        public TriangleShape(double a, double b, double c, ShapeBase cutting_shape)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.material = cutting_shape.Material;

            if (Area < cutting_shape.Area)
            {
                cutting_shape.Cutting(Area);
            }
            else
            {
                throw new ShapeExceptions("Площадь новой фигуры больше основной!");
            }

        }

        /// <summary>
        /// Периметр треугольника
        /// </summary>
        public override double Perimeter
        {
            get
            {
                double perimeter = a + b + c;
                if (double.IsNaN(perimeter))
                {
                    return 0;
                }
                return perimeter;
            }
        }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public override double Area
        {
            get
            {
                double semi_perimeter = (a + b + c) / 2;
                double area = Math.Sqrt(semi_perimeter * (semi_perimeter - a) * (semi_perimeter - b) * (semi_perimeter - c));
                if (double.IsNaN(area))
                {
                    return 0;
                }
                return area;
            }
        }

        /// <summary>
        /// Уменьшить площадь фигуры
        /// </summary>
        /// <param name="area">Площадь</param>
        public override void Cutting(double area)
        {
            double old_area = Area;
            double new_area = old_area - area;
            double koef = 1.0 - (1.0 - (new_area / old_area)) / 2;
            a *= koef;
            b *= koef;
            c *= koef;
        }

        /// <summary>
        /// Окрасить фигуру
        /// </summary>
        /// <param name="color">Цвет окрашивания</param>
        public override void Paint(Colors.Palette color)
        {
            material.Paint(color);
        }

        /// <summary>
        /// Преобразование фигуры в элемент xml
        /// </summary>
        /// <param name="Document">Ссылка на документ</param>
        /// <returns>Возвращает XmlNode элемент </returns>
        public override XmlNode ToStreamWriter(XmlDocument Document)
        {
            XmlNode shape = Document.CreateElement("TriangleShape");
            XmlAttribute attributeA = Document.CreateAttribute("A");
            attributeA.Value = a.ToString();
            XmlAttribute attributeB = Document.CreateAttribute("B");
            attributeB.Value = b.ToString();
            XmlAttribute attributeC = Document.CreateAttribute("C");
            attributeC.Value = c.ToString();

            XmlAttribute attributeMaterial = Document.CreateAttribute("Material");
            attributeMaterial.Value = Material.ToString();

            XmlAttribute attributeIsPainted = Document.CreateAttribute("IsPainted");
            attributeIsPainted.Value = Material.IsPainted().ToString();

            XmlAttribute attributeColor = Document.CreateAttribute("Color");
            attributeColor.Value = Material.GetColor().ToString();

            shape.Attributes.Append(attributeA);
            shape.Attributes.Append(attributeB);
            shape.Attributes.Append(attributeC);
            shape.Attributes.Append(attributeMaterial);
            shape.Attributes.Append(attributeIsPainted);
            shape.Attributes.Append(attributeColor);
            return shape;
        }

        /// <summary>
        /// Преобразование фигуры в элемент xml
        /// </summary>
        /// <param name="xmlWriter">Ссылка на XmlTextWriter</param>
        public override void ToXmlWriter(XmlTextWriter xmlWriter)
        {

            xmlWriter.WriteStartElement("TriangleShape"); //Тип фигуры

            xmlWriter.WriteAttributeString("A", a.ToString());
            xmlWriter.WriteAttributeString("B", b.ToString());
            xmlWriter.WriteAttributeString("C", c.ToString());

            xmlWriter.WriteAttributeString("Material", Material.ToString());
            xmlWriter.WriteAttributeString("IsPainted", Material.IsPainted().ToString());
            xmlWriter.WriteAttributeString("Color", Material.GetColor().ToString());

            xmlWriter.WriteEndElement();
        }
    }
}
