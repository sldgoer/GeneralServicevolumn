using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralService.Utility.ByteUtility
{
    public class BytesHandler
    {

        public void GetBytesFromString(string src, ref byte[] dest,Char cover,CoverSide side)
        {
            var res = Encoding.ASCII.GetBytes(src);
            int lenDiff = dest.Length - res.Length;
            //Console.WriteLine(lenDiff);

            Console.WriteLine(res.Length);
            Console.WriteLine(dest.Length);

            if (lenDiff <= 0) { Buffer.BlockCopy(res, 0, dest, 0, dest.Length); }
            else
            {
                switch (side)
                {
                    case CoverSide.Left:
                        byte coverByte = Convert.ToByte(cover);
                        for (int i = 0; i < lenDiff; i++)
                        {
                            dest[i] = coverByte;
                        }
                        Buffer.BlockCopy(res, 0, dest, lenDiff, res.Length);
                        break;

                }
            }

        }

        public void GetBytesFromUint(uint src, ref byte[] dest)
        {            
            var res = BitConverter.GetBytes(src);
            dest = res;
        }

        public void GetBytesFromInt(uint src, ref byte[] dest)
        {
            var res = BitConverter.GetBytes(src);
            dest = res;
        }

        public string GetStringFromBytes(byte[] src)
        {
            return Encoding.ASCII.GetString(src);
        }

        public UInt32 GetUintFromBytes(byte[] src)
        {
            return BitConverter.ToUInt32(src,0);
        }

        public int GetIntFromBytes(byte[] src)
        {
            return BitConverter.ToInt32(src,0);
        }

        public void BytesCombine(List<byte[]> src,ref byte[] dest)
        {
            int insertindex = 0;
            foreach(byte[] b in src)
            {
                b.CopyTo(dest, insertindex);
                insertindex += b.Length;
            }

        }

        public enum CoverSide
        {
            Left,
            Right
        }

    }
}
