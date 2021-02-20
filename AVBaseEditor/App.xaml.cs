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
    }
    public class BaseRecord
    {
        public string VirusName { get; set; }
        public string FileType { get; set; }
        public byte Signature { get; set; }
        public UInt32 Length { get; set; }
        public UInt32 Hash { get; set; }
        public UInt32 OffsetStart { get; set; }
        public UInt32 OffsetEnd { get; set; }
        public BaseRecord(string VirusName, string FileType,
            byte Signature, UInt32 Length, UInt32 Hash,
            UInt32 OffsetStart, UInt32 OffsetEnd)
        {
            this.VirusName = VirusName;
            this.FileType = FileType;
            this.Signature = Signature;
            this.Length = Length;
            System.Security.Cryptography.SHA256 sha;
            this.Hash = Hash;
            this.OffsetStart = OffsetStart;
            this.OffsetEnd = OffsetEnd;
        }
    }
}
