using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var readFile = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                var buffer = new byte[4096];

                using (var writeFile = new FileStream("../../../copyMe-copy.png", FileMode.Create))
                {
                    while (true)
                    {
                        int bytesCount = readFile.Read(buffer, 0, buffer.Length);

                        if (bytesCount == 0)
                        {
                            break;
                        }

                        writeFile.Write(buffer, 0, bytesCount);
                    }

                }
            }
        }
    }
}
