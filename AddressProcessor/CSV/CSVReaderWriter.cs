using System;
using System.IO;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */

    public class CSVReaderWriter
    {
        /// <summary>
        /// Instance of CSVReader class.
        /// </summary>
        private ICSVReader _reader;

        /// <summary>
        /// Instance of CSVWriter class.
        /// </summary>
        private ICSVWriter _writer;

        /// <summary>
        /// Mode enum
        /// </summary>
        [Flags]
        public enum Mode { Read = 1, Write = 2 };


        /// <summary>
        /// Initializes a new instance of the <see cref="CSVReaderWriter"/> class.
        /// Adding this constructor for backward compatibility.
        /// </summary>
        public CSVReaderWriter()
        {
            this._reader = new CSVReader();
            this._writer = new CSVWriter();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVReaderWriter"/> class.
        /// Using Unity or any other dependency injection container reader and writer will be passed.(DIP from SOLID principles)
        /// class depends only on the abstraction of reader and writer classes.
        /// This makes easier for testing as we can pass mocks of reader and writer.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="writer">The writer.</param>
        public CSVReaderWriter(ICSVReader reader, ICSVWriter writer)
        {
            this._reader = reader;
            this._writer = writer;
        }


        /// <summary>
        /// Opens the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mode">The mode.</param>
        /// <exception cref="System.Exception">Unknown file mode for  + fileName</exception>
        public void Open(string fileName, Mode mode)
        {
            if (mode == Mode.Read)
            {
                this._reader.OpenFile(fileName);
            }
            else if (mode == Mode.Write)
            {
                this._writer.OpenFile(fileName);
            }
            else
            {
                throw new Exception("Unknown file mode for " + fileName);
            }
        }

        /// <summary>
        /// Writes the specified columns.
        /// </summary>
        /// <param name="columns">The columns.</param>
        public void Write(params string[] columns)
        {
            this._writer.Write(columns);
        }

        /// <summary>
        /// Reads the specified column1.
        /// Since this method only returns bool value and wasn't using arguments passed in.
        /// CSVReader read method without arguments is used to return just bool.
        /// Haven't changed the signature of this mehtod for backward compatibility
        /// </summary>
        /// <param name="column1">The column1.</param>
        /// <param name="column2">The column2.</param>
        /// <returns>true or false</returns>
        public bool Read(string column1, string column2)
        {
            return  this._reader.Read();
        }

        /// <summary>
        /// Reads the specified columns and sets the value to column1 and column2 and return a boolean.
        /// </summary>
        /// <param name="column1">The column1.</param>
        /// <param name="column2">The column2.</param>
        /// <returns>true or false</returns>
        public bool Read(out string column1, out string column2)
        {
            return this._reader.Read(out column1, out column2);
        }

        /// <summary>
        /// Closes this instance.
        /// Call the dispose methods of the CSVReader and CSVwriter.
        /// Since the Intefaces don't implement IDiposable have to cast the reader and writer to IDiposable.
        /// </summary>
        public void Close()
        {
            IDisposable readerDisposable = this._reader as IDisposable;
            IDisposable writerDisposable = this._writer as IDisposable;
            if(readerDisposable != null)
            {
                readerDisposable.Dispose();
            }
            if(writerDisposable != null)
            {
                writerDisposable.Dispose();
            }
        }
    }
}
