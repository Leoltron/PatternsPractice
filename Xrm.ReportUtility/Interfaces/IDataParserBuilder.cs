namespace Xrm.ReportUtility.Interfaces
{
    /*
     * Реализация фабричного метода, позволяет связывать парсер данных и подходящее имя файла
     * без нагромождения всего в один метод, однако требует два класса на каждый новый парсер.
     */ 
    public interface IDataParserBuilder
    {
        bool Matches(string filename);
        IDataParser Build();
    }
}
