// <copyright file="MediaFeedWrapper.cs" company="Servant Software">
// Copyright (c) Servant Software. All rights reserved
// </copyright>

/*
License

The MIT License (MIT) Copyright (c) 2012 - 2017

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */


namespace ServantSoftware.Toolkit.Rss
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// Wrapper for processing a RSS feed which contains media items
    /// </summary>
    public class MediaFeedWrapper : FeedWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFeedWrapper"/> class.
        /// </summary>
        /// <param name="feed">The feed.</param>
        public MediaFeedWrapper(XDocument feed) : base(feed)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFeedWrapper"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public MediaFeedWrapper(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFeedWrapper"/> class.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public MediaFeedWrapper(string xml) : base(xml)
        {
        }

        /// <summary>
        /// Gets the channel.
        /// </summary>
        /// <returns></returns>
        public override ChannelModel GetChannel()
        {
            if(this.channel == null)
            {
                return null;
            }

            var channel = new ChannelModel(
                this.channel.Element("title").Value,
                this.channel.Element("link").Value,
                this.channel.Element("language").Value,
                this.channel.Element("copyright").Value);

            foreach (var item in this.channel.Elements("item"))
            {
                ChannelItemModel channelItem = new ChannelItemModel(
                    item.Element("title").Value,
                    item.Element("description").Value,
                    item.Element("guid").Value,
                    item.Element("pubDate").Value,
                    GetMediaEnclosure(item.Element("enclosure")) );;

                channel.AddItemToChannel(channelItem);                  
            }

            return channel;
        }

        /// <summary>
        /// Gets the media enclosure.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">item cannot be null</exception>
        private MediaEnclosureModel GetMediaEnclosure(XElement item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item cannot be null");
            }

            return new MediaEnclosureModel(
                item.Attribute("url").Value,
                item.Attribute("length").Value,
                item.Attribute("type").Value);
        }
    }
}
