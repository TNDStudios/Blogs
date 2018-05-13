﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace TNDStudios.Blogs
{
    public abstract class BlogBase : IBlogBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BlogBase()
        {
            // Set up the location of any additional data that might be captured
            AdditionalData = new Dictionary<string, JToken>();
        }

        /// <summary>
        /// Property bag of additional data as stated by Newtonsoft
        /// </summary>
        [XmlIgnore]
        [JsonExtensionData]
        public Dictionary<string, JToken> AdditionalData { get; set; }
        
        /// <summary>
        /// Cast the item to an Xml String
        /// </summary>
        /// <returns></returns>
        public String ToXmlString()
        {
            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer serialiser = new XmlSerializer(this.GetType());
            String renderedItem = "";
            using (StringWriter writer = new StringWriter())
            {
                serialiser.Serialize(writer, this);
                renderedItem = writer.ToString();
            }

            return renderedItem;
        }
    }
}
