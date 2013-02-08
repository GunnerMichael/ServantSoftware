// <copyright file="ILogger.cs" company="Servant Software">
// Copyright (c) Servant Software. All rights reserved
// </copyright>

/*
License

The MIT License (MIT) Copyright (c) 2012 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */


namespace ServantSoftware.Toolkit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ILogger
    {
        /// <summary>
        /// Writes the specified message to the log
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(string message);

        /// <summary>
        /// Writes the specified format to the log
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arguments">The arguments.</param>
        void Write(string format, params object[] arguments);

        /// <summary>
        /// Writes an exception stack trace to the log along with a custom message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        void Write(string message, Exception ex);

        /// <summary>
        /// Writes an exception stack trace to the log 
        /// </summary>
        /// <param name="ex">The ex.</param>
        void Write(Exception ex);
    }
}
