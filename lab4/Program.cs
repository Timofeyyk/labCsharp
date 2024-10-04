
Student st1=new Student();
st1.WriteInfo();
ITStudent st2 = new ITStudent();
st2.WriteInfo();
st1.BecomeOlder();
st2.BecomeOlder();
st1.WriteInfo();
st2.WriteInfo();
Console.WriteLine("До: st2="+st2.GetType().FullName + " st1=" + st1.GetType().FullName);
st1 = st2;
Console.WriteLine("После st2="+st2.GetType().FullName + " st1=" + st1.GetType().FullName);
Console.WriteLine(st1.Birth);
st1.WriteInfo();
st1.BecomeOlder();
st1.WriteInfo();
st1.BecomeOlder();
st1.WriteInfo();
Console.WriteLine("После st1.BecomeOlder");
Console.WriteLine(st1.Birth);
st2.WriteInfo();
st2.BecomeOlder();
st2.WriteInfo();
st1.WriteInfo();
st2.BecomeOlder();
st2.WriteInfo();
st1.WriteInfo();
Console.WriteLine("После st2.BecomeOlder");
Console.WriteLine(st1.Birth);
//метод BecomeOlder для разных объектов работает по разному, в то время как WriteInfo нет, потому что при первом искользовалось
//скрытие,а во втором переопределение
class Student
{
    public String _name { get; set; }
    public int? Age { get; set; }
    public int? Birth { get; set; }

    public Student() { _name = "Arkasha";Age = 27;Birth = 2000; }
    public Student(String _name) { this._name = _name; }
    public Student(String _name, int Age)
    {
        this._name = _name;
        this.Age = Age;
    }
    public virtual void WriteInfo()
    {
        if (this.Age == null)
        {
            System.Console.WriteLine("Имя : " + this._name);
        }
        else
        {
            System.Console.WriteLine("Имя : " + this._name + ", Возраст : " + this.Age+", Birth : "+this.Birth);
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
}
abstract class Person
{
    public abstract String? Name { get; set; }

    public abstract void Info();
}
class ITStudent : Student
{
    public String Spec { get; set; }
    public ITStudent() { _name = "ITarkasha";Age = 17;Spec = "programmist"; }

    public override void WriteInfo()
    {
        if (this.Age == null)
        {
            System.Console.WriteLine("Имя : " + this._name);
        }
        else
        {
            System.Console.WriteLine("Имя : " + this._name + ", Возраст : " + this.Age+", Специальность : "+this.Spec);
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
    
}