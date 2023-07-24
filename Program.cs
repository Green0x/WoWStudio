using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows;



namespace BirdmanStudio
{
    class Program
    {

        static unsafe void Main(string[] args)
        {

            Console.BufferHeight = 2000;

            Console.WriteLine("--------------------------------");
            Console.WriteLine("World of Warcraft Studio");
            Console.WriteLine("--------------------------------\n");


            string logFilePath = "log.txt";
            var logFile = File.Create(logFilePath);
            logFile.Close();
            


            string fileName = null;
            
            try
            {
                fileName = args[0];
                
                

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No file was found");

            }
            
           

            System.Net.WebClient wc = new System.Net.WebClient();
            
            

            if (File.Exists(fileName))
            {

                
                

                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    
                    var isAdt = Helper.SeekChunk(reader, "MDDF");
                    
#region ADT
                    
                    if (isAdt == true)
                    {
                        try
                        {
                            ADT.MDDF ADTmddf = new ADT.MDDF();
                            //int no = 0; 
                            
                            ADTmddf.MagicSize = reader.ReadUInt32();
                            uint doodadDefSize = ADTmddf.MagicSize / 36;
                            Console.WriteLine(ADTmddf.MagicSize);
                            
                            for (uint i = 0; i < doodadDefSize; i++)
                            {
                                ADTmddf.FileDataID = reader.ReadUInt32();
                                //reader.ReadInt32();
                                ADTmddf.Uniqueid = reader.ReadUInt32();
                                ADTmddf.posx = reader.ReadUInt32();
                                ADTmddf.posy = reader.ReadUInt32();
                                ADTmddf.posz = reader.ReadUInt32();
                                ADTmddf.rotx = reader.ReadUInt32();
                                ADTmddf.roty = reader.ReadUInt32();
                                ADTmddf.rotz = reader.ReadUInt32();
                                ADTmddf.scale = reader.ReadUInt16();
                                ADTmddf.flags = reader.ReadUInt16();
                                //string webdata = wc.DownloadString("https://bnet.marlam.in/scripts/filedata_api.php?filename=1&filedataid=" + TXIDtextures);
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFilePath, true))
                                {
                                    file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " FileDataID = " + ADTmddf.FileDataID);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.Uniqueid);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.posx);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.posy);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.posz);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.rotx);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.roty);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.rotz);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.scale);
                                   // file.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.flags);
                                    file.WriteLine(" ");

                                }

                                //Console.WriteLine(webdata);
                                
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " FileDataID =" + " " + ADTmddf.FileDataID);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.Uniqueid);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.posx);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.posy);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.posz);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.rotx);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.roty);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.rotz);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.scale);
                                Console.WriteLine("DoodadDefs[" + i.ToString() + "]" + " " + ADTmddf.flags);
                                Console.WriteLine(" ");
                                //reader.ReadUInt32();
                                //reader.BaseStream.Seek(5, SeekOrigin.Current);
                                
                            }

                        }
                        catch (EndOfStreamException)
                        {
                            Console.WriteLine("End of TXID chunk");
                            

                        }
                        
                    }
                    else
                    {
                        //Console.WriteLine("There is no TXID");
                    }
                    
#endregion


                }



                



            }


            
            Console.ReadKey();
            
            


        }
       
#region Helpful things

#endregion
    }
    
}
