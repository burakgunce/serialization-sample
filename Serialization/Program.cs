using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Serialization();

            //XMLSerialization();

            //JSONSerialization();

        }

        private static void JSONSerialization()
        {
            //JSON Serialization
            const string filePath = "Student.json";

            Student student = new Student();
            student.ID = Guid.NewGuid();
            student.FirstName = "John";
            student.LastName = "Doe";
            student.BirthDate = DateTime.Now.AddYears(-45);
            student.Email = "john.doe@hotmail.com";
            student.Phone = "661 611 6161";
            student.AveragePoint = 61.61;
            student.StudentNotes = "Sample Text";

            FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using (stream)
            {
                JsonSerializer.Serialize(stream, student);
            }

            FileStream stream2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            Student studentRead = JsonSerializer.Deserialize<Student>(stream2);
            Console.WriteLine($"ID : {studentRead.ID}");
            Console.WriteLine($"Name : {studentRead.FirstName}");
            Console.WriteLine($"BirthDate : {studentRead.BirthDate}");
        }

        private static void XMLSerialization()
        {
            // XML Serialization
            const string filePath = "Student.xml";

            Student student = new Student();
            student.ID = Guid.NewGuid();
            student.FirstName = "John";
            student.LastName = "Doe";
            student.BirthDate = DateTime.Now.AddYears(-45);
            student.Email = "john.doe@hotmail.com";
            student.Phone = "661 611 6161";
            student.AveragePoint = 61.61;
            student.StudentNotes = "Sample Text";

            XmlSerializer xml = new XmlSerializer(typeof(Student));
            FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using (stream)
            {
                xml.Serialize(stream, student);
            }

            FileStream stream2 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            Student studentRead = (Student)xml.Deserialize(stream2);
            Console.WriteLine($"ID : {studentRead.ID}");
            Console.WriteLine($"Name : {studentRead.FirstName}");
            Console.WriteLine($"BirthDate : {studentRead.BirthDate}");
        }

        private static void Serailization()
        {
            const string filePath = "Student.txt";

            IFormatter binaryFormatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            Student student = new Student();
            student.ID = Guid.NewGuid();
            student.FirstName = "John";
            student.LastName = "Doe";
            student.BirthDate = DateTime.Now.AddYears(-45);
            student.Email = "john.doe@hotmail.com";
            student.Phone = "661 611 6161";
            student.AveragePoint = 61.61;
            student.StudentNotes = "Sample Text";

            binaryFormatter.Serialize(stream, student);
            stream.Close();

            Console.ReadLine();

            Console.WriteLine("Öğrenci bilgilerini dosyadan okumak");

            stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            Student studentRead = (Student)binaryFormatter.Deserialize(stream);
            Console.WriteLine($"ID : {studentRead.ID}");
            Console.WriteLine($"Name : {studentRead.FirstName}");
            Console.WriteLine($"BirthDate : {studentRead.BirthDate}");
        }
    }
}