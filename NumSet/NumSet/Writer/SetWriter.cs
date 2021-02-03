using System;
using System.IO;

namespace NumSet.Writer
{
    public sealed class SetWriter: IDisposable
    {
        
        private bool _disposedValue = false;
        
        private StreamWriter? _writer;

        public StreamWriter Writer{
            get => _writer!;
            private set => _writer = value?? throw new ArgumentNullException();
        }

        public SetWriter(string filePath)
        {
             if(filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            _writer = new StreamWriter(filePath);
        }

        public void WriteSet(NumSet numSet)
        {
            if(numSet is null)
            {
                throw new ArgumentNullException(nameof(numSet));
            }

            this.Writer.WriteLine(numSet.ToString());
        }
   

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing) {
                    Writer.Close();
                    Writer.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
