using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AVBaseEditor
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<Phone> Phones { get; set; }
    }
    public class BaseRecord
    {
        public string VirusName { get; set; }
        public string FileType { get; set; }
        public UInt32 Signature { get; set; }
        public UInt32 Length { get; set; }
        public UInt32 Hash { get; set; }
        public UInt32 OffsetStart { get; set; }
        public UInt32 OffsetEnd { get; set; }
        public BaseRecord(string VirusName, string FileType, 
            UInt32 Signature, UInt32 Length, UInt32 Hash, 
            UInt32 OffsetStart, UInt32 OffsetEnd)
        {
            this.VirusName = VirusName;
            this.FileType = FileType;
            this.Signature = Signature;
            this.Length = Length;
            this.Hash = Hash;
            this.OffsetStart = OffsetStart;
            this.OffsetEnd = OffsetEnd;
        }
    }
    public class Phone
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public Phone(string Title, string Company, int Price)
        {
            this.Title = Title;
            this.Company = Company;
            this.Price = Price;
        }
        public override string ToString()
        {
            return Title + ", " + Company + ", " + Price.ToString();
        }
    }
}
