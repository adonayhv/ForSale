using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ForSale.ComunDll.Helpers
{
    public interface IFilesHelper
    {
        byte[] ReadFully(Stream input);
    }


}
