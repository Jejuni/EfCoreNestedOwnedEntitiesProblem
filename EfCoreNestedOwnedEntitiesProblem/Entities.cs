using System;

namespace EfCoreNestedOwnedEntitiesProblem
{
    public class EntityOne
    {
        public Guid Id { get; set; }
        public LvlOne MyProp { get; set; }
    }

    public class EntityTwo
    {
        public Guid Id { get; set; }

        public LvlOne MyOtherProp { get; set; }
    }


    public class LvlThree
    {
        public int MyInteger { get; set; }
    }

    public class LvlTwo
    {
        public LvlThree LvlThree { get; set; }
    }

    public class LvlOne
    {
        public LvlTwo LvlTwo { get; set; }
    }
}