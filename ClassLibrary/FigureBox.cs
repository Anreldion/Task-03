using System;
using System.Collections.Generic;
using System.Linq;
using Shapes.Exceptions;
using Shapes.Services.Interfaces;
using Shapes.Shapes;
using Shapes.Sheets;

namespace Shapes
{
    public class FigureBox
    {
        private const int MaxCount = 20; 
        private const double Tolerance = 0.01;
        private readonly IWriterService _writerService;
        private readonly ISerializer _serializer;
        private List<Shape> _figures = [];

        public FigureBox() { }

        public FigureBox(ISerializer serializer, IWriterService writerService)
        {
            _serializer = serializer;
            _writerService = writerService;
        }
        
        public bool AddFigure(Shape shape)
        {
            if (_figures.Count >= MaxCount)
            {
                throw new IndexOutOfRangeException();
            }

            if (_figures.Contains(shape))
            {
                throw new BoxFullException($"FigureBox already contains {shape.GetType()}");
            }

            _figures.Add(shape);
            return true;
        }

        public Shape GetFigureByIndex(int index)
        {
            if (index < 0 || _figures.Count <= index)
            {
                throw new FigureNotFoundException("Запрашиваемый номер (" + index + ") превышает число элементов в колекции!", _figures.Count);
            }
            else
            {
                return _figures[index];
            }

        }

        /// <summary>
        /// Извлечь фигуру по номеру (фигура удаляется из коробки)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Shape RemoveFigure(int index)
        {
            var shape = GetFigureByIndex(index);
            _figures.RemoveAt(index);
            return shape;
        }


        /// <summary>
        /// Заменить фигуру по номеру
        /// </summary>
        /// <param name="index">Номер элемента в коллекции</param>
        /// <param name="shape">Shape Элемент</param>
        public void ReplaceFigure(int index, Shape shape)
        {
            if (_figures.Count <= index)
            {
                throw new FigureNotFoundException("Запрашиваемый номер (" + index + ") превышает число элементов в колекции!", _figures.Count);
            }
            else
            {
                _figures[index] = shape;
            }
        }

        /// <summary>
        /// Найти фигуру по образцу (эквивалентную по своим характеристикам)
        /// </summary>
        /// <param name="area">Площадь фигуры</param>
        /// <returns></returns>
        public Shape Find(double area)
        {
            foreach (var item in _figures)
            {
                if (item.GetArea().EqualTo(area, Tolerance))
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
            return _figures.Count;
        }

        /// <summary>
        /// Получить суммарный периметр всех фигур
        /// </summary>
        /// <returns>Суммарный периметр</returns>
        public double TotalPerimeter()
        {
            return _figures.Sum(item => item.GetPerimeter());
        }

        /// <summary>
        /// Получить суммарную площадь всех фигур
        /// </summary>
        /// <returns>Сумарная площадь</returns>
        public double TotalArea()
        {
            return _figures.Sum(item => item.GetArea());
        }

        /// <summary>
        /// Получить все круги
        /// </summary>
        /// <returns>List<Shape>, иначе null</returns>
        public List<Shape> GetCircles()
        {
            return _figures.OfType<Circle>().Cast<Shape>().ToList();
        }

        /// <summary>
        /// Достать все пленочные фигуры
        /// </summary>
        /// <returns>List<Shape>, иначе null</returns>
        public List<Shape> GetFilmShapes()
        {
            return _figures.Where(item => item.Material is Film).ToList();
        }


        /// <summary>
        /// Достать все Пластиковые фигуры, которые ни разу не красились 
        /// </summary>
        /// <returns>List<Shape>, иначе null</returns>
        public List<Shape> GetNotPaintedPlasticShapes()
        {
            var shapes = new List<Shape>();
            foreach (var item in _figures)
            {
                if (item.Material.ToString() == "Plastic" && item.Material.IsPainted() == false)
                {
                    shapes.Add(item);
                }
            }
            return shapes;
        }
        public void Save(string fileName)
        {
            _writerService.Save(_figures);
        }
        public void SaveFillShapes(string fileName)
        {
            _writerService.Save(_figures);
        }
        public void SavePlasticShapes(string fileName)
        {
            _writerService.Save(_figures);
        }
        public void SavePaperShapes(string fileName)
        {
            _writerService.Save(_figures);
        }


        public void LoadFromXml(string fileName)
        {
            _figures =_writerService.Load();
        }

        public override bool Equals(object obj)
        {
            return obj is FigureBox box && _figures.Equals(box._figures);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_figures);
        }
        public override string ToString()
        {
            return "FigureBox. Count: " + _figures.Count;
        }
    }

}
