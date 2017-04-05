﻿using RestSharp;
using SimpleFeedReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;
using System.Xml.Linq;
using Terradue.ServiceModel.Syndication;

namespace RSSReader
{




    public class Reader
    {
        public static string Feeds()
        //finalnie powinien przyjmowac tablice stringow/linkow i z nich sobie pobierac
        {

            var reader = new FeedReader();
            var items = reader.RetrieveFeed("http://www.nytimes.com/services/xml/rss/nyt/International.xml");
            string feeds = "";

            foreach (var i in items)
            {

                var x = (string.Format("{0}\t{1}",
                        i.Date.ToString("g"),
                        i.Title)

                );
                feeds += x + "\n";
            }
            return feeds;
        }
    }

    public class Post
    {
        public string PublishedDate;
        public string Description;
        public string Title;
        public string link { get; set; }

    }

    public class Getter
    {
    public static string xmel()
        {
            var post = new Post();
            string url = "http://news.google.fr/nwshp?hl=fr&tab=wn&output=rss";
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                post.Title =(feed.Title.Text);
               post.link=(feed.Links[0].Uri.ToString());
                foreach (SyndicationItem item in feed.Items)
                {
                    post.Title=(item.Title.Text);
                }
            }

            return 
        }
    }
    public class Cutter
    {
        public static Post Posts(IEnumerable<FeedItem> x)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("c:\\temp.xml");
            var pos = new Post();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string text = node.InnerText; //or loop through its children as well
                string attr = node.Attributes["link"]?.InnerText;
            }
            
            return 
            
            
        }
    }

    
    public class Refresher
    {
        void RefreshConfTimer(int val)
        {
            // Create a timer
            var myTimer = new System.Timers.Timer();
            // Tell the timer what to do when it elapses
            myTimer.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every val seconds
            myTimer.Interval = val;
            // And start it        
            myTimer.Enabled = true;
            // ma pobierać VAL z GUI i wedle wpisanej watosci wywolywac funkcje pobierajaca feed'y
        }

// Implement a call with the right signature for events going off
        private void myEvent(object source, ElapsedEventArgs e)
        {
            
        }
    
    }

    
}
