using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CST343Project
{
    [XmlRoot("Computer")]
    public class ComputerPlayer
    {
        [XmlAttribute("ComputerPlayerName")]
        public string Name { get; set; }

        [XmlAttribute("AmountOfChips")]
        public int ChipCount { get; set; }

        public ComputerPlayer()
        {

        }

        public ComputerPlayer(string name, int chipCount)
        {
            Name = name;
            ChipCount = chipCount;
        }

        public void Save(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var XML = new XmlSerializer(typeof(ComputerPlayer));
                XML.Serialize(stream, this);
            }
        }

        public static ComputerPlayer LoadFromFile(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(ComputerPlayer));
                return (ComputerPlayer)XML.Deserialize(stream);
            }
        }

    }
}

