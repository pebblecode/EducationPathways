using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EducationPathways.ServiceBus
{
    /// <summary>
    /// Simple settings class to configure the connection to Windows Azure services.
    /// </summary>
    [XmlRoot("InfrastructureSettings", Namespace = XmlNamespace)]
    public class InfrastructureSettings
    {
        public const string XmlNamespace = @"urn:education-servicebus";

        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(InfrastructureSettings));
        private static readonly XmlReaderSettings readerSettings;

        static InfrastructureSettings()
        {
            var schema = XmlSchema.Read(typeof(InfrastructureSettings).Assembly.GetManifestResourceStream("EducationPathways.ServiceBus.Settings.xsd"), null);
            readerSettings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
            readerSettings.Schemas.Add(schema);
        }

        /// <summary>
        /// Reads the settings from the specified file.
        /// </summary>
        public static InfrastructureSettings Read(string file)
        {
            using (var reader = XmlReader.Create(file, readerSettings))
            {
                return (InfrastructureSettings)serializer.Deserialize(reader);
            }
        }

        public ServiceBusSettings ServiceBus { get; set; }
    }
}
