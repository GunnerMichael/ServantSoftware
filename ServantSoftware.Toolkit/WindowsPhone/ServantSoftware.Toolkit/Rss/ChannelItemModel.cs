// <copyright file="ChannelItemModel.cs" company="Servant Software">
// Copyright (c) Servant Software. All rights reserved
// </copyright>

/*
License

The MIT License (MIT) Copyright (c) 2012 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */


namespace ServantSoftware.Toolkit.Rss
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Model representing an Rss Channel Item
    /// </summary>
    public class ChannelItemModel
    {
        /// <summary>
        /// The title
        /// </summary>
        private string title;
        /// <summary>
        /// The description
        /// </summary>
        private string description;

        /// <summary>
        /// The GUID
        /// </summary>
        private string guid;
        /// <summary>
        /// The pub date
        /// </summary>
        private string pubDate;

        /// <summary>
        /// The media enclosure
        /// </summary>
        private MediaEnclosureModel mediaEnclosure;

        /// <summary>
        /// The link to the main text
        /// </summary>
        private string link;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelItemModel"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="guid">The GUID.</param>
        /// <param name="pubDate">The pub date.</param>
        /// <param name="mediaEnclosure">The media enclosure.</param>
        public ChannelItemModel(string title, string description, string guid, string pubDate, MediaEnclosureModel mediaEnclosure)
        {
            this.title = title;
            this.description = description;
            this.guid = guid;
            this.pubDate = pubDate;
            this.mediaEnclosure = mediaEnclosure;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelItemModel"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="guid">The GUID.</param>
        /// <param name="pubDate">The pub date.</param>
        /// <param name="mediaEnclosure">The media enclosure.</param>
        public ChannelItemModel(string title, string description, string guid, string pubDate, string link)
        {
            this.title = title;
            this.description = description;
            this.guid = guid;
            this.pubDate = pubDate;
            this.link = link;
        }


        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return this.title;
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Gets the GUID.
        /// </summary>
        /// <value>
        /// The GUID.
        /// </value>
        public string Guid
        {
            get
            {
                return this.guid;
            }
        }

        /// <summary>
        /// Gets the pub date.
        /// </summary>
        /// <value>
        /// The pub date.
        /// </value>
        public string PubDate
        {
            get
            {
                return this.pubDate;
            }
        }

        /// <summary>
        /// Gets the media enclosure.
        /// </summary>
        /// <value>
        /// The media enclosure.
        /// </value>
        public MediaEnclosureModel MediaEnclosure
        {
            get
            {
                return this.mediaEnclosure;
            }
        }

        /// <summary>
        /// Gets the link to the main text
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string Link
        {
            get
            {
                return this.link;
            }
        }

    }
}
