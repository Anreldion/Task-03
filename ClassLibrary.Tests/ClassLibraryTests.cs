using ClassLibrary.Shapes;
using ClassLibrary.Sheets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static ClassLibrary.Box;
using static ClassLibrary.Colors;
using static ClassLibrary.ExceptionsClass;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class ClassLibraryTests
    {

        /// <summary>
        /// Добавить фигуру. Проверка количества фигур в коробке.
        /// </summary>
        [TestMethod]
        public void Box_Add_TestCount()
        {
            // Arrange
            Box box = new Box();
            TriangleShape PaperTriangle = new TriangleShape(2, 2, 2, new Paper());
            TriangleShape FilmTriangle = new TriangleShape(2, 2, 2, new Film());
            TriangleShape PlasticTriangle = new TriangleShape(2, 2, 2, new Plastic());
            int expected_count = 3;

            // Act 
            box.Add(PaperTriangle);
            box.Add(FilmTriangle);
            box.Add(PlasticTriangle);


            // Assert 
            Assert.AreEqual(expected_count, box.Count());
            Assert.AreEqual("Paper", box[0].Material.ToString());
            Assert.AreEqual("Film", box[1].Material.ToString());
            Assert.AreEqual("Plastic", box[2].Material.ToString());
        }

        /// <summary>
        /// Добавить фигуру. Нельзя добавить одну и ту же фигуру дважды.
        /// </summary>
        [TestMethod]
        public void Box_Add_TestEqual()
        {
            // Arrange
            Box box = new Box();
            TriangleShape PlasticTriangle = new TriangleShape(2, 2, 2, new Plastic());
            bool expected_Added = false;
            bool is_added;
            int expected_count = 1;

            // Act 
            box.Add(PlasticTriangle);
            is_added = box.Add(PlasticTriangle);

            // Assert 
            Assert.AreEqual(expected_count, box.Count());
            Assert.AreEqual(expected_Added, is_added);

        }

        /// <summary>
        /// Добавить фигуру. Не более 20 фигур в коробке.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BoxArgumentException), "Исключение не работает!")]
        public void Box_Add_TestNoMoreThan20()
        {
            // Arrange
            Box box = new Box();

            // Act 
            for (int i = 0; i < 20; i++)
            {
                box.Add(new TriangleShape(a: i + 1, b: i + 1, c: i + 1, new Paper()));
            }

            box.Add(new TriangleShape(2, 2, 2, new Film()));
        }

        /// <summary>
        /// Просмотреть фигуру по номеру (фигура остается в коробке)
        /// </summary>
        [TestMethod]
        public void Box_Get_Test()
        {
            // Arrange
            Box box = new Box();
            TriangleShape triangle_0 = new TriangleShape(1, 1, 1, new Paper());
            TriangleShape triangle_1 = new TriangleShape(2, 2, 2, new Film());
            TriangleShape triangle_2 = new TriangleShape(3, 3, 3, new Plastic());
            triangle_2.Paint(Palette.Green);
            Palette expected_color = Palette.Green;
            string expected_type = "TriangleShape";

            // Act 
            box.Add(triangle_0);
            box.Add(triangle_1);
            box.Add(triangle_2);

            TriangleShape triangle_get = (TriangleShape)box.Get(2);

            // Assert
            Assert.AreEqual(expected_color, box[2].Material.GetColor());
            Assert.AreEqual(expected_type, box[2].Type);

            Assert.AreEqual(expected_color, triangle_get.Material.GetColor());
            Assert.AreEqual(expected_type, triangle_get.Type);
        }

        /// <summary>
        /// Просмотреть фигуру по номеру. Проверка исключения (количество элементов в коробке меньше запрашиваемого элемента)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BoxArgumentException), "Исключение не работает!")]
        public void Box_Get_TestException()
        {
            // Arrange
            Box box = new Box();
            TriangleShape triangle_0 = new TriangleShape(1, 1, 1, new Paper());
            triangle_0.Paint(Palette.Green);

            // Act 
            box.Add(triangle_0);
            Palette color = box[1].Material.GetColor();
        }

        /// <summary>
        /// Извлечь фигуру по номеру (фигура удаляется из коробки) + просмотр фигуры + проверка на исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(BoxArgumentException), "Исключение не работает!")]
        public void Box_Extract_Test()
        {
            // Arrange
            Box box = new Box();
            TriangleShape triangle = new TriangleShape(1, 1, 1, new Paper());
            triangle.Paint(Palette.Green);
            int expected_count = 0;
            Palette expected_color = Palette.Green;
            string expected_type = "TriangleShape";

            // Act 
            box.Add(triangle);

            TriangleShape extract_triangle = (TriangleShape)box.Extract(0);

            // Assert
            Assert.AreEqual(expected_count, box.Count());
            Assert.AreEqual(expected_color, extract_triangle.Material.GetColor());
            Assert.AreEqual(expected_type, extract_triangle.Type);
            Palette color = box[0].Material.GetColor();
        }

        /// <summary>
        /// Заменить фигуру по номеру
        /// </summary>
        [TestMethod]
        public void Box_Replace_Test()
        {
            // Arrange
            Box box = new Box();
            TriangleShape triangle_0 = new TriangleShape(1, 1, 1, new Paper());
            TriangleShape triangle_1 = new TriangleShape(2, 2, 2, new Film());
            string expected_type = "TriangleShape";

            // Act
            box.Add(triangle_0);
            box.Replace(0, triangle_1);

            // Assert
            Assert.AreEqual("Film", box[0].Material.ToString());
            Assert.AreEqual(expected_type, box[0].Type);
        }

        /// <summary>
        /// Найти фигуру по образцу (эквивалентную по своим характеристикам)
        /// </summary>
        [TestMethod]
        public void Box_Find_Test()
        {
            // Arrange
            Box box = new Box();
            TriangleShape triangle_0 = new TriangleShape(1, 1, 1, new Paper());
            TriangleShape triangle_1 = new TriangleShape(2, 2, 2, new Film());
            TriangleShape triangle_2 = new TriangleShape(3, 3, 3, new Plastic());
            double expected_area = 1.73;

            // Act
            box.Add(triangle_0);
            box.Add(triangle_1);
            box.Add(triangle_2);

            TriangleShape find_triangle = (TriangleShape)box.Find(expected_area);

            // Assert
            Assert.AreEqual(expected_area, find_triangle.Area, 0.01);
        }

        /// <summary>
        /// Получить суммарный периметр всех фигур
        /// </summary>
        [TestMethod]
        public void Box_TotalPerimeter_Test()
        {
            // Arrange
            Box box = new Box();
            TriangleShape triangle_0 = new TriangleShape(1, 1, 1, new Paper());
            TriangleShape triangle_1 = new TriangleShape(2, 2, 2, new Film());
            TriangleShape triangle_2 = new TriangleShape(3, 3, 3, new Plastic());
            double expected_total_perimeter = 18;

            // Act
            box.Add(triangle_0);
            box.Add(triangle_1);
            box.Add(triangle_2);

            double total_perimeter = box.TotalPerimeter();

            // Assert
            Assert.AreEqual(expected_total_perimeter, total_perimeter, 0.01);

        }

        /// <summary>
        /// Получить суммарную площадь всех фигур
        /// </summary>
        [TestMethod]
        public void Box_TotalArea_Test()
        {
            // Arrange
            Box box = new Box();
            TriangleShape triangle_0 = new TriangleShape(1, 1, 1, new Paper());
            TriangleShape triangle_1 = new TriangleShape(2, 2, 2, new Film());
            TriangleShape triangle_2 = new TriangleShape(3, 3, 3, new Plastic());
            double expected_total_area = 6.062;

            // Act
            box.Add(triangle_0);
            box.Add(triangle_1);
            box.Add(triangle_2);

            double total_area = box.TotalArea();

            // Assert
            Assert.AreEqual(expected_total_area, total_area, 0.01);

        }

        /// <summary>
        /// Получить все круги из коробки
        /// </summary>
        [TestMethod]
        public void Box_GetAllCircles_Test()
        {
            // Arrange
            Box box = new Box();
            List<ShapeBase> shapes;
            box.Add(new TriangleShape(1, 1, 1, new Paper()));
            box.Add(new TriangleShape(2, 2, 2, new Film()));
            box.Add(new TriangleShape(3, 3, 3, new Plastic()));
            box.Add(new СircleShape(1, new Paper()));
            box.Add(new СircleShape(2, new Paper()));
            box.Add(new СircleShape(3, new Paper()));
            box.Add(new RectangleShape(1, 1, new Paper()));
            box.Add(new RectangleShape(2, 2, new Paper()));
            box.Add(new RectangleShape(3, 3, new Paper()));
            box.Add(new SquareShape(1, new Paper()));
            box.Add(new SquareShape(2, new Paper()));
            box.Add(new SquareShape(3, new Paper()));
            int expected_count = 3;

            // Act
            shapes = box.GetAllCircles();

            // Assert
            Assert.AreEqual(expected_count, shapes.Count);
        }

        /// <summary>
        /// Достать все пленочные фигуры из коробки
        /// </summary>
        [TestMethod]
        public void Box_GetFilmShapes_Test()
        {
            // Arrange
            Box box = new Box();
            List<ShapeBase> shapes;
            box.Add(new TriangleShape(1, 1, 1, new Paper()));
            box.Add(new TriangleShape(2, 2, 2, new Film()));
            box.Add(new TriangleShape(3, 3, 3, new Plastic()));
            box.Add(new СircleShape(1, new Film()));
            box.Add(new СircleShape(2, new Paper()));
            box.Add(new СircleShape(3, new Plastic()));
            box.Add(new RectangleShape(1, 1, new Paper()));
            box.Add(new RectangleShape(2, 2, new Plastic()));
            box.Add(new RectangleShape(3, 3, new Paper()));
            box.Add(new SquareShape(1, new Plastic()));
            box.Add(new SquareShape(2, new Paper()));
            box.Add(new SquareShape(3, new Film()));
            int expected_count = 3;

            // Act
            shapes = box.GetFilmShapes();

            // Assert
            Assert.AreEqual(expected_count, shapes.Count);
        }

        /// <summary>
        /// Достать все пастиковые фигуры, из коробки, которые ни разу не красились
        /// </summary>
        [TestMethod]
        public void Box_GetNotPaintedPlasticShapes_Test()
        {
            // Arrange
            Box box = new Box();
            List<ShapeBase> shapes;
            box.Add(new TriangleShape(1, 1, 1, new Paper(Palette.Blue)));
            box.Add(new TriangleShape(2, 2, 2, new Film()));
            box.Add(new TriangleShape(3, 3, 3, new Plastic(Palette.Orange)));
            box.Add(new СircleShape(1, new Paper(Palette.LightBlue)));
            box.Add(new СircleShape(2, new Film()));
            box.Add(new СircleShape(3, new Plastic()));
            box.Add(new RectangleShape(1, 1, new Paper(Palette.Violet)));
            box.Add(new RectangleShape(2, 2, new Film()));
            box.Add(new RectangleShape(3, 3, new Plastic(Palette.Red)));
            box.Add(new SquareShape(1, new Paper(Palette.Green)));
            box.Add(new SquareShape(2, new Film()));
            box.Add(new SquareShape(3, new Plastic()));
            int expected_count = 2;

            // Act
            shapes = box.GetNotPaintedPlasticShapes();

            // Assert
            Assert.AreEqual(expected_count, shapes.Count);
        }

        /// <summary>
        /// Используя классы StreamReader и StreamWriter обеспечить загрузку/сохранение данных из XML-файла
        /// </summary>
        [TestMethod]
        public void XML_StreamReaderWriter_Test()
        {
            // Arrange
            TriangleShape triangle_0 = new TriangleShape(2, 2, 2, new Paper(Palette.Blue));
            TriangleShape triangle_1 = new TriangleShape(3, 3, 3, new Film());
            Box box_save = new Box();
            box_save.Add(triangle_0);
            box_save.Add(triangle_1);
            int expected_count = box_save.Count();
            Box box_load = new Box();


            // Act 
            box_save.SaveToXML("StreamWriterTest.xml", Box.SaveShape.All, XmlSaveMethod.StreamWriter);
            box_load.LoadFromXML("StreamWriterTest.xml", XmlLoadMethod.StreamReader);

            // Assert 
            Assert.AreEqual(expected_count, box_load.Count());
            Assert.AreEqual("TriangleShape", box_load[0].Type);

        }

        /// <summary>
        /// Используя классы XmlReader и XmlWriter обеспечить чтение/сохранение данных в XML-файл
        /// </summary>
        [TestMethod]
        public void XML_XmlReaderlWriter_Test()
        {
            // Arrange
            TriangleShape triangle_0 = new TriangleShape(2, 2, 2, new Paper(Palette.Blue));
            TriangleShape triangle_1 = new TriangleShape(3, 3, 3, new Film());
            Box box_save = new Box();
            box_save.Add(triangle_0);
            box_save.Add(triangle_1);
            Box box_load = new Box();
            int expected_count = box_save.Count();

            // Act 
            box_save.SaveToXML("XmlReaderTest.xml", Box.SaveShape.All, XmlSaveMethod.XmlWriter);
            box_load.LoadFromXML("XmlReaderTest.xml", XmlLoadMethod.XmlReader);

            // Assert
            Assert.AreEqual(expected_count, box_load.Count());
            Assert.AreEqual("TriangleShape", box_load[0].Type);
        }

        /// <summary>
        /// Обеспечить взаимное чтение/сохранение данных классами XmlWriter и StreamReader, StreamWriter и XmlReader
        /// </summary>
        [TestMethod]
        public void XML_ReadersWriters_CombineTest()
        {
            // Arrange
            TriangleShape triangle = new TriangleShape(2, 2, 2, new Paper(Palette.Blue));
            TriangleShape triangle2 = new TriangleShape(3, 3, 3, new Film());
            Box box_save = new Box();
            box_save.Add(triangle);
            box_save.Add(triangle2);
            Box box_loadStreamReader = new Box();
            Box box_loadXmlReader = new Box();
            int expected_count = box_save.Count();
            // Act 
            box_save.SaveToXML("StreamWriterTest.xml", Box.SaveShape.All, XmlSaveMethod.StreamWriter);
            box_save.SaveToXML("XmlWriterTest.xml", Box.SaveShape.All, XmlSaveMethod.XmlWriter);

            box_loadXmlReader.LoadFromXML("StreamWriterTest.xml", XmlLoadMethod.XmlReader);
            box_loadStreamReader.LoadFromXML("XmlWriterTest.xml", XmlLoadMethod.StreamReader);

            // Assert
            Assert.AreEqual(expected_count, box_loadXmlReader.Count());
            Assert.AreEqual("TriangleShape", box_loadXmlReader[0].Type);

            Assert.AreEqual(expected_count, box_loadStreamReader.Count());
            Assert.AreEqual("TriangleShape", box_loadStreamReader[0].Type);
        }


        /// <summary>
        /// Cохранить все фигуры
        /// </summary>
        [TestMethod]
        public void XML_SaveAllShapes_Test()
        {
            // Arrange
            Box box = new Box();
            box.Add(new RectangleShape(1, 1, new Paper(Palette.Violet)));
            box.Add(new RectangleShape(2, 2, new Film()));
            box.Add(new RectangleShape(3, 3, new Plastic(Palette.Red)));

            box.Add(new TriangleShape(1, 1, 1, new Paper(Palette.Blue)));
            box.Add(new TriangleShape(2, 2, 2, new Film()));
            box.Add(new TriangleShape(3, 3, 3, new Plastic(Palette.Orange)));

            box.Add(new СircleShape(1, new Paper(Palette.LightBlue)));
            box.Add(new СircleShape(2, new Film()));
            box.Add(new СircleShape(3, new Plastic(Palette.Yellow)));

            box.Add(new SquareShape(1, new Paper(Palette.Green)));
            box.Add(new SquareShape(2, new Film()));
            box.Add(new SquareShape(3, new Plastic(Palette.Violet)));

            int expected_count = 12;
            Box box_load = new Box();
            // Act
            box.SaveToXML("AllShapesTest.xml", Box.SaveShape.All, XmlSaveMethod.StreamWriter);
            box_load.LoadFromXML("AllShapesTest.xml", XmlLoadMethod.StreamReader);

            // Assert
            Assert.AreEqual(expected_count, box_load.Count());
        }

        /// <summary>
        /// Cохранить только бумажные фигуры
        /// </summary>
        [TestMethod]
        public void XML_SaveOnlyPaperShapes_Test()
        {
            // Arrange
            Box box = new Box();
            box.Add(new RectangleShape(1, 1, new Paper(Palette.Violet)));
            box.Add(new RectangleShape(2, 2, new Film()));
            box.Add(new RectangleShape(3, 3, new Plastic(Palette.Red)));

            box.Add(new TriangleShape(1, 1, 1, new Paper(Palette.Blue)));
            box.Add(new TriangleShape(2, 2, 2, new Film()));
            box.Add(new TriangleShape(3, 3, 3, new Plastic(Palette.Orange)));
            box.Add(new СircleShape(1, new Paper(Palette.LightBlue)));
            box.Add(new СircleShape(2, new Film()));
            box.Add(new СircleShape(3, new Plastic()));

            box.Add(new SquareShape(1, new Paper(Palette.Green)));
            box.Add(new SquareShape(2, new Film()));
            box.Add(new SquareShape(3, new Plastic()));
            int expected_count = 4;
            Box box_load = new Box();
            // Act
            box.SaveToXML("OnlyPaperTest.xml", Box.SaveShape.Paper, XmlSaveMethod.StreamWriter);
            box_load.LoadFromXML("OnlyPaperTest.xml", XmlLoadMethod.StreamReader);

            // Assert
            Assert.AreEqual(expected_count, box_load.Count());
            Assert.AreEqual("Paper", box_load[0].Material.ToString());
        }

        /// <summary>
        /// Cохранить только пластиковые фигуры
        /// </summary>
        [TestMethod]
        public void XML_SaveOnlyPlasticShapes_Test()
        {
            // Arrange
            Box box = new Box();
            box.Add(new TriangleShape(1, 1, 1, new Paper(Palette.Blue)));
            box.Add(new TriangleShape(2, 2, 2, new Film()));
            box.Add(new TriangleShape(3, 3, 3, new Plastic(Palette.Orange)));
            box.Add(new СircleShape(1, new Paper(Palette.LightBlue)));
            box.Add(new СircleShape(2, new Film()));
            box.Add(new СircleShape(3, new Plastic()));
            box.Add(new RectangleShape(1, 1, new Paper(Palette.Violet)));
            box.Add(new RectangleShape(2, 2, new Film()));
            box.Add(new RectangleShape(3, 3, new Plastic(Palette.Red)));
            box.Add(new SquareShape(1, new Paper(Palette.Green)));
            box.Add(new SquareShape(2, new Film()));
            box.Add(new SquareShape(3, new Plastic()));
            int expected_count = 4;
            Box box_load = new Box();

            // Act
            box.SaveToXML("OnlyPlasticTest.xml", Box.SaveShape.Plastic, XmlSaveMethod.XmlWriter);
            box_load.LoadFromXML("OnlyPlasticTest.xml", XmlLoadMethod.XmlReader);

            // Assert
            Assert.AreEqual(expected_count, box_load.Count());
            Assert.AreEqual("Plastic", box_load[0].Material.ToString());
        }

        /// <summary>
        /// Cохранить только плёночные фигуры
        /// </summary>
        [TestMethod]
        public void XML_SaveOnlyFilmShapes_Test()
        {
            // Arrange
            Box box = new Box();
            box.Add(new TriangleShape(1, 1, 1, new Paper(Palette.Blue)));
            box.Add(new TriangleShape(2, 2, 2, new Film()));
            box.Add(new TriangleShape(3, 3, 3, new Plastic(Palette.Orange)));
            box.Add(new СircleShape(1, new Paper(Palette.LightBlue)));
            box.Add(new СircleShape(2, new Film()));
            box.Add(new СircleShape(3, new Plastic()));
            box.Add(new RectangleShape(1, 1, new Paper(Palette.Violet)));
            box.Add(new RectangleShape(2, 2, new Film()));
            box.Add(new RectangleShape(3, 3, new Plastic(Palette.Red)));
            box.Add(new SquareShape(1, new Paper(Palette.Green)));
            box.Add(new SquareShape(2, new Film()));
            box.Add(new SquareShape(3, new Plastic()));
            int expected_count = 4;
            Box box_load = new Box();

            // Act
            box.SaveToXML("OnlyFilmTest.xml", Box.SaveShape.Film, XmlSaveMethod.StreamWriter);
            box_load.LoadFromXML("OnlyFilmTest.xml", XmlLoadMethod.StreamReader);

            // Assert
            Assert.AreEqual(expected_count, box_load.Count());
            Assert.AreEqual("Film", box_load[0].Material.ToString());
        }


        /// <summary>
        /// Создать фигуру из листа бумаги, пленки, пластика.
        /// </summary>
        [TestMethod]
        public void CreateShapesFromSheet_Test()
        {
            // Arrange
            TriangleShape PaperTriangle = new TriangleShape(2, 2, 2, new Paper());
            SquareShape FilmTriangle = new SquareShape(2, new Film());
            СircleShape PlasticTriangle = new СircleShape(2, new Plastic());

            // Act 

            // Assert 
            Assert.AreEqual("Paper", PaperTriangle.Material.ToString());
            Assert.AreEqual("Film", FilmTriangle.Material.ToString());
            Assert.AreEqual("Plastic", PlasticTriangle.Material.ToString());
        }


        /// <summary>
        /// Вырезать фигуру из фигуры. 
        /// </summary>
        [TestMethod]
        public void CreateShapesFromShapes_Test()
        {
            // Arrange
            TriangleShape triangle = new TriangleShape(2, 2, 2, new Paper(Palette.Blue));

            // Act 
            TriangleShape triangle_cut = new TriangleShape(1, 1, 1, triangle);

            // Assert 
            Assert.AreEqual("Paper", triangle_cut.Material.ToString());
            Assert.AreEqual(Palette.Blue, triangle_cut.Material.GetColor());

            //уменьшение площади оригинальной фигуры
            Assert.AreEqual(1.32, triangle.Area, 0.01);
        }

        /// <summary>
        /// Вырезать фигуру из фигуры. Получить исключение, если вырезаемая фигура больше основной.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ShapeExceptions), "Исключение не работает!")]
        public void CreateShapesFromShapes_ExceptionTest()
        {
            // Arrange
            TriangleShape triangle = new TriangleShape(2, 2, 2, new Paper(Palette.Blue));

            // Act 
            TriangleShape triangle_cut = new TriangleShape(3, 3, 3, triangle);

            // Exception!
        }

        /// <summary>
        /// Получить площадь фигуры
        /// </summary>
        [TestMethod]
        public void ShapeAreaGet_Test()
        {
            // Arrange
            TriangleShape triangle;
            SquareShape square;
            RectangleShape rectangle;
            СircleShape сircle;

            // Act 
            triangle = new TriangleShape(2, 2, 2, new Paper());
            square = new SquareShape(2, new Paper());
            rectangle = new RectangleShape(2, 2, new Paper());
            сircle = new СircleShape(2, new Paper());


            // Assert 
            Assert.AreEqual(triangle.Area, 1.73, 0.01);
            Assert.AreEqual(square.Area, 4, 0.01);
            Assert.AreEqual(rectangle.Area, 4, 0.01);
            Assert.AreEqual(сircle.Area, 12.56, 0.01);

        }

        /// <summary>
        /// Получить периметр фигуры
        /// </summary>
        [TestMethod]
        public void ShapePerimeterGet_Test()
        {
            // Arrange
            TriangleShape triangle;
            SquareShape square;
            RectangleShape rectangle;
            СircleShape сircle;

            // Act 
            triangle = new TriangleShape(2, 2, 2, new Paper());
            square = new SquareShape(2, new Paper());
            rectangle = new RectangleShape(2, 2, new Paper());
            сircle = new СircleShape(2, new Paper());

            // Assert 
            Assert.AreEqual(triangle.Perimeter, 6, 0.01);
            Assert.AreEqual(square.Perimeter, 8, 0.01);
            Assert.AreEqual(rectangle.Perimeter, 8, 0.01);
            Assert.AreEqual(сircle.Perimeter, 12.56, 0.01);

        }
    }
}
