using lab_6;
using System;

namespace Lab_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Singleton
            // Устанавливаем уровень логирования и путь к файлу
            Logger logger = Logger.GetInstance();
            logger.SetLogLevel(LogLevel.INFO);  // Логировать все уровни
            logger.SetLogFilePath("C:\\Users\\bauir\\OneDrive\\Рабочий стол\\parallel_log.txt");

            // Используем Parallel.Invoke для параллельной записи в лог
            Parallel.Invoke(
                () => logger.Log("Thread 1: Info message", LogLevel.INFO),
                () => logger.Log("Thread 2: Warning message", LogLevel.WARNING),
                () => logger.Log("Thread 3: Error message", LogLevel.ERROR),
                () => logger.Log("Thread 4: Another info message", LogLevel.INFO)
            );

            // Чтение и вывод логов
            logger.ReadLogs();
            /*//Builder
            // Создаем офисный компьютер
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            ComputerDirector director = new ComputerDirector(officeBuilder);
            director.ConstructComputer();
            Computer officeComputer = director.GetComputer();

            if (director.ValidateConfiguration(officeComputer))
            {
                Console.WriteLine(officeComputer);
            }
            else
            {
                Console.WriteLine("Конфигурация офисного компьютера некорректна.");
            }

            // Создаем игровой компьютер
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            director = new ComputerDirector(gamingBuilder);
            director.ConstructComputer();
            Computer gamingComputer = director.GetComputer();
            if (director.ValidateConfiguration(gamingComputer))
            {
                Console.WriteLine(gamingComputer);
            }
            else
            {
                Console.WriteLine("Конфигурация офисного компьютера некорректна.");
            }

            // Создаем компьютер для работы с графикой
            IComputerBuilder graphicBuilder = new GraphicWorkstationBuilder();
            director = new ComputerDirector(graphicBuilder);
            Computer graphicComputer = director.GetComputer();
            director.ConstructComputer();
            if (director.ValidateConfiguration(graphicComputer))
            {
                Console.WriteLine(graphicComputer);
            }
            else
            {
                Console.WriteLine("Конфигурация офисного компьютера некорректна.");
            }*/

            /*//Prototype
            Document originalDocument = new Document(
                "Технический отчет", 
                "Основное содержание отчета",
                new List<Section> 
                {
                    new Section("Введение", "Текст введения"),
                    new Section("Основная часть", "Текст основной части")
                },
                new List<Image> 
                {
                    new Image("https://example.com/image1.png"),
                    new Image("https://example.com/image2.png")
                }
            );

            // Выводим оригинальный документ
            Console.WriteLine("Оригинальный документ:");
            Console.WriteLine(originalDocument);

            // Клонируем оригинальный документ
            DocumentManager documentManager = new DocumentManager();
            Document clonedDocument = documentManager.CreateDocument(originalDocument);

            // Выводим клонированный документ
            Console.WriteLine("\nКлонированный документ:");
            Console.WriteLine(clonedDocument);*/
        }
    }
}