using System.Diagnostics;

System.Console.OutputEncoding = System.Text.Encoding.UTF8;

Student st1 = new Student();
Student st2 = new Student("Kenso",22);
Student st3 = new Student("Oleg");
Student st4 = new() { _name = "Krio", Age = 10 };

st1.WriteInfo();
st2.WriteInfo();
st3.WriteInfo();
st4.WriteInfo();
Console.WriteLine($" {Student.DefaultPassword}");
Student.DefaultPassword = "123456";
Student.PassInfo();
Console.WriteLine($" Изначально у всех студентов пароль - {Student.DefaultPassword}");
Console.WriteLine($" {st4._name } имеет пароль {Student.DefaultPassword}");
Student.DefaultPassword = "123123132131";
Student.PassInfo();
Univer.Name = "SGU Sorokina";
Console.WriteLine($" {"Сейчас все студнеты университета "+Student.UniverName}");

Univer.Name = "MGU";
Console.WriteLine($" {"Сейчас все студнеты университета "+Student.UniverName}");
public class Student
{
    public String _name { get; set; }
    public int? Age { get; set; }
    public static String? UniverName;

    public static String DefaultPassword { get; set; }
    static Student()
    {

        UniverName = null;
        DefaultPassword = "123";
    }
    public static void PassInfo()
    {
        Console.WriteLine($" Сейчас обычный пароль для всех это - {DefaultPassword}");
    }


    public Student()
    {
        this._name = "default";
        this.Age = 0;
    }
    public Student(String _name) { this._name = _name; }
    public Student(String _name, int Age)
    {
        this._name = _name;
        this.Age = Age;
    }
    public void WriteInfo()
    {
        if (this.Age == null)
        {
            System.Console.WriteLine("Имя : " + this._name);
        }
        else
        {
            System.Console.WriteLine("Имя : " + this._name + ", Возраст : " + this.Age);
        }
    }
    public void BecomeOlder()
    {
        if (this.Age == null)
        {
            System.Console.WriteLine("Возраст не указан");
        }
        else
        {
            this.Age++;
        }
    }
}
public static class Univer {

    public static String? Name { get => Name; set => Student.UniverName = value; }

    static Univer()
    {
        Name = "SGU";
    }
    
}