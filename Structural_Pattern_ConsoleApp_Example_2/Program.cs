// Пример структурного шаблона - Адаптер (Adapter)
// Предоставляет возможность объектам с несовместимыми интерфейсами работать вместе
using System;

namespace Structural_Pattern_ConsoleApp_Example_2
{
    // Интерфейс, который описывает действие
    public interface ITarget
    {
        void Request();
    }
    // Adaptee - класс, реализующий действие
    public class Adaptee
    {
        // SpecificRequest() - метод класса Adaptee
        public void SpecificRequest()
        {
            Console.WriteLine("Выполняется конкретное действие...");
        }
    }
    // Adapter - класс наследованный от ITarget, адаптер преобразующий действие Adaptee к интерфейсу ITarget
    public class Adapter : ITarget
    {
        private Adaptee m_adaptee;
        public Adapter(Adaptee adaptee)
        {
            m_adaptee = adaptee;
        }
        public void Request()
        {
            m_adaptee.SpecificRequest();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр класса Adaptee
            Adaptee adaptee = new Adaptee();
            // Создаем адаптер
            ITarget target = new Adapter(adaptee);
            // Вызываем действие через адаптер
            target.Request();
            Console.ReadKey();
        }
    }
}
