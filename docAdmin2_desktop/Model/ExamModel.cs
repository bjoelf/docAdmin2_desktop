using System;
using System.Collections.Generic;
using System.Text;

namespace docAdmin2_desktop.Model
{
    class ExamModel
    {
        public string doctor { get; set; }
        public string examType { get; set; }
        public int amount { get; set; }
        public Priority priority { get; set; }
        public DateTime examSent { get; set; }
        public DateTime requestRecived { get; set; }
        public enum Priority { Acute, Electiv, Jour }
    }
}
