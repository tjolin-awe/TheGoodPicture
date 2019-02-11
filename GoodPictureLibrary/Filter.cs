using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoodPictureLibrary
{
    public abstract class Filter : IEquatable<Filter>
    {
        private readonly string _key;

        public Filter(string key)
        {
            _key = key;
        }

        public bool Equals(Filter other)
        {
            return _key.Equals(other.Key, StringComparison.OrdinalIgnoreCase);
        }

        public string Key
        {
            get { return _key; }
        }

        public virtual Bitmap Process(Bitmap source)
        {
            return source;
        }

    }
}
