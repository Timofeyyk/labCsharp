
using System.Xml.Linq;

Student st1 = new Student();
Console.WriteLine("st1.WriteInfo");
st1.WriteInfo();
ITStudent st2 = new ITStudent();
Console.WriteLine("st2.WriteInfo");
st2.WriteInfo();
Subject.SetFavSub("Math");
st2.WriteFavSub();
Student st3 = new Student("Ben",10);
((IPerson)st2).SayHi();
((IPerson)st2).SayGoodbye();
((ISpecialist)st2).SayHi();
((ISpecialist)st2).DoAFlip();
st3.WriteInfo();
Console.WriteLine("Сперва просто сделаем st3=st1 \nst3.WriteInfo выдает: ");
st3 = st1;
st3.WriteInfo();
st1._name = "Kira";
Console.WriteLine("После изменения st1._name на 'Kira' \nst3.WriteInfo выдает:");
st3.WriteInfo();
Console.WriteLine("Теперь метод клон, изменим st1._name на 'Mira' \nst3.WriteInfo выдает: ");
st3 = (Student)st1.Clone();
st1._name = "Mira";
Console.WriteLine("После изменения st1");
st3.WriteInfo();
Console.WriteLine();
Student st4=new Student();
Student[] students = {st1,st3,st4};


foreach (Student student in students)
{
    Console.WriteLine($"{student._name} - {student.Age} - {student.Birth}");
}

public interface ICloneable
{
    object Clone();
}

public interface IComparable
{
    object CompareTo(object obj);
}
class Student:ICloneable, IComparable
{
    public String _name { get; set; }
    public int? Age { get; set; }
    public int? Birth { get; set; }
    public static String? FavSub { get; set; }

    public Student() { _name = "Arkasha"; Age = 27; Birth = 2000; }
    public Student(String _name) { this._name = _name; }
    public Student(String _name, int Age)
    {
        this._name = _name;
        this.Age = Age;
    }
    public void WriteFavSub() 
    {
        Console.WriteLine(FavSub);
    }
    public virtual void WriteInfo()
    {
        if (this.Age == null)
        {
            System.Console.WriteLine("Имя : " + this._name);
        }
        else
        {
            System.Console.WriteLine("Имя : " + this._name + ", Возраст : " + this.Age + ", Birth : " + this.Birth);
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
            this.Birth++;
        }
    }

    public object Clone() => MemberwiseClone();

    public object CompareTo(object? obj)
    {
        if(obj is Student student)
        {
            return _name.CompareTo(student._name);
        }
        else throw new ArgumentException("Некорректное значение параметра");
    }

}
abstract class Person
{
    public abstract String? Name { get; set; }

    public abstract void Info();
}
public interface IPerson
{
    void SayHi();
    void SayGoodbye();
}
public interface ISpecialist : IPerson
{
    new void SayHi();
    void DoAFlip();
}
class ITStudent : Student,IPerson,ISpecialist
{
    public String Spec { get; set; }
    public ITStudent() { _name = "ITarkasha"; Age = 17; Spec = "programmist"; }

    public override void WriteInfo()
    {
        if (this.Age == null)
        {
            System.Console.WriteLine("Имя : " + this._name);
        }
        else
        {
            System.Console.WriteLine("Имя : " + this._name + ", Возраст : " + this.Age + ", Специальность : " + this.Spec);
        }
    }
    public new void BecomeOlder() // при скрытии необязательно, чтобы предыдущий
                                  // класс имел модификаторы virtual, abstract или override
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

    void IPerson.SayHi() { Console.WriteLine($"Привет! я {_name}, родился в {Birth}"); }
    void IPerson.SayGoodbye() { Console.WriteLine("ББ я к чб"); }

    void ISpecialist.SayHi() { Console.WriteLine($"Привет! я {Age} летка"); }
    void ISpecialist.DoAFlip() {Console.WriteLine("Ну что я делаю сальто"); }

}

public class Subject
{

    public static String? FavSub {  get; set; }

    public static void SetFavSub(string FavSub)
    {
        Student.FavSub = FavSub;    
    }

}
