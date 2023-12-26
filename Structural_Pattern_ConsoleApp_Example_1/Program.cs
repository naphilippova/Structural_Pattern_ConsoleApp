// Пример структурного шаблона - Декоратор (Decorator)
// Предоставляет возможность динамически добавлять новое поведение к объекту без необходимости изменять его исходный код
using System;
using System.Collections.Generic;

namespace Structural_Pattern_ConsoleApp_Example_1
{
    // Абстрактный класс RestaurantDish (блюдо в ресторане)
    abstract class RestaurantDish
    {
        public abstract void Display();
    }
    // Класс конкретного блюда FreshSalad (свежий салат)
    class FreshSalad : RestaurantDish
    {
        // Приватные поля: зелень, сыр, заправка
        private string m_greens;
        private string m_cheese;
        private string m_dressing;
        // Конструктор для FreshSalad
        public FreshSalad(string greens, string cheese, string dressing)
        {
            m_greens = greens;
            m_cheese = cheese;
            m_dressing = dressing;
        }
        // Покажы ингредиенты блюда
        public override void Display()
        {
            Console.WriteLine("\nFresh Salad:");
            Console.WriteLine(" Зелень: {0}", m_greens);
            Console.WriteLine(" Сыр: {0}", m_cheese);
            Console.WriteLine(" Заправка: {0}", m_dressing);
        }
    }
    // Класс конкретного блюда Pasta (макароны)
    class Pasta : RestaurantDish
    {
        // Приватные поля: макароны (тип), соус
        private string m_pastaType;
        private string m_sauce;
        // Конструктор для Pasta
        public Pasta(string pastaType, string sauce)
        {
            m_pastaType = pastaType;
            m_sauce = sauce;
        }
        // Покажы ингредиенты блюда
        public override void Display()
        {
            Console.WriteLine("\nКлассическая паста:");
            Console.WriteLine(" Паста: {0}", m_pastaType);
            Console.WriteLine(" Соус: {0}", m_sauce);
        }
    }
    // Абстрактный класс Decorator наследован от RestaurantDish
    abstract class Decorator : RestaurantDish
    {
        // Защищённое поле блюдо
        protected RestaurantDish m_dish;
        // Коструктор для Decorator
        public Decorator(RestaurantDish dish)
        {
            m_dish = dish;
        }
        // Покажы ингредиенты блюда
        public override void Display()
        {
            m_dish.Display();
        }
    }
    // Этот класс (наследован от Decorator) будет проверять блюда,
    // например, достаточно ли в этих блюдах ингредиентов для их заказа
    class Available : Decorator
    {
        // Переменная NumAvailable, смысл сколько можем сделать?
        public int NumAvailable { get; set; }
        // Лист клиентов
        protected List<string> customers = new List<string>();
        public Available(RestaurantDish dish, int numAvailable) : base(dish)
        {
            NumAvailable = numAvailable;
        }
        public void OrderItem(string name)
        {
            if (NumAvailable > 0)
            {
                customers.Add(name);
                NumAvailable--;
            }
            else
            {
                Console.WriteLine($"\nНедостаточно ингредиентов для блюда клиента {name}...");
            }
        }
        // Покажы заказы клиентов
        public override void Display()
        {
            base.Display();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Заказ {customer}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Определяем несколько блюд и сколько каждого из них мы можем приготовить.
            FreshSalad caesarSalad = new FreshSalad("Хрустящий салат", "Натёртый сыр Пармезан", "Домашняя заправка Цезарь");
            caesarSalad.Display();
            Pasta fettuccineAlfredo = new Pasta("Свежеприготовленные макароны", "Сливочно-чесночный соус");
            fettuccineAlfredo.Display();
            Console.WriteLine("\nЭти блюда доступны для заказа.");
            // Если мы попытаемся заказать их, когда у нас закончатся ингредиенты, мы сможем уведомить об этом клиента
            Available caesarAvailable = new Available(caesarSalad, 3);
            Available alfredoAvailable = new Available(fettuccineAlfredo, 4);
            // Заказы несколько блюд
            caesarAvailable.OrderItem("Иван");
            caesarAvailable.OrderItem("Наталья");
            caesarAvailable.OrderItem("Мария");
            alfredoAvailable.OrderItem("Наталья");
            alfredoAvailable.OrderItem("Пётр");
            alfredoAvailable.OrderItem("Семён");
            alfredoAvailable.OrderItem("Денис");
            alfredoAvailable.OrderItem("Владимир");
            caesarAvailable.Display();
            alfredoAvailable.Display();
            Console.ReadKey();
        }
    }
}
