using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SpendingCalculator.Ui.Models
{
    [Serializable]
    public class SpendingCategoryModel : Model
    {
        [XmlAttribute(AttributeName = "Id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
    }
}
