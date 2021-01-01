using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SpendingCalculator.Ui.Models
{
    [Serializable]
    public class SpendingModel : Model
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        [XmlAttribute(AttributeName = "CategoryId")]
        public int CategoryId { get; set; }

        [XmlAttribute(AttributeName = "CreatedAt")]
        public DateTime CreatedAt { get; set; }

        private int value;
    }
}
