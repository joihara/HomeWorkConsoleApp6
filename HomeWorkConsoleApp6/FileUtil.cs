using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWorkConsoleApp6
{
    public class FileUtil
    {
        public void WriteFile(string NameFile, string text) {

            string writePath = NameFile;
            try
            {
                using (StreamWriter sw = new(writePath, true, Encoding.Default))
                {
                    sw.WriteLine(text);
                }

                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public StructUserInfo[] ReadFile(string NameFile) {
            List<StructUserInfo> data = new();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new(NameFile);
                //Read the first line of text
                var line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    var userInfo = ParcerString(line);
                    data.Add(userInfo);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                return data.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void GetComplitedFormat(StructUserInfo[] input)
        {
            Console.WriteLine("ID|AddDateTimeWriteEntry|FullName|Age|Height|DateOfBirth|PlaceOfBirth");

            foreach (var item in input) {
                Console.WriteLine($"{GetComplitedFormat(item)}");
            }
        }

        public string GetComplitedFormat(StructUserInfo input)
        {
            return $"{input.ID}|{input.AddDateTimeWriteEntry,10}|{input.FullName,10}|{input.Age,10}|{input.Height,10}|{input.DateOfBirth,10}|{input.PlaceOfBirth,10}";
        }

        public StructUserInfo ParcerString(string text)
        {
            StructUserInfo userInfo = new();

                var arrayData = text.Split('#');
                

                if (arrayData.Length == 7)
                {


                    var ok1 = int.TryParse(arrayData[0], out int id);
                    var addDateTimeWriteEntry = arrayData[1];
                    var fullName = arrayData[2];
                    var ok2 = int.TryParse(arrayData[3], out int age);
                    var ok3 = int.TryParse(arrayData[4], out int height);
                    var dateOfBirth = arrayData[5];
                    var placeOfBirth = arrayData[6];
                    var allOk = ok1 && ok2 && ok3 && arrayData.Length == 7;
                    if (allOk)
                    {
                        userInfo = new StructUserInfo
                        {
                            ID = id,
                            AddDateTimeWriteEntry = addDateTimeWriteEntry,
                            Age = age,
                            Height = height,
                            DateOfBirth = dateOfBirth,
                            FullName = fullName,
                            PlaceOfBirth = placeOfBirth

                        };
                    }
                }

            return userInfo;
        }

    }
}
