using ClassLibrary.Shapes;
using ClassLibrary.Sheets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using static ClassLibrary.Colors;
using static ClassLibrary.ExceptionsClass;

namespace ClassLibrary
{
    public class Box
    {
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Box()
        {

        }

        private List<ShapeBase> container = new List<ShapeBase>(); //Контейнер

        /// <summary>
        /// Индексатор (Контейнер)
        /// </summary>
        /// <param name="index">Номер элемента</param>
        /// <returns></returns>
        public ShapeBase this[int index]
        {
            get { return Get(index); }
            set { Add(value); }
        }

        /// <summary>
        /// Добавить фигуру. Нельзя добавить одну и ту же фигуру дважды. Не более 20 фигур в коробке.
        /// </summary>
        /// <param name="shape">ShapeBase элемент</param>
        /// <returns>true если элемент добавлен, иначе false</returns>
        public bool Add(ShapeBase shape)
        {
            if (container.Count >= 20)
            {
                throw new BoxArgumentException("Количество фигур превышает 20 штук!", container.Count);
            }
            else
            {
                if (container.Contains(shape))
                {
                    return false;
                }
                else
                {
                    container.Add(shape);
                    return true;
                }
            }
        }

        /// <summary>
        /// Просмотреть фигуру по номеру (фигура остается в коробке)
        /// </summary>
        /// <param name="number">Запрашиваемый номер фигуры</param>
        /// <returns>ShapeBase, иначе исключение BoxArgumentException</returns>
        public ShapeBase Get(int number)
        {
            if (container.Count <= number)
            {
                throw new BoxArgumentException("Запрашиваемый номер (" + number.ToString() + ") превышает число элементов в колекции!", container.Count);
                //return null;
            }
            else
            {
                return container[number];
            }

        }

        /// <summary>
        /// Извлечь фигуру по номеру (фигура удаляется из коробки)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public ShapeBase Extract(int number)
        {
            if (container.Count <= number)
            {
                throw new BoxArgumentException("Запрашиваемый номер (" + number.ToString() + ") превышает число элементов в колекции!", container.Count);
            }
            else
            {
                ShapeBase shape = container[number];
                container.RemoveAt(number);
                return shape;
            }
        }


        /// <summary>
        /// Заменить фигуру по номеру
        /// </summary>
        /// <param name="number">Номер элемента в коллекции</param>
        /// <param name="shape">ShapeBase Элемент</param>
        public void Replace(int number, ShapeBase shape)
        {
            if (container.Count <= number)
            {
                throw new BoxArgumentException("Запрашиваемый номер (" + number.ToString() + ") превышает число элементов в колекции!", container.Count);
            }
            else
            {
                container[number] = shape;
            }
        }

        /// <summary>
        /// Найти фигуру по образцу (эквивалентную по своим характеристикам)
        /// </summary>
        /// <param name="area">Площадь фигуры</param>
        /// <returns></returns>
        public ShapeBase Find(double area)
        {
            foreach (var item in container)
            {
                if (item.Area.EqualTo(area, 0.01))
                {
                    return item;
                }
            }
            return null;
        }


        /// <summary>
        /// Показать наличное количество фигур
        /// </summary>
        /// <returns>Возвращает количество фигур в коробке</returns>
        public int Count()
        {
            return container.Count;
        }

        /// <summary>
        /// Получить суммарный периметр всех фигур
        /// </summary>
        /// <returns>Суммарный периметр</returns>
        public double TotalPerimeter()
        {
            double perimeter = 0;
            foreach (var item in container)
            {
                perimeter += item.Perimeter;
            }
            return perimeter;
        }

        /// <summary>
        /// Получить суммарную площадь всех фигур
        /// </summary>
        /// <returns>Сумарная площадь</returns>
        public double TotalArea()
        {
            double area = 0;
            foreach (var item in container)
            {
                area += item.Area;
            }
            return area;
        }

