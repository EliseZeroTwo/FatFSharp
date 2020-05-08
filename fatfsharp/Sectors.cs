namespace fatfsharp
{
    public class Sectors
    {
        private Fat32 Parent;
        public Sector this[uint LBA]
        {
            get
            {
                return new Sector(Parent.Stream, LBA, 0);
            }
        }

        public Sectors(Fat32 parent)
        {
            Parent = parent;
        }
    }
}