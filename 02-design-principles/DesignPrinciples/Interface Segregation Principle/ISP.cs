/*
#region  Before Applying ISP
public interface IMultiFunctionPrinter
{
    void Print();
    void Scan();
    void Fax();

}

public class BasicPrinter : IMultiFunctionPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing....");
    }

 public void Scan()
    {
        throw new NotImplementedException();
    }

    public void Fax()
    {
        throw new NotImplementedException();
    }
}       
#endregion
 */

#region  After Applying ISP
public interface IPrinter
{
    void Print();
}
public interface IScanner
{
    void Scan();
}
public interface IFax
{
    void Fax();
}


public class BasicPrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing....");
    }
 
}
public class AdvancedPrinter : IPrinter ,IScanner
{
    public void Print()
    {
        Console.WriteLine("Printing....");
    }
    public void Scan()
    {
        Console.WriteLine("Scanning....");
    }
 
}
#endregion