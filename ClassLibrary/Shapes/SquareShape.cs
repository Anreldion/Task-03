using ClassLibrary.Sheets;
using System.Xml;
using static ClassLibrary.ExceptionsClass;

namespace ClassLibrary.Shapes
{
    public class SquareShape : ShapeBase
    {
        double side; //Сторона квадрата
        private Material material; //Материал 
        private string type = "SquareShape"; //Тип фигуры.

        /// <summary>
        /// Тип фигуры.
        /// </summary>
        public override string Type => type;
        /// <summary>
        /// Материал фигуры
        /// </summary>
        public override Material Material => material;

        /// <summary>
        /// Конструктор фигуры из материала
        /// </summary>
        /// <param name="side">Сторона квадрата</param>
        /// <param name="material">Материал для создания новой фигуры</param>
        public SquareShape(double side, Material material)
        {
            this.side = side;
            this.material = material;
        }
        /// <summary>
        /// Конструктор фигуры из другой фигуры
        /// </summary>
        /// <param name="side">Сторона квадрата</param>
        /// <param name="cutting_shape">Фигура для вырезания</param>
        public SquareShape(double side, ShapeBase cutting_shape)
        {
            this.side = side;
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
        /// Периметр квадрата
        /// </summary>
        public override double Perimeter
        {
            get
            {
                double perimeter = side * 4;
                if (double.IsNaN(perimeter))
                {
                    return 0;
                }
                return perimeter;
            }
        }
        /// <summary>
        /// Площадь квадрата
        /// </summary>
        public override double Area
        {
            get
            {
                double area = side * side;
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
            double koef = (new_area / old_area);
            side *= koef;
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
            XmlNode shape = Document.CreateElement(Type);
            XmlAttribute attributeSide = Document.CreateAttribute("Side");
            attributeSide.Value = side.ToString();

            XmlAttribute attributeMaterial = Document.CreateAttribute("Material");
            attributeMaterial.Value = Material.ToString();

            XmlAttribute attributeIsPainted = Document.CreateAttribute("IsPainted");
            attributeIsPainted.Value = Material.IsPainted().ToString();

            XmlAttribute attributeColor = Document.CreateAttribute("Color");
            attributeColor.Value = Material.GetColor().ToString();

            shape.Attributes.Append(attributeSide);
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
            xmlWriter.WriteStartElement(Type); //Тип фигуры

            xmlWriter.WriteAttributeString("Side", side.ToString());

            xmlWriter.WriteAttributeString("Material", Material.ToString());
            xmlWriter.WriteAttributeString("IsPainted", Material.IsPainted().ToString());
            xmlWriter.WriteAttributeString("Color", Material.GetColor().ToString());

            xmlWriter.WriteEndElement();
        }
    }
}
