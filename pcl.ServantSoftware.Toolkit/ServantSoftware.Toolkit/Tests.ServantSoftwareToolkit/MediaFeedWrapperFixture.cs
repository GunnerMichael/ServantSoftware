using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServantSoftware.Toolkit.Rss;

namespace Tests.ServantSoftwareToolkit
{
    [TestClass]
    public class MediaFeedWrapperFixture
    {
        [TestMethod]
        [DeploymentItem("TestFiles\\mediatest.xml")]
        public void TestCanGetAChannel()
        {
            string text = File.ReadAllText("mediatest.xml");

            MediaFeedWrapper fw = new MediaFeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.IsNotNull(channel);
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\mediatest.xml")]
        public void TestGetsCorrectChannelTitle()
        {
            string text = File.ReadAllText("mediatest.xml");

            MediaFeedWrapper fw = new MediaFeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.AreEqual("This Week in Enterprise Tech (HD)", channel.Title);
        }


        [TestMethod]
        [DeploymentItem("TestFiles\\mediatest.xml")]
        public void TestGetsChannelItems()
        {
            string text = File.ReadAllText("mediatest.xml");

            MediaFeedWrapper fw = new MediaFeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.AreNotEqual(0, channel.ChannelItems.Count);
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\mediatest.xml")]
        public void TestGetChannelItemWithMediaEnclosure()
        {
            string text = File.ReadAllText("mediatest.xml");

            MediaFeedWrapper fw = new MediaFeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.IsNotNull(channel.ChannelItems[0].MediaEnclosure);
        }

        [TestMethod]
        [DeploymentItem("TestFiles\\mediatest.xml")]
        public void TestGetChannelItemWithMediaEnclosureHasCorrectUrl()
        {
            string text = File.ReadAllText("mediatest.xml");
            string url = "http://dts.podtrac.com/redirect.mp4/twit.cachefly.net/video/twiet/twiet0028/twiet0028_h264m_1280x720_1872.mp4";

            MediaFeedWrapper fw = new MediaFeedWrapper(text);

            var channel = fw.GetChannel();

            Assert.AreEqual(url, channel.ChannelItems[0].MediaEnclosure.Url);
        }

    }
}
