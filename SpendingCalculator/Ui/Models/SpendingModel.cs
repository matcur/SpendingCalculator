using System;
using System.Collections.Generic;
using System.Text;

namespace SpendingCalculator.Ui.Models
{
    class SpendingModel : Model
    {
        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public int Value { get; set; }
    }
}
