Student st1 = new Student();
st1.WriteInfo();
Student st2 = new Student();
st2.WriteInfo();
try
{
    string str;
    for (int i = 0; i < 2; i++)
    {
        str = Console.ReadLine();
        st1.Age = int.Parse(str);
        st1.BecomeOlder();
        st1.WriteInfo();
    }
}
catch (SystemException ex) { Console.WriteLine(ex.Message); }
finally { Console.WriteLine("Конец отлова, в итоге st1 имеет данные такие: ");st1.WriteInfo(); }
class Student
{
    public String _name { get; set; }
    public int? Age { get; set; }
    public int? Birth { get; set; }

    public Student() { _name = "Arkasha"; Age = 27; Birth = 2000; }
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
            System.Console.WriteLine("Имя : " + this._name + ", Возраст : " + this.Age + ", Birth : " + this.Birth);
        }
    }
    public void BecomeOlder()
    {
            this.Age++;
    }
}
