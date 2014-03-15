// <copyright file="ChannelModel.cs" company="Servant Software">
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
    /// Model class representing an Rss Channel
    /// </summary>
    public class ChannelModel
    {
        /// <summary>
        /// The title
        /// </summary>
        private string title;

        /// <summary>
        /// The link
        /// </summary>
        private string link;

        /// <summary>
        /// The language
        /// </summary>
        private string language;

        /// <summary>
        /// The copyright
        /// </summary>
        private string copyright;

        /// <summary>
        /// The channel items
        /// </summary>
        private List<ChannelItemModel> channelItems = new List<ChannelItemModel>();


        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelModel"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="link">The link.</param>
        /// <param name="language">The language.</param>
        /// <param name="copyright">The copyright.</param>
        public ChannelModel(string title, string link, string language, string copyright)
        {
            this.title = title;
            this.link = link;
            this.language = language;
            this.copyright = copyright;
        }

        /// <summary>
        /// Gets the channel items.
        /// </summary>
        /// <value>
        /// The channel items.
        /// </value>
        public List<ChannelItemModel> ChannelItems
        {
            get
            {
                return this.channelItems;
            }
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
        /// Gets the link.
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

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language
        {
            get
            {
                return this.language;
            }
        }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        /// <value>
        /// The copyright.
        /// </value>
        public string Copyright
        {
            get
            {
                return this.copyright;
            }
        }

        /// <summary>
        /// Adds an item to channel.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddItemToChannel(ChannelItemModel item)
        {
            channelItems.Add(item);
        }
    }
}
