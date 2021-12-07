A aClass = new();

aClass.M();

B bClas = new();

bClas.M();

Console.ReadLine();





interface I1
{
    void M();
}

interface I2
{
    void M();
}

class A :I1,I2
{
    public void M() { Console.WriteLine("A.M()"); }
}

class B : A, I1,I2
{

}