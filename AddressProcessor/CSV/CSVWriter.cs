using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.CSV
{

    /// <summary>
    /// Class to perform all the write tasks for CSV file
    /// </summary>
    /// <seealso cref="AddressProcessing.CSV.ICSVWriter" />
    /// <seealso cref="System.IDisposable" />
    public class CSVWriter : ICSVWriter, IDisposable
    {
        /// <summary>
        /// Instance of StreamWriter.
        /// </summary>
        private StreamWriter _writerStream;

        /// <summary>
        /// The disposed value
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Opens the file
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void OpenFile(string fileName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                this._writerStream = fileInfo.CreateText();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Writes the specified columns.
        /// </summary>
        /// <param name="columns">The columns.</param>
        public void Write(params string[] columns)
        {
            if (columns != null)
            {
                string outPut = string.Join("\t", columns);
                this._writerStream.WriteLine(outPut);
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
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this._writerStream != null)
                    {
                        this._writerStream.Dispose();
                        this._writerStream = null;
                    }
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CSVWriter"/> class.
        /// </summary>
        ~CSVWriter()
        {
            Dispose(false);
        }
    }
}
