using System;
using System.Collections.Generic;
using System.Text;

namespace SpendingCalculator.Ui.Models
{
    class SpendingModel : Model
    {
        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; }

        private int value;
    }
}
