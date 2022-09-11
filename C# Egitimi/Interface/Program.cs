//=>Interface;
/*-Siniflarin icermesi gereken metotlarin imzalarinin yer aldigi, ozelliklerin tanimlandigi bir taslak
gibi dusunulebilir.
-Interface icerisindeki propertylere deger atamasi(veya ilk deger atamasi) yapilmaz ve metotlarin govdesi de yazilmaz.
-Sadece implemente edilen sinifin ne is yaptigini belirten bir arayuzdur.
-Intefaceler kendilerinden kalitim alan siniflarin cercevesinin,sorumlugunun cizilmesinde yardimci olur.
**Ayni sorumlulugu baska bir sekilde yapmasi gereken classlar icin bu olanagi saglar. Ondan tureyen
n tane sinifin ne is yaptigi kolayca anlasilabilir.
(own)-Polymorphism'i destekledigi buradan da anlasilabilir.
*/

FileLogger fileLogger = new FileLogger();
fileLogger.WriteLog();

DatabaseLogger dbLogger = new DatabaseLogger();
dbLogger.WriteLog();

SmsLogger smsLogger = new(); //bunu da kabul eder instance olusturuken, new SmsLogger() olarak algilar.
smsLogger.WriteLog();

//Kalitim alan classlardan hangisinin gonderildigini algilayip bu dogrultuda kontrolu saglamak icin.
//LogManager ne gonderildigini bilmeden, bundan soyut olarak gonderilen referansa ait olan WriteLog()
//metodunu calistirir.
//Ustteki ayri ayri tanimladigin fileLogger,dbLogger,smsLogger yerine direkt burada constructora 
//ILogger'dan miras alan classlardan birisinin instance'ini verdiginde (ILogger'in referansi) ona ait
//olan WriteLog() metodu calistirilabilecek;
LogManager logManager = new LogManager(new FileLogger());
logManager.WriteLog();