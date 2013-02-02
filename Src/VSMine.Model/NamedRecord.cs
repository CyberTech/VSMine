using System;

namespace VSMine.Model
{
    public class NamedRecord : Record, IComparable<NamedRecord>, IComparable
    {
        protected string Name { get; set; }

        public NamedRecord(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }

        protected bool Equals(NamedRecord other)
        {
            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public override bool Equals(object obj)
        {
            if (obj is NamedRecord)
            {
                NamedRecord comparing = (NamedRecord)obj;
                return this.Id == comparing.Id && this.Name == comparing.Name;
            }
            return false;
        }

        public int CompareTo(NamedRecord other)
        {
            return String.Compare(this.Name, other.Name, StringComparison.CurrentCulture);
        }

        public int CompareTo(object obj)
        {
            if (obj is NamedRecord)
            {
                return this.CompareTo((NamedRecord)obj);
            }
            return 1;
        }
    }
}
