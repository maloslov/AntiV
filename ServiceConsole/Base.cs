using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConsole
{
    class Record
    {
        public string name { get; set; }
        public string ext { get; set; }
        public byte[] sign { get; set; }
        public ulong hash { get; set; }
        public ulong signLength { get; set; }
        public ulong offsetStart { get; set; }
        public ulong offsetEnd { get; set; }
    }

    class Base
    {
        public static long minOffStart;
        public static long maxOffEnd;
        public static long maxLength;
        private static Dictionary<ulong, Record> mybase;
        private static string path;

        public Base(string basePath)
        {
            path = basePath;
            mybase = new Dictionary<ulong, Record>();
            minOffStart = long.MaxValue;
            maxOffEnd = 0;
            maxLength = 8;
            
        }
        public static List<string> isFound(byte[] maxSign, ulong offStart)
        {
            var sha = SHA256.Create();
            var res = new List<string>();
            for (int i = 8; i <= maxSign.Length; i++)
            {
                var sign = new byte[i];
                for (int j = 0; j < i; j++)
                    sign[j] = maxSign[j];
                var key = BitConverter.ToUInt64(sha.ComputeHash(sign), 0);
                if(mybase.ContainsKey(key))
                {
                    res.Add(mybase[key].name);
                }
                /*
                ulong k;
                if (i >= 26 && offStart >= 823)
                {
                    var b = sha.ComputeHash(sign);
                    k = BitConverter.ToUInt64(b, 0);
                    if (k == 10495849145646780990)
                        k = 0;
                }*/
            }
            return res;
        }
        public static void load()
        {
            {
                if (File.Exists(path))
                    using (var f = File.Open(path, FileMode.Open,FileAccess.Read))
                    {
                        byte[] buf = new byte[9];
                        for (int j = 0; j < buf.Length; j++)
                        {
                            buf[j] = (byte)f.ReadByte();
                        }
                        if (!(buf[0] == 'b' && buf[1] == 'a' && buf[2] == 's'
                            && buf[3] == 'o' && buf[4] == 'v'))
                            return;
                        int rows = BitConverter.ToInt32(buf, 5);
                        for (int i = 0; i < rows; i++)
                        {
                            Record r = new Record();
                            //read name
                            int len = f.ReadByte();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.ReadByte();
                            }
                            r.name = Encoding.ASCII.GetString(buf);

                            //read file type
                            len = f.ReadByte();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.ReadByte();
                            }
                            r.ext = Encoding.ASCII.GetString(buf);

                            //read prefix
                            len = f.ReadByte();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.ReadByte();
                            }
                            r.sign = (buf);

                            //read hash
                            len = f.ReadByte();
                            buf = new byte[len];
                            
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.ReadByte();
                            }
                            r.hash = (BitConverter.ToUInt64(buf, 0));

                            //read length
                            len = f.ReadByte();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.ReadByte();
                            }
                            r.signLength = (BitConverter.ToUInt64(buf, 0));
                            maxLength = (long)r.signLength > maxLength ? (long)r.signLength : maxLength;

                            //read offset start
                            len = f.ReadByte();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.ReadByte();
                            }
                            r.offsetStart = BitConverter.ToUInt64(buf, 0);
                            minOffStart = minOffStart > (long)r.offsetStart ? (long)r.offsetStart : minOffStart;

                            //read offset end
                            len = f.ReadByte();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.ReadByte();
                            }
                            r.offsetEnd = BitConverter.ToUInt64(buf, 0);
                            maxOffEnd = maxOffEnd < (long)r.offsetEnd ? (long)r.offsetEnd : maxOffEnd;

                            mybase.Add(r.hash, r);
                        }
                        Console.WriteLine("base loaded...");
                    }
            }
        }


    }
}
