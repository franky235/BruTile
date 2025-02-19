// Copyright (c) BruTile developers team. All rights reserved. See License.txt in the project root for license information.

using System.Xml;
using System.Xml.Linq;

namespace BruTile.Wms
{
    public class StyleSheetURL : XmlObject
    {
        private OnlineResource _onlineResourceField;

        public StyleSheetURL()
        { }

        public StyleSheetURL(XElement node, string @namespace)
        {
            var element = node.Element(XName.Get("Format", @namespace));
            Format = element == null ? "png" : element.Value;

            element = node.Element(XName.Get("OnlineResource", @namespace));
            if (element != null)
                OnlineResource = new OnlineResource(element);
        }

        public override XElement ToXElement(string @namespace)
        {
            return new XElement(XName.Get("StyleURL", @namespace),
                                new XElement(XName.Get("Format", @namespace), Format),
                                OnlineResource.ToXElement(@namespace));
        }

        public string Format { get; set; }

        public OnlineResource OnlineResource
        {
            get => _onlineResourceField ??= new OnlineResource();
            set => _onlineResourceField = value;
        }

        #region Overrides of XmlObject

        public override void ReadXml(XmlReader reader)
        {
            var isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement();
            if (!isEmptyElement)
            {
                reader.ReadStartElement("Format");
                Format = reader.ReadContentAsString();
                reader.ReadEndElement();
                OnlineResource.ReadXml(reader);
            }
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Format", Format);
            writer.WriteStartElement("OnlineResource", Namespace);
            OnlineResource.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion Overrides of XmlObject
    }
}
