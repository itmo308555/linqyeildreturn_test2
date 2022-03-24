using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldReturnTest
{
    [MemoryDiagnoser]
    public class YieldBenchmarks
    {
        [Benchmark]
        public void CreateStudents()
        {
            var students = GetStudents(1000000);

            foreach (var student in students)
            {
                if (student.Id < 1000)
                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
                else
                    break;
            }
        }

        static IEnumerable<Student> GetStudents(int count)
        {
            var students = new List<Student>();
            for (int i = 0; i < count; i++)
            {
                students.Add(new Student() { Id = i, Name = $"Student Number {i}" });
            }
            return students;
        }

        [Benchmark]
        public void CreateStudentsYield()
        {
            var students = GetStudentsYield(1000000);

            foreach (var student in students)
            {
                if (student.Id < 1000)
                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
                else
                    break;
            }
        }

        static IEnumerable<Student> GetStudentsYield(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Student() { Id = i, Name = $"Student Number Yield {i}" };
            }
        }
    }
}
