// <copyright file="DateRange.cs" company="Servant Software">
// Copyright (c) Servant Software. All rights reserved
// </copyright>

// The MIT License (MIT) Copyright (c) 2012 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace ServantSoftware.Toolkit
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class to access and manipulate a date range
    /// </summary>
    public class DateRange
    {
        private DateTime start;
        private DateTime end;

        /// <summary>
        /// Prevents a default instance of the <see cref="DateRange"/> class from being created.
        /// </summary>
        private DateRange()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        public DateRange(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// Sets the end date based on the number of days after the start date
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="days">The number of days til the end of the range</param>
        public DateRange(DateTime start, int days)
        {
            this.start = start;
            this.end = this.start.AddDays(days);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// Sets the start range based on the number of days before the end Date
        /// </summary>
        /// <param name="startDays">The start days.</param>
        /// <param name="endDate">The end date.</param>
        public DateRange(int startDays, DateTime endDate)
        {
            this.end = endDate;
            this.start = endDate.AddDays(startDays);
        }

        /// <summary>
        /// Gets the <see cref="TimeSpan">TimeSpan</see> for the date range
        /// </summary>
        public System.TimeSpan TimeSpan
        {
            get
            {
                return this.End - this.Start;
            }
        }

        /// <summary>
        /// Gets the start date of the range
        /// </summary>
        /// <value>
        /// The start date of the range.
        /// </value>
        public DateTime Start
        {
            get
            {
                return this.start;
            }
        }

        /// <summary>
        /// Gets the end date of the range
        /// </summary>
        /// <value>
        /// The end date of the range
        /// </value>
        public DateTime End
        {
            get
            {
                return this.end;
            }
        }

        /// <summary>
        /// Gets the number of days between start and end.
        /// </summary>
        /// <value>
        /// The number days between start and end.
        /// </value>
        public int DaysBetweenStartAndEnd
        {
            get
            {
                return Convert.ToInt32(this.TimeSpan.TotalDays);
            }
        }

        /// <summary>
        /// Get the number of days between the start date and the specified date
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>the number of days between the start date and the specified date</returns>
        public int DaysBetweenStart(DateTime date)
        {
            if (date > this.start)
            {
                return Convert.ToInt32((date - this.start).TotalDays);
            }
            else
            {
                return Convert.ToInt32((this.start - date).TotalDays);
            }
        }

        /// <summary>
        /// Get the number of days between the end date and the specified date
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>the number of days between the end date and the specified date</returns>
        public int DaysBetweenEnd(DateTime date)
        {
            if (date > this.end)
            {
                return Convert.ToInt32(( date - this.end).TotalDays);
            }
            else
            {
                return Convert.ToInt32((this.end - date).TotalDays);
            }
        }

        /// <summary>
        /// Changes the end date by x number of days
        /// </summary>
        /// <param name="days">The days.</param>
        public void ChangeEndDate(int days)
        {
            this.end = this.end.AddDays(days);
        }

        /// <summary>
        /// Changes the end date by x number of days
        /// </summary>
        /// <param name="days">The days.</param>
        public void ChangeStartDate(int days)
        {
            this.start = this.start.AddDays(days);
        }

        /// <summary>
        /// Parses from YYYMMDD.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public static DateRange ParseFromYYYMMDD(string start, string end)
        {
            var range = new DateRange();

            range.start = DateTime.ParseExact(start, "yyyyMMdd", CultureInfo.CurrentCulture);
            range.end = DateTime.ParseExact(end, "yyyyMMdd", CultureInfo.CurrentCulture);

            return range;
        }
    }
}