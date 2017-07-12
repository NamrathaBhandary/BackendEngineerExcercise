using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.CSV
{
    public interface ICSVWriter
    {
        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        void OpenFile(string fileName);

        /// <summary>
        /// Writes the specified columns.
        /// </summary>
        /// <param name="columns">The columns.</param>
        void Write(params string[] columns);
    }
}
