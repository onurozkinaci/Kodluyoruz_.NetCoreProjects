public class LogManager:ILogger
{
   public ILogger _logger; //ILogger'in instance'ini aldik.
   public LogManager(ILogger logger) //interface'ler new ile yaratilamadigindan, parametre olarak nesnesini degil de 
   //referansini veriyoruz gibi dusun(DbLogger gibi bu interface'ten kalitim/miras alan bir class'in instance'i verilebilir yani).
   {
      this._logger = logger;
   }

    //Bu classta, constructor uzerinden iletilen nesnenin
    //WriteLog() metodu calistirilacak;
    public void WriteLog()
    {
       this._logger.WriteLog(); //FileLogger.WriteLog() gibi
    }
}