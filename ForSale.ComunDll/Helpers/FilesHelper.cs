using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ForSale.ComunDll.Helpers
{
    public class FilesHelper : IFilesHelper
    {
        public byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }


}
