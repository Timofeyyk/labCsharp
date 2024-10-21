Student st1 = new Student();
st1.WriteInfo();
Student st2 = new Student("Bisa",20);
st2.WriteInfo();
string? str="0";
try
{ 
    for (int i = 0; i < 2; i++)
    {
        str = Console.ReadLine();
        st1.Age = int.Parse(str)-1;
        st1.BecomeOlder();
        st1.WriteInfo();
    }
}
catch (SystemException ex) { Console.WriteLine("Нужно ввести цифру от 0 до 9"); }
finally { Console.WriteLine("Конец отлова, в итоге st1 имеет данные такие: ");st1.WriteInfo(); }
try 
{
    for (int i = 0; i < 2; i++)
    {
        str = Console.ReadLine();
        st2.Age = int.Parse(str)-1;
        st2.BecomeOlder();
        st2.WriteInfo();
        if (st2.Age == 0) { throw new Exception("Сообщние при ошибке"); }
    }
}
catch(Exception e)when (str == "0"){ Console.WriteLine("str не должно быть равно 0. "+e.Message); }
catch(Exception ex) {  Console.WriteLine("Нужно ввести цифру от 0 до 9"); }
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
