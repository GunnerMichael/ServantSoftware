using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServantSoftware.Toolkit.Rss;

namespace Tests.ServantSoftwareToolkit
{
    [TestClass]
    public class FeedWrapperFixture
    {
        [TestMethod]
        [DeploymentItem("TestFiles\\rsstest.xml")]
        public void TestCanGetAChannel()
        {
            string text = File.ReadAllText("rsstest.xml");

            FeedWrapper fw = new FeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.IsNotNull(channel);
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\rsstest.xml")]
        public void TestGetsCorrectChannelTitle()
        {
            string text = File.ReadAllText("rsstest.xml");

            FeedWrapper fw = new FeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.AreEqual("Scott Hanselman's Blog", channel.Title);
        }


        [TestMethod]
        [DeploymentItem("TestFiles\\rsstest.xml")]
        public void TestGetsChannelItems()
        {
            string text = File.ReadAllText("rsstest.xml");

            FeedWrapper fw = new FeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.AreNotEqual(0, channel.ChannelItems.Count);
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\rsstest.xml")]
        public void TestGetChannelItemWithCorrectLink()
        {
            string link = "http://feeds.hanselman.com/~/37915217/0/scotthanselman~Simultaneous-Editing-for-Visual-Studio-with-the-free-MultiEdit-extension.aspx";
            string text = File.ReadAllText("rsstest.xml");

            FeedWrapper fw = new FeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.AreEqual(link, channel.ChannelItems[0].Link);
        }
    }


}
