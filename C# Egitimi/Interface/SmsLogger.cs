public class SmsLogger : ILogger
{
    //kalitim alinan interface'in metotlari implemente edilmeli
    //ve govdesi olusturulmalidir({} ile);
    public void WriteLog()
    {
     //throw new NotImplementedException();
     Console.WriteLine("Sms olarak log yazar!");
    }
}