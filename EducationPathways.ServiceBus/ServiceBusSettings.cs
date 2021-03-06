﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EducationPathways.ServiceBus
{
    /// <summary>
    /// Simple settings class to configure the connection to the Windows Azure Service Bus.
    /// </summary>
    [XmlRoot("ServiceBus", Namespace = InfrastructureSettings.XmlNamespace)]
    public class ServiceBusSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSettings"/> class.
        /// </summary>
        public ServiceBusSettings()
        {
            this.ServiceUriScheme = string.Empty;
            this.ServiceNamespace = string.Empty;
            this.ServicePath = string.Empty;

            this.TokenIssuer = string.Empty;
            this.TokenAccessKey = string.Empty;

            this.Topics = new List<TopicSettings>();
        }

        /// <summary>
        /// Gets or sets the service URI scheme.
        /// </summary>
        public string ServiceUriScheme { get; set; }
        /// <summary>
        /// Gets or sets the service namespace.
        /// </summary>
        public string ServiceNamespace { get; set; }
        /// <summary>
        /// Gets or sets the service path.
        /// </summary>
        public string ServicePath { get; set; }
        /// <summary>
        /// Gets or sets the token issuer.
        /// </summary>
        public string TokenIssuer { get; set; }
        /// <summary>
        /// Gets or sets the token access key.
        /// </summary>
        public string TokenAccessKey { get; set; }

        [XmlArray(ElementName = "Topics", Namespace = InfrastructureSettings.XmlNamespace)]
        [XmlArrayItem(ElementName = "Topic", Namespace = InfrastructureSettings.XmlNamespace)]
        public List<TopicSettings> Topics { get; set; }
    }

    [XmlRoot("Topic", Namespace = InfrastructureSettings.XmlNamespace)]
    public class TopicSettings
    {
        public TopicSettings()
        {
            this.Subscriptions = new List<SubscriptionSettings>();
            this.MigrationSupport = new List<UpdateSubscriptionIfExists>();
        }

        [XmlAttribute]
        public bool IsEventBus { get; set; }

        [XmlAttribute]
        public string Path { get; set; }

        [XmlIgnore]
        public TimeSpan DuplicateDetectionHistoryTimeWindow { get; set; }

        [XmlElement("Subscription", Namespace = InfrastructureSettings.XmlNamespace)]
        public List<SubscriptionSettings> Subscriptions { get; set; }

        [XmlArray(ElementName = "MigrationSupport", Namespace = InfrastructureSettings.XmlNamespace)]
        [XmlArrayItem(ElementName = "UpdateSubscriptionIfExists", Namespace = InfrastructureSettings.XmlNamespace)]
        public List<UpdateSubscriptionIfExists> MigrationSupport { get; set; }

        /// <summary>
        /// Don't access this property directly. Use the properly typed 
        /// <see cref="DuplicateDetectionHistoryTimeWindow"/> instead.
        /// </summary>
        /// <remarks>
        /// XmlSerializer still doesn't know how to convert TimeSpan... 
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAttribute("DuplicateDetectionHistoryTimeWindow")]
        public string XmlDuplicateDetectionHistoryTimeWindow
        {
            get { return this.DuplicateDetectionHistoryTimeWindow.ToString("hh:mm:ss"); }
            set { this.DuplicateDetectionHistoryTimeWindow = TimeSpan.Parse(value); }
        }
    }

    [XmlRoot("Subscription", Namespace = InfrastructureSettings.XmlNamespace)]
    public class SubscriptionSettings
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool RequiresSession { get; set; }

        [XmlAttribute]
        public string SqlFilter { get; set; }
    }

    [XmlRoot("UpdateSubscriptionIfExists", Namespace = InfrastructureSettings.XmlNamespace)]
    public class UpdateSubscriptionIfExists
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string SqlFilter { get; set; }
    }
}
