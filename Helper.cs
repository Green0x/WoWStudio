using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BirdmanStudio
{
    class Helper
    {
        public static bool SeekChunkM2(BinaryReader reader, string magic, bool begin = true)
        {
            if (begin)
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

            uint signatureInt = MagicToSignatureM2(magic);

            try
            {
                var sig = reader.ReadUInt32();
                while (sig != signatureInt)
                {
                    try
                    {
                        var size = reader.ReadInt32();
                        reader.BaseStream.Position += size;
                        sig = reader.ReadUInt32();
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("TXID chunk does not exist");
                        break;
                    }
                    
                }

                return sig == signatureInt;
            }
            catch (EndOfStreamException)
            {
                return false;
            }
        }

        public static bool SeekChunk(BinaryReader reader, string magic, bool begin = true)
        {
            if (begin)
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

            uint signatureInt = MagicToSignature(magic);

            try
            {
                var sig = reader.ReadUInt32();
                while (sig != signatureInt)
                {
                    var size = reader.ReadInt32();
                    reader.BaseStream.Position += size;
                    sig = reader.ReadUInt32();
                }

                return sig == signatureInt;
            }
            catch (EndOfStreamException)
            {
                return false;
            }
        }

        public static UInt32 MagicToSignatureM2(string magic)
        {
            //magic = Reverse(magic);
            return BitConverter.ToUInt32(Encoding.ASCII.GetBytes(magic), 0);
        }

        public static UInt32 MagicToSignature(string magic)
        {
            magic = Reverse(magic);
            return BitConverter.ToUInt32(Encoding.ASCII.GetBytes(magic), 0);
        }

        public static string Reverse(string text)
        {
            if (text == null)
                return null;

            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
    }
}