        /// <summary>
        /// Получить все круги
        /// </summary>
        /// <returns>List<ShapeBase>, иначе null</returns>
        public List<ShapeBase> GetAllCircles()
        {
            List<ShapeBase> shapes = new List<ShapeBase>();
            foreach (var item in container)
            {
                if (item.Type == "СircleShape")
                {
                    shapes.Add(item);
                }
            }
            return shapes;
        }

        /// <summary>
        /// Достать все пленочные фигуры
        /// </summary>
        /// <returns>List<ShapeBase>, иначе null</returns>
        public List<ShapeBase> GetFilmShapes()
        {
            List<ShapeBase> shapes = new List<ShapeBase>();
            foreach (var item in container)
            {
                if (item.Material.ToString() == "Film")
                {
                    shapes.Add(item);
                }
            }
            return shapes;
        }


        /// <summary>
        /// Достать все Пластиковые фигуры, которые ни разу не красились 
        /// </summary>
        /// <returns>List<ShapeBase>, иначе null</returns>
        public List<ShapeBase> GetNotPaintedPlasticShapes()
        {
            List<ShapeBase> shapes = new List<ShapeBase>();
            foreach (var item in container)
            {
                if (item.Material.ToString() == "Plastic" && item.Material.IsPainted() == false)
                {
                    shapes.Add(item);
                }
            }
            return shapes;
        }

        /// <summary>
        /// Варианты сохранения фигур в xml файл
        /// </summary>
        public enum SaveShape
        {
            All,
            Plastic,
            Film,
            Paper,
        }
        /// <summary>
        /// Способы сохранения xml
        /// </summary>
        public enum XmlSaveMethod
        {
            StreamWriter,
            XmlWriter,
        }
        /// <summary>
        /// Способы загрузки xml
        /// </summary>
        public enum XmlLoadMethod
        {
            StreamReader,
            XmlReader,
        }

        /// <summary>
        /// Cохранить фигуры из коробки в XML-файл
        /// </summary>
        /// <param name="file_name">Название файла</param>
        /// <param name="what_to_save">Какой тип фигур необходимо сохранить (All, Circles, Film, Paper)</param>
        /// <param name="save_method">Способ сохранения (StreamWriter, XmlWriter)</param>
        public void SaveToXML(string file_name, SaveShape what_to_save, XmlSaveMethod save_method)
        {

            if (save_method == XmlSaveMethod.XmlWriter)
            {
                using (StreamWriter streamWriter = File.CreateText(file_name))
                {
                    using (XmlTextWriter xmlWriter = new XmlTextWriter(streamWriter))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteWhitespace("\n");
                        xmlWriter.WriteStartElement("Box");
                        xmlWriter.WriteWhitespace("\n");

                        foreach (var item in container)//Добавляем фигуры
                        {
                            switch (what_to_save)
                            {
                                case SaveShape.All:
                                    item.ToXmlWriter(xmlWriter);
                                    break;

                                case SaveShape.Paper:
                                    if (item.Material.ToString() == "Paper")
                                    {
                                        item.ToXmlWriter(xmlWriter);
                                        xmlWriter.WriteWhitespace("\n");
                                    }
                                    break;

                                case SaveShape.Plastic:
                                    if (item.Material.ToString() == "Plastic")
                                    {
                                        item.ToXmlWriter(xmlWriter);
                                        xmlWriter.WriteWhitespace("\n");
                                    }
                                    break;

                                case SaveShape.Film:
                                    if (item.Material.ToString() == "Film")
                                    {
                                        item.ToXmlWriter(xmlWriter);
                                        xmlWriter.WriteWhitespace("\n");
                                    }
                                    break;
                            }
                        }
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                    }
                }
            }
            else
            {
                XmlDocument Document = new XmlDocument();
                XmlNode boxNode = Document.CreateElement("Box");
                Document.AppendChild(boxNode);
                foreach (var item in container)
                {
                    switch (what_to_save)
                    {
                        case SaveShape.All:
                            boxNode.AppendChild(item.ToStreamWriter(Document));
                            break;

                        case SaveShape.Paper:
                            if (item.Material.ToString() == "Paper")
                            {
                                boxNode.AppendChild(item.ToStreamWriter(Document));
                            }
                            break;

                        case SaveShape.Plastic:
                            if (item.Material.ToString() == "Plastic")
                            {
                                boxNode.AppendChild(item.ToStreamWriter(Document));
                            }
                            break;

                        case SaveShape.Film:
                            if (item.Material.ToString() == "Film")
                            {
                                boxNode.AppendChild(item.ToStreamWriter(Document));
                            }
                            break;
                    }
                }
                using (StreamWriter stream = new StreamWriter(file_name, false, Encoding.UTF8))
                {
                    Document.Save(stream);
                }
            }
        }


