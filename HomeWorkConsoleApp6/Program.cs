using System;

namespace HomeWorkConsoleApp6
{
    class Program
    {

        private static readonly FileUtil fileUtil = new();
        static void Main(string[] args)
        {
            

            bool endWork = false;
            while (!endWork)
            {
                string startWork = "Выберите действие:\n" +
                     "1) Вывести данные на экран\n" +
                     "2) Заполнить данные и добавить новую запись в конец файла\n" +
                     "3) Прекратить работу";
                var select = WaitEnterPassAddText(startWork, 1, 3);
                switch (select)
                {
                    case 1:
                        var file = fileUtil.ReadFile("data.db");
                        if (file == null)
                        {

                        }
                        else {
                            fileUtil.GetComplitedFormat(file);
                        }
                        break;
                    case 2:
                        WriteUserData();
                        break;
                    case 3:
                        endWork = true;
                        break;
                    default:
                        break;
                }
            }

        }

        private static void WriteUserData() {
            string allDataUser = "";
            Console.WriteLine("Введите:");
            Console.Write("Фамилию Имя Отчество:");
            string fullName = Console.ReadLine();
            Console.Write("Возраст:");
            string age = Console.ReadLine();
            Console.Write("Рост:");
            string height = Console.ReadLine();
            Console.Write("Дату рождения:");
            string dateOfBirth = Console.ReadLine();
            Console.Write("Место рождения:");
            string placeOfBirth = Console.ReadLine();
            var addDateTimeWriteEntry = DateTime.Now.ToString();

            var file = fileUtil.ReadFile("data.db");
            if (file == null) {
                allDataUser += "0#";
            } else {
                int id = file.Length;
                allDataUser += $"{id}#";
            }

            allDataUser += $"{addDateTimeWriteEntry}#{fullName}#{age}#{height}#{dateOfBirth}#{placeOfBirth}";
            fileUtil.WriteFile("data.db",allDataUser);
        }

        /// <summary>
        /// Проверка на правильность введённых данных с клавиатуры
        /// </summary>
        /// <param name="minValue">Минимальное допустимое значение</param>
        /// <param name="maxValue">Максимальное допустимое значение</param>
        /// <returns>Результат чтения строки (null не проходит по условиям)</returns>
        private static int? WaitEnterPass(int minValue, int maxValue)
        {
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out int outNumber);
            if (result && outNumber >= minValue && outNumber <= maxValue)
            {
                return outNumber;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Ожидает пока игрок введёт число в правильном диапазоне
        /// </summary>
        /// <param name="text">Текст который выводиться перед тем как ввести число</param>
        /// <param name="minValue">Минимальное допустимое значение</param>
        /// <param name="maxValue">Максимальное допустимое значение</param>
        /// <returns>правильно введенное число</returns>
        private static int WaitEnterPassAddText(string text, int minValue, int maxValue)
        {
            while (true)
            {
                Console.WriteLine(text);
                var readNumberOrNull = WaitEnterPass(minValue, maxValue);
                if (readNumberOrNull != null)
                {
                    return (int)readNumberOrNull;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }
        }
    }
}
