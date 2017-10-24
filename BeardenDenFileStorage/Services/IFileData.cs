using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public interface IFileData
    {
        IEnumerable<File> GetAll();
    }
}
