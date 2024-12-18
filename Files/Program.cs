using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace Files
{
    using System;
    using System.IO;
    using System.Runtime.Remoting.Messaging;
    using System.Text;

    class Program
    {

        public static void Main()
        {

            
            try
            {
                DeleteFile();
                
                /*  //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line); 
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();*/

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        //Чтение файла
        public static void GetText()
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();
            StreamReader sr = new StreamReader(path);

            var line = sr.ReadToEnd();

            Console.WriteLine(line);

        }

        public static void DeleteFile()
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }

            Console.WriteLine($"Файл по пути {path} успешно удален");
        }

        public static void EditFile()
        {
            Console.WriteLine("Введите путь к файлу:");
            string path = Console.ReadLine();


            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден");
                return;
            }

            try
            {

                string currenttextoffile = File.ReadAllText(path);
                Console.WriteLine("Текущее содержимое файла:");
                Console.WriteLine(currenttextoffile);


                Console.WriteLine("Введите новый текст");
                string newtext = Console.ReadLine();


                if (!string.IsNullOrWhiteSpace(newtext))
                {
                    File.WriteAllText(path, newtext);
                    Console.WriteLine("Файл успешно изменен");
                }
                else
                {
                    Console.WriteLine("Файл не был изменен");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при изменении файла: {ex.Message}");
            }
        }

        public static void AddFile()
        {
            Console.WriteLine("Введите путь куда вы хотите запихнуть файл вместе с тем как он будет называться:");
            string path = Console.ReadLine();
            try
            {
                // Создание файла
                using (FileStream fs = File.Create(path))
                {
                    //Добавление чтоб файл не был пустым изначально
                    byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    fs.Write(info, 0, info.Length);
                }

                // Читаем что получилось
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

