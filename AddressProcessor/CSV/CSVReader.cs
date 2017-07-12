using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.CSV
{

    /// <summary>
    /// Class to perform all the read tasks for CSV file
    /// </summary>
    /// <seealso cref="AddressProcessing.CSV.ICSVReader" />
    /// <seealso cref="System.IDisposable" />
    public class CSVReader : ICSVReader, IDisposable
    {
        /// <summary>
        /// Instacne of StreamReader.
        /// </summary>
        private StreamReader _readerStream;

        /// <summary>
        /// The disposed value
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void OpenFile(string fileName)
        {
            try
            {
               this._readerStream = File.OpenText(fileName);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Reads the specified column1.
        /// </summary>
        /// <param name="column1">The column1.</param>
        /// <param name="column2">The column2.</param>
        /// <returns>true or false</returns>
        public bool Read()
        {
            string[] columns = GetColumns();
            return columns == null || columns.Length == 0 ? false : true;
        }

        /// <summary>
        /// Reads the specified column1.
        /// </summary>
        /// <param name="column1">The column1.</param>
        /// <param name="column2">The column2.</param>
        /// <returns>true or false</returns>
        public bool Read(out string column1, out string column2)
        {
            const int FIRST_COLUMN = 0;
            const int SECOND_COLUMN = 1;

            string[] columns = GetColumns();

            if (columns == null || columns.Length == 0)
            {
                column1 = null;
                column2 = null;

                return false;
            }
            else
            {
                column1 = columns[FIRST_COLUMN];
                column2 = columns[SECOND_COLUMN];

                return true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the columns.
        /// Created this method to remove dupication of code as both the Read methods were impelementing same logic.
        /// </summary>
        /// <returns>columns array</returns>
        private string[] GetColumns()
        {
            try
            {
                string line = this._readerStream.ReadLine();
                string[] columns = line != null ? line.Split('\t') : null;
                return columns;
            }
            catch(OutOfMemoryException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_readerStream != null)
                    {
                        _readerStream.Dispose();
                        _readerStream = null;
                    }
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CSVReader"/> class.
        /// </summary>
        ~CSVReader()
        {
           Dispose(false);
        }

    }
}
