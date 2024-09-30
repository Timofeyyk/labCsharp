System.Console.OutputEncoding = System.Text.Encoding.UTF8;

Student st1 = new Student("Anton", 10);
Student st2 = new Student("Akasha");
Student st3 = new Student("Jones", 11);
Student st4 = new Student("Zhora");
st4.WriteInfo();
st1.WriteInfo();
st3.WriteInfo();
st2.WriteInfo();
st1.BecomeOlder();
st2.BecomeOlder();
//st2.Age = 2; не работает так как сеттер с модификтаром private
Console.WriteLine(st2.Age);// работает, так как геттер имеет модификатор public
st1.WriteInfo();
st4.BecomeOlder();
st4.WriteInfo();

Game gm1= new Game("Akasha","Dota2",2400);
//Game gm2 = new Game("Bash","Elden Ring"); недоступен, потому что private
Game gm2;
Game GameName = new Game("Kesha", "Skyrim", 10);

GameName.FindFavGame();
GameName.HoursPlayed=1000;// можно, так как сеттер паблик
//Console.WriteLine(GameName.HoursPlayed); Нельзя так как геттер private
GameName.FindFavGame();
GameName.BestGame("KeshaRe","Cilivization");

Subject sub1 = new Subject("Mikasa", "UPM", 'A');
sub1.FindFavSub(); 
//sub1._favSub = "Atack"; нельзя, так как protected
sub1.FindFavSub();
Console.WriteLine(sub1.ClassChar);
Obj o1 = new Obj("Kurumi", "Math", 'B');
o1.FindFavSub();
o1.ChangeSub("Russian");
o1.FindFavSub();


class Obj : Subject
{
    public Obj(string _name, string _favSub, char ClassChar) : base(_name, _favSub, ClassChar)
    {

    }
    public void ChangeSub(String _favSub) 
    {
        this._favSub = _favSub;
    }
    //public void ChangeName(String _name) не будет работать, так как метод private
    //{
    //    this._name = _name;
    //}
}
class Subject 
{
    private String _name { get; set; }
    protected String _favSub { get; set; }
    internal Char ClassChar { get; set; }
    public Subject(String _name,String _favSub,Char ClassChar) 
    { 
        this._name = _name;
        this._favSub = _favSub; 
        this.ClassChar = ClassChar; 
    }
    public void FindFavSub()
    {
        System.Console.WriteLine(this._name+" Любимый предмет: "+this._favSub);
    }
}
class Game
{
    private String _name { get; set; }
    private String _favGame { get; set; }
    public int? HoursPlayed { private get; set; }
    private Game(String _name, String _favGame) { this._name = _name;this._favGame = _favGame; }
    public Game(String _name, String _favGame, int HoursPlayed)
    {
        this._name = _name;
        this._favGame = _favGame;
        this.HoursPlayed = HoursPlayed;
    }
    public void FindFavGame()
    {
        System.Console.WriteLine(this._name+" Любимая игра: "+this._favGame+" Время в игре: "+this.HoursPlayed);
    }
    public void BestGame(String _name, String _favGame) 
    {
        Game GameName=new Game(_name, _favGame);
        GameName.FindFavGame();
    }
     
}
class Student{
    private String _name { get; set; }
    public int? Age { get; private set; }
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
            System.Console.WriteLine("Имя : "+this._name);
        }
        else
        {
            System.Console.WriteLine("Имя : " + this._name+", Возраст : "+this.Age);
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