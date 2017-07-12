using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.CSV
{
    public interface ICSVReader
    {
        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        void OpenFile(string fileName);

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>true or false</returns>
        bool Read();

        /// <summary>
        /// Reads the specified column1.
        /// </summary>
        /// <param name="column1">The column1.</param>
        /// <param name="column2">The column2.</param>
        /// <returns>true or false</returns>
        bool Read(out string column1, out string column2);
    }
}