        /// <summary>
        /// Загрузить все фигуры в коробку из XML-файла
        /// </summary>
        /// <param name="file_name">Название файла</param>
        /// <param name="load_method">Способ загрузки (StreamReader, XmlReader)</param>
        public void LoadFromXML(string file_name, XmlLoadMethod load_method)
        {
            switch (load_method)
            {
                case XmlLoadMethod.StreamReader:
                    XmlDocument document = new XmlDocument();
                    using (StreamReader stream = new StreamReader(file_name, Encoding.UTF8))
                    {
                        document.Load(stream);

                    }
                    XmlElement element = document.DocumentElement;
                    foreach (XmlNode node in element)
                    {
                        XmlNode Material, IsPainted, Color;

                        switch (node.Name)
                        {
                            case "TriangleShape":
                                XmlNode A = node.Attributes.GetNamedItem("A");
                                XmlNode B = node.Attributes.GetNamedItem("B");
                                XmlNode C = node.Attributes.GetNamedItem("C");

                                Material = node.Attributes.GetNamedItem("Material");
                                IsPainted = node.Attributes.GetNamedItem("IsPainted");
                                Color = node.Attributes.GetNamedItem("Color");

                                TriangleShape triangle = new TriangleShape(
                                    a: Double.Parse(A.InnerText),
                                    b: Double.Parse(B.InnerText),
                                    c: Double.Parse(C.InnerText),
                                    material: XmlParseMaterial(Material.InnerText)
                                    );
                                if (Convert.ToBoolean(IsPainted.InnerText))
                                {
                                    triangle.Paint((Palette)Enum.Parse(typeof(Palette), Color.InnerText));
                                }
                                Add(triangle);
                                break;

                            case "СircleShape":
                                XmlNode Radius = node.Attributes.GetNamedItem("Radius");

                                Material = node.Attributes.GetNamedItem("Material");
                                IsPainted = node.Attributes.GetNamedItem("IsPainted");
                                Color = node.Attributes.GetNamedItem("Color");

                                СircleShape сircle = new СircleShape(
                                    radius: Double.Parse(Radius.InnerText),
                                    material: XmlParseMaterial(Material.InnerText)
                                    );
                                if (Convert.ToBoolean(IsPainted.InnerText))
                                {
                                    сircle.Paint((Palette)Enum.Parse(typeof(Palette), Color.InnerText));
                                }
                                Add(сircle);
                                break;

                            case "RectangleShape":
                                XmlNode Width = node.Attributes.GetNamedItem("Width");
                                XmlNode Height = node.Attributes.GetNamedItem("Height");

                                Material = node.Attributes.GetNamedItem("Material");
                                IsPainted = node.Attributes.GetNamedItem("IsPainted");
                                Color = node.Attributes.GetNamedItem("Color");

                                RectangleShape rectangle = new RectangleShape(
                                    width: Double.Parse(Width.InnerText),
                                    height: Double.Parse(Height.InnerText),
                                    material: XmlParseMaterial(Material.InnerText)
                                    );
                                if (Convert.ToBoolean(IsPainted.InnerText))
                                {
                                    rectangle.Paint((Palette)Enum.Parse(typeof(Palette), Color.InnerText));
                                }
                                Add(rectangle);
                                break;

                            case "SquareShape":
                                XmlNode Side = node.Attributes.GetNamedItem("Side");

                                Material = node.Attributes.GetNamedItem("Material");
                                IsPainted = node.Attributes.GetNamedItem("IsPainted");
                                Color = node.Attributes.GetNamedItem("Color");

                                SquareShape square = new SquareShape(
                                    side: Double.Parse(Side.InnerText),
                                    material: XmlParseMaterial(Material.InnerText)
                                    );
                                if (Convert.ToBoolean(IsPainted.InnerText))
                                {
                                    square.Paint((Palette)Enum.Parse(typeof(Palette), Color.InnerText));
                                }
                                Add(square);
                                break;
                        }
                    }
                    break;

                case XmlLoadMethod.XmlReader:
                    using (XmlTextReader xmlReader = new XmlTextReader(file_name))
                    {
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                switch (xmlReader.Name)
                                {
                                    case "TriangleShape":
                                        TriangleShape triangle = new TriangleShape(
                                            a: Double.Parse(xmlReader.GetAttribute("A")),
                                            b: Double.Parse(xmlReader.GetAttribute("B")),
                                            c: Double.Parse(xmlReader.GetAttribute("C")),
                                            material: XmlParseMaterial(xmlReader.GetAttribute("Material"))
                                            );
                                        if (Convert.ToBoolean(xmlReader.GetAttribute("IsPainted")))
                                        {
                                            triangle.Paint((Palette)Enum.Parse(typeof(Palette), xmlReader.GetAttribute("Color")));
                                        }
                                        Add(triangle);
                                        break;

                                    case "СircleShape":
                                        СircleShape сircle = new СircleShape(
                                            radius: Double.Parse(xmlReader.GetAttribute("Radius")),
                                            material: XmlParseMaterial(xmlReader.GetAttribute("Material"))
                                            );
                                        if (Convert.ToBoolean(xmlReader.GetAttribute("IsPainted")))
                                        {
                                            сircle.Paint((Palette)Enum.Parse(typeof(Palette), xmlReader.GetAttribute("Color")));
                                        }
                                        Add(сircle);
                                        break;

                                    case "RectangleShape":
                                        RectangleShape rectangle = new RectangleShape(
                                            width: Double.Parse(xmlReader.GetAttribute("Width")),
                                            height: Double.Parse(xmlReader.GetAttribute("Height")),
                                            material: XmlParseMaterial(xmlReader.GetAttribute("Material"))
                                            );

                                        if (Convert.ToBoolean(xmlReader.GetAttribute("IsPainted")))
                                        {
                                            rectangle.Paint((Palette)Enum.Parse(typeof(Palette), xmlReader.GetAttribute("Color")));
                                        }
                                        Add(rectangle);
                                        break;
                                    case "SquareShape":
                                        SquareShape square = new SquareShape(
                                            side: Double.Parse(xmlReader.GetAttribute("Side")),
                                            material: XmlParseMaterial(xmlReader.GetAttribute("Material"))
                                            );
                                        if (Convert.ToBoolean(xmlReader.GetAttribute("IsPainted")))
                                        {
                                            square.Paint((Palette)Enum.Parse(typeof(Palette), xmlReader.GetAttribute("Color")));
                                        }
                                        Add(square);
                                        break;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Получить материал из строки. Вспомогательная функция.
        /// </summary>
        /// <param name="material">Строка с наименованием материала</param>
        /// <returns>new Material</returns>
        private Material XmlParseMaterial(string material)
        {
            switch (material)
            {
                case "Paper":
                    return new Paper();

                case "Film":
                    return new Film();

                case "Plastic":
                    return new Plastic();

                default:
                    return new Plastic();
            }
        }
        public override bool Equals(object obj)
        {
            return obj is Box box && container.Equals(box.container);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(container);
        }
        public override string ToString()
        {
            return "Box. Count: " + container.Count.ToString();
        }
    }

}
