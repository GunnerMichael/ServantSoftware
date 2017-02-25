// <copyright file="TextFileLogger.cs" company="Servant Software">
// Copyright (c) Servant Software. All rights reserved
// </copyright>

// The MIT License (MIT) Copyright (c) 2012 - 2017
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace ServantSoftware.Toolkit
{
    using System;
    using System.IO;

    /// <summary>
    /// Implementation of <see cref="ILogger"/> that writes to a text file
    /// </summary>
    public class TextFileLogger : ILogger
    {
        /// <summary>
        /// The path of the text file to log to
        /// </summary>
        private string path;

        /// <summary>
        /// Flag indicating if the message written to the log should have a timestamp prefix
        /// </summary>
        private bool timestamp;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileLogger"/> class.
        /// </summary>
        /// <param name="folder">The folder to write the log to</param>
        /// <param name="filename">The filename of the log</param>
        /// <param name="datestamp">if set to <c>true</c> then the file will be given a date prefix</param>
        /// <param name="timestamp">if set to <c>true</c> then each line will be given a timestamp</param>
        public TextFileLogger(string folder, string filename, bool datestamp, bool timestamp)
        {
            this.path = datestamp == true ? String.Format("{0}\\{1}-{2}", folder, DateTime.Now.ToString("yyyyMMdd"), filename) :
                String.Format("{0}\\{1}", folder, filename);

            this.timestamp = timestamp;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileLogger"/> class.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <param name="filename">The filename.</param>
        public TextFileLogger(string folder, string filename)
        {
            this.path = String.Format("{0}\\{1}-{2}", folder, DateTime.Now.ToString("yyyyMMdd"), filename);
            this.timestamp = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileLogger"/> class.
        /// </summary>
        /// <param name="folder">The folder to write the log to</param>
        /// <param name="filename">The filename of the log</param>
        /// <param name="datestamp">if set to <c>true</c> then the file will be given a date prefix</param>
        public TextFileLogger(string folder, string filename, bool datestamp)
        {
            this.path = datestamp == true ? String.Format("{0}\\{1}-{2}", folder, DateTime.Now.ToString("yyyyMMdd"), filename) :
                String.Format("{0}\\{1}", folder, filename);

            this.timestamp = false;
        }

        /// <summary>
        /// Writes the specified format to the log
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arguments">The arguments.</param>
        public void Write(string format, params object[] arguments)
        {
            this.Write(String.Format(format, arguments));
        }

        /// <summary>
        /// Writes an exception stack trace to the log along with a custom message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The exception.</param>
        public void Write(string message, Exception ex)
        {
            this.Write("{0} {1}", message, ex.ToString());
        }

        /// <summary>
        /// Writes an exception stack trace to the log
        /// </summary>
        /// <param name="ex">The exception</param>
        public void Write(Exception ex)
        {
            this.Write(ex.ToString());
        }

        /// <summary>
        /// Writes to the streamwriter
        /// </summary>
        /// <param name="message">The message.</param>
        private void Write(string message)
        {
            using (var writer = File.AppendText(path))
            {
                if (this.timestamp == true)
                {
                    writer.WriteLine(String.Format("{0} -> {1}", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"), message));
                }
                else
                {
                    writer.WriteLine(message);
                }
            }
        }
    }
}
