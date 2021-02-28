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
            this.Signature = new UInt32();
            var b = BitConverter.GetBytes(Signature);
            if(b.Length > 8)
            {
                this.Signature = BitConverter.ToUInt32(b.Take(8).ToArray(), 0);
            }
            else
            {
                this.Signature = BitConverter.ToUInt32(b,0);
            }
            this.Length = Length;
            //System.Security.Cryptography.SHA256 sha;
            this.Hash = Hash;
            this.OffsetStart = OffsetStart;
            this.OffsetEnd = OffsetEnd;
        }

        public byte[] ToBytes()
        {
            byte[] name = MainWindow.stob(VirusName),
                type = MainWindow.stob(FileType),
                sign = BitConverter.GetBytes(Signature),
                lenbytes = BitConverter.GetBytes(Length),
                hashbytes = BitConverter.GetBytes(Hash),
                startbytes = BitConverter.GetBytes(OffsetStart),
                endbytes = BitConverter.GetBytes(OffsetEnd);

 //           while (sign.Length < 8)
   //             sign = sign.Prepend((byte)0).ToArray();

            var res = new byte[0];
            res = res.Append((byte)name.Length).Concat(name).Append(
                (byte)type.Length).Concat(type).Append(
                (byte)sign.Length).Concat(sign).Append(
                (byte)lenbytes.Length).Concat(lenbytes).Append(
                (byte)hashbytes.Length).Concat(hashbytes).Append(
                (byte)startbytes.Length).Concat(startbytes).Append(
                (byte)endbytes.Length).Concat(endbytes).ToArray();
            return res;
        }
    }
}
