# Task-03
Inheritance. Interfaces. Abstract classes.

Структура проекта:

ColorationInterface - Папка. Содержит интерфейс и реализации интерфейса.
- IColoration - Интерфейс. Поведение при окрашивании.
- ColoringMultiple - Класс. Множественное окрашивание. Реализация интерфейса.
- ColoringOnce - Класс. Однократное окрашивание. Реализация интерфейса.
- NoColoring - Класс. Окрашивание невозможно. Реализация интерфейса.

Material Class - Папка. Содержит абстрактный класс и классы наследники.
- Material - Абстрактный класс - Материал.
- Film - Класс. Фигуры из пленки бесцветные и красить их нельзя.
- Paper- Класс. Бумажные фигуры можно красить, но только 1 раз.
- Plastic - Класс. Фигуры из пластика можно многократно перекрашивать. 

Shapes - Папка. Содержит абстрактный класс и классы наследники.
- ShapeBase - Абстрактный класс - Фигура.
- RectangleShape. Класс наследник. Прямоугольник.
- SquareShape. Класс наследник. Квадрат.
- TriangleShape. Класс наследник. Треугольник.
- СircleShape. Класс наследник. Круг.

ClassLibrary.Tests - Модульные тесты. Проверяет:
- Box. Добавить фигуру. Проверка количества фигур в коробке.
- Box. Добавить фигуру. Нельзя добавить одну и ту же фигуру дважды.
- Box. Добавить фигуру. Не более 20 фигур в коробке.
- Box. Просмотреть фигуру по номеру (фигура остается в коробке)
- Box. Просмотреть фигуру по номеру. Проверка исключения (количество элементов в коробке меньше запрашиваемого элемента)
- Box. Извлечь фигуру по номеру (фигура удаляется из коробки) + просмотр фигуры + проверка на исключение
- Box. Заменить фигуру по номеру
- Box. Найти фигуру по образцу (эквивалентную по своим характеристикам)
- Box. Получить суммарный периметр всех фигур
- Box. Получить суммарную площадь всех фигур
- Box. Получить все круги из коробки
- Box. Достать все пленочные фигуры из коробки
- Box. Достать все пастиковые фигуры, из коробки, которые ни разу не красились
- XML. Используя классы StreamReader и StreamWriter обеспечить загрузку/сохранение данных из XML-файла
- XML. Используя классы XmlReader и XmlWriter обеспечить чтение/сохранение данных в XML-файл
- XML. Обеспечить взаимное чтение/сохранение данных классами XmlWriter и StreamReader, StreamWriter и XmlReader
- XML. Cохранить все фигуры
- XML. Cохранить только бумажные фигуры
- XML. Cохранить только пластиковые фигуры
- XML. Cохранить только плёночные фигуры
- Shapes. Создать фигуру из листа бумаги, пленки, пластика.
- Shapes. Вырезать фигуру из фигуры.
- Shapes. Получить площадь фигуры
- Shapes. Получить периметр фигуры
