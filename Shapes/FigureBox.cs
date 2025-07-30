using System;
using System.Collections.Generic;
using System.Linq;
using Shapes.Exceptions;
using Shapes.Extensions;
using Shapes.Services.Interfaces;
using Shapes.Shapes;
using Shapes.Sheets;

namespace Shapes
{
    /// <summary>
    /// Represents a container for storing and managing geometric shapes.
    /// Provides operations for adding, removing, replacing, filtering, and saving/loading figures.
    /// </summary>
    public class FigureBox
    {
        /// <summary>
        /// The maximum number of figures allowed in the box.
        /// </summary>
        public const int MaxCapacity = 20;

        private const double Tolerance = 0.01;
        private readonly ISaveLoadService _saveLoadService;
        private readonly List<Shape> _figures = [];

        /// <summary>
        /// Gets the current number of figures in the box.
        /// </summary>
        public int Count => _figures.Count;

        /// <summary>
        /// Initializes a new instance of the <see cref="FigureBox"/> class using the given persistence service.
        /// </summary>
        /// <param name="saveLoadService">The service used for saving and loading figures.</param>
        public FigureBox(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        /// <summary>
        /// Adds a new shape to the box.
        /// </summary>
        /// <param name="shape">The shape to add.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the box exceeds <see cref="MaxCapacity"/>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the shape already exists in the box.</exception>
        public void AddFigure(Shape shape)
        {
            if (_figures.Count >= MaxCapacity)
                throw new IndexOutOfRangeException("The box is full.");

            if (_figures.Contains(shape))
                throw new InvalidOperationException($"FigureBox already contains {shape.GetType()}.");

            _figures.Add(shape);
        }

        /// <summary>
        /// Gets a figure by its index.
        /// </summary>
        /// <param name="index">The index of the figure.</param>
        /// <returns>The requested figure.</returns>
        /// <exception cref="FigureNotFoundException">Thrown if the index is out of bounds.</exception>
        public Shape GetFigureByIndex(int index)
        {
            if (index < 0 || _figures.Count <= index)
                throw new FigureNotFoundException($"The requested index ({index}) exceeds the number of items in the collection.");

            return _figures[index];
        }

        /// <summary>
        /// Removes a figure by its index.
        /// </summary>
        /// <param name="index">The index of the figure to remove.</param>
        /// <returns>The removed shape.</returns>
        public Shape RemoveFigure(int index)
        {
            var shape = GetFigureByIndex(index);
            _figures.RemoveAt(index);
            return shape;
        }

        /// <summary>
        /// Replaces a figure at the specified index with a new one.
        /// </summary>
        /// <param name="index">The index to replace.</param>
        /// <param name="shape">The new shape to place at the index.</param>
        /// <exception cref="FigureNotFoundException">Thrown if the index is out of bounds.</exception>
        public void ReplaceFigure(int index, Shape shape)
        {
            if (index < 0 || _figures.Count <= index)
                throw new FigureNotFoundException($"The requested index ({index}) exceeds the number of items in the collection.");

            _figures[index] = shape;
        }

        /// <summary>
        /// Finds the first shape with the specified area (within tolerance).
        /// </summary>
        /// <param name="area">The area to search for.</param>
        /// <returns>A matching shape or null if not found.</returns>
        public Shape FindByArea(double area)
        {
            return _figures.FirstOrDefault(item => item.GetArea().EqualTo(area, Tolerance));
        }

        /// <summary>
        /// Calculates the total perimeter of all shapes in the box.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        public double GetTotalPerimeter()
        {
            return _figures.Sum(item => item.GetPerimeter());
        }

        /// <summary>
        /// Calculates the total area of all shapes in the box.
        /// </summary>
        /// <returns>The total area.</returns>
        public double GetTotalArea()
        {
            return _figures.Sum(item => item.GetArea());
        }

        /// <summary>
        /// Gets all figures of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of shape to filter.</typeparam>
        /// <returns>A list of shapes of the given type.</returns>
        public List<T> GetFiguresOfType<T>() where T : Shape
        {
            return _figures.OfType<T>().ToList();
        }

        /// <summary>
        /// Gets all shapes made of film material.
        /// </summary>
        /// <returns>A list of film shapes.</returns>
        public List<Shape> GetFilmShapes()
        {
            return _figures.Where(item => item.Material is Film).ToList();
        }

        /// <summary>
        /// Gets all plastic shapes that have not been painted.
        /// </summary>
        /// <returns>A list of unpainted plastic shapes.</returns>
        public List<Shape> GetNotPaintedPlasticShapes()
        {
            return _figures.Where(item => item.Material is Plastic && !item.Material.IsPainted()).ToList();
        }

        /// <summary>
        /// Saves all shapes in the box to a file.
        /// </summary>
        /// <param name="fileName">The file to save to.</param>
        public void Save(string fileName)
        {
            _saveLoadService.Save(fileName, _figures);
        }

        /// <summary>
        /// Saves only shapes made of the specified material type to a file.
        /// </summary>
        /// <typeparam name="T">The type of material to filter.</typeparam>
        /// <param name="fileName">The file to save to.</param>
        public void SaveByMaterial<T>(string fileName) where T : Material
        {
            var shapes = _figures.Where(f => f.Material is T).ToList();
            _saveLoadService.Save(fileName, shapes);
        }

        /// <summary>
        /// Loads shapes from an XML file into the box.
        /// </summary>
        /// <param name="fileName">The file to load from.</param>
        /// <exception cref="InvalidOperationException">Thrown if loaded figures exceed the max capacity.</exception>
        public void LoadFromXml(string fileName)
        {
            var loaded = _saveLoadService.Load(fileName);
            if (loaded.Count > MaxCapacity)
                throw new InvalidOperationException("Too many figures loaded.");

            _figures.Clear();
            _figures.AddRange(loaded);
        }

        /// <summary>
        /// Removes all shapes from the box.
        /// </summary>
        public void Clear() => _figures.Clear();

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is FigureBox box && _figures.SequenceEqual(box._figures);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(_figures);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"FigureBox. Count: {_figures.Count}";
        }
    }
}
