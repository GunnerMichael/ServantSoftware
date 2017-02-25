// <copyright file="IEmailAddressValidator.cs" company="Servant Software">
// Copyright (c) Servant Software. All rights reserved
// </copyright>

// The MIT License (MIT) Copyright (c) 2012 - 2017
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


namespace ServantSoftware.Toolkit
{
    public interface IEmailAddressValidator
    {
        /// <summary>
        /// Determines whether the specified email address is valid.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>
        ///   <c>true</c> if the specified email address is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(string emailAddress);

        /// <summary>
        /// Determines whether the specified email address is valid.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="badAddress">an array of the email addresses that are invalid</param>
        /// <returns>
        ///   <c>true</c> if the specified email address is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(string emailAddress, out string[] badAddress);

        /// <summary>
        /// Returns an array of email addresses that are invalid
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>a string[] of invalid email addresses</returns>
        string[] FindInvalidEmailAddress(string emailAddress);
    }
}
