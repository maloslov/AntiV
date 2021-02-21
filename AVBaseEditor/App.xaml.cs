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
            //System.Security.Cryptography.SHA256 sha;
            this.Hash = Hash;
            this.OffsetStart = OffsetStart;
            this.OffsetEnd = OffsetEnd;
        }

        public BaseRecord(byte[] record)
        {
            byte state = 0;
            var val = new byte[0];
            foreach (byte b in record)
            {
                if (b != 9) //tab
                {
                    val = val.Append(b).ToArray();
                    continue;
                }
                state++;

                if (val.Length > 0)
                    switch (state)
                    {
                        case 1:
                            VirusName = MainWindow.btos(val);
                            break;
                        case 2:
                            FileType = MainWindow.btos(val);
                            break;
                        case 3:
                            Signature = val[0];
                            break;
                        case 4:
                            Length = BitConverter.ToUInt32(val, 0);
                            break;
                        case 5:
                            Hash = BitConverter.ToUInt32(val, 0);
                            break;
                        case 6:
                            OffsetStart = BitConverter.ToUInt32(val, 0);
                            break;
                        case 7:
                            OffsetEnd = BitConverter.ToUInt32(val, 0);
                            break;
                    }
                val = new byte[0];
            }
        }

        public byte[] ToBytes()
        {
            byte[] lenbytes = BitConverter.GetBytes(Length).ToArray(),
                hashbytes = BitConverter.GetBytes(Hash).ToArray(),
                startbytes = BitConverter.GetBytes(OffsetStart).ToArray(),
                endbytes = BitConverter.GetBytes(OffsetEnd).ToArray();

            byte[] res = MainWindow.stob(VirusName+'\t').Concat(
                MainWindow.stob(FileType+'\t')).Append(Signature).Append(
                (byte)9).Concat(lenbytes).Append((byte)9).Concat(hashbytes).Append(
                (byte)9).Concat(startbytes).Append((byte)9).Concat(endbytes).Append(
                (byte)9).ToArray();
            return res;
        }
    }
}
