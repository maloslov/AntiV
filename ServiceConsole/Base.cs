using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConsole
{
    class Record
    {
        public string name { get; set; }
        public string ext { get; set; }
        public ulong sign { get; set; }
        public ulong hash { get; set; }
        public ulong signLength { get; set; }
        public ulong offsetStart { get; set; }
        public ulong offsetEnd { get; set; }
    }

    class Base
    {
        public ulong minOffStart;
        public ulong maxOffEnd;
        public ulong maxLength;
        private Dictionary<ulong, Record> mybase;
        private string path;

        public Base(string basePath)
        {
            path = basePath;
            mybase = new Dictionary<ulong, Record>();
            minOffStart = 0;
            maxOffEnd = 0;
            maxLength = 8;
        }
        public bool isFound(ulong hashKey, ulong offStart, string name)
        {

            return false;
        }
        public void load()
        {
            {
                if (File.Exists(path))
                    using (var f = new StreamReader(path, Encoding.ASCII))
                    {
                        byte[] buf = new byte[9];
                        for (int j = 0; j < buf.Length; j++)
                        {
                            buf[j] = (byte)f.Read();
                        }
                        if (!(buf[0] == 'b' && buf[1] == 'a' && buf[2] == 's'
                            && buf[3] == 'o' && buf[4] == 'v'))
                            return;
                        int rows = BitConverter.ToInt32(buf, 5);
                        for (int i = 0; i < rows; i++)
                        {
                            Record r = new Record();
                            //read name
                            int len = f.Read();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.Read();
                            }
                            r.name = Encoding.ASCII.GetString(buf);

                            //read file type
                            len = f.Read();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.Read();
                            }
                            r.ext = Encoding.ASCII.GetString(buf);

                            //read prefix
                            len = f.Read();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.Read();
                            }
                            r.sign = BitConverter.ToUInt64(buf, 0);

                            //read hash
                            len = f.Read();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.Read();
                            }
                            r.hash = (BitConverter.ToUInt64(buf, 0));

                            //read length
                            len = f.Read();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.Read();
                            }
                            r.signLength = (BitConverter.ToUInt64(buf, 0));
                            maxLength = r.signLength > maxLength ? r.signLength : maxLength;

                            //read offset start
                            len = f.Read();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.Read();
                            }
                            r.offsetStart = BitConverter.ToUInt64(buf, 0);
                            minOffStart = minOffStart > r.offsetStart ? r.offsetStart : minOffStart;

                            //read offset end
                            len = f.Read();
                            buf = new byte[len];
                            for (int j = 0; j < len; j++)
                            {
                                buf[j] = (byte)f.Read();
                            }
                            r.offsetEnd = BitConverter.ToUInt64(buf, 0);
                            maxOffEnd = maxOffEnd < r.offsetEnd ? r.offsetEnd : maxOffEnd;

                            mybase.Add(r.hash, r);
                        }
                    }
            }
        }


    }
}
