using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.Wpf.WpfForms
{
    public class FormElement
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class FormElement<T> : FormElement
    { 
    }

    public class DateElement : FormElement<DateTime>
    { 
    }

    public class StringElement : FormElement<string>
    { 
    }

    public class MultiElement : FormElement<int>
    {
        public List<FormElement<int>> Options { get; set; }
    }
}
