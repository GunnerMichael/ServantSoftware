// <copyright file="FeedWrapper.cs" company="Servant Software">
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
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class FeedWrapper
    {
        /// <summary>
        /// The feed
        /// </summary>
        protected XDocument feed;

        /// <summary>
        /// The namespaces
        /// </summary>
        protected Dictionary<string, XNamespace> namespaces;

        /// <summary>
        /// The channel
        /// </summary>
        protected XElement channel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFeedWrapper"/> class.
        /// </summary>
        /// <param name="feed">The feed.</param>
        public FeedWrapper(XDocument feed)
        {
            this.feed = feed;
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFeedWrapper"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public FeedWrapper(Stream stream)
        {
            feed = XDocument.Load(stream);
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFeedWrapper"/> class.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public FeedWrapper(string xml)
        {
            feed = XDocument.Parse(xml);
            Init();
        }

        /// <summary>
        /// Inits this instance.
        /// </summary>
        private void Init()
        {
            GetNamespaces();

            this.channel = feed.Element("rss").Element("channel");
        }

        /// <summary>
        /// Gets the namespaces.
        /// </summary>
        private void GetNamespaces()
        {
            // code from http://www.hanselman.com/blog/GetNamespacesFromAnXMLDocumentWithXPathDocumentAndLINQToXML.aspx
           namespaces = feed.Root.Attributes().
                    Where(a => a.IsNamespaceDeclaration).
                    GroupBy(a => a.Name.Namespace == XNamespace.None ? String.Empty : a.Name.LocalName,
                            a => XNamespace.Get(a.Value)).
                    ToDictionary(g => g.Key,
                                 g => g.First());
        }


        /// <summary>
        /// Gets the channel.
        /// </summary>
        /// <returns></returns>
        public virtual ChannelModel GetChannel()
        {
            if(this.channel == null)
            {
                return null;
            }

            var channel = new ChannelModel(
                this.channel.Element("title") == null ? String.Empty : this.channel.Element("title").Value,
                this.channel.Element("link") == null ? String.Empty : this.channel.Element("link").Value,
                this.channel.Element("language") == null ? String.Empty : this.channel.Element("language").Value,
                this.channel.Element("copyright") == null ? String.Empty : this.channel.Element("copyright").Value); 

            foreach (var item in this.channel.Elements("item"))
            {
                ChannelItemModel channelItem = new ChannelItemModel(
                    item.Element("title").Value,
                    item.Element("description").Value,
                    item.Element("guid").Value,
                    item.Element("pubDate").Value,
                    item.Element("link").Value);;

                channel.AddItemToChannel(channelItem);                  
            }

            return channel;
        }

    }
}
