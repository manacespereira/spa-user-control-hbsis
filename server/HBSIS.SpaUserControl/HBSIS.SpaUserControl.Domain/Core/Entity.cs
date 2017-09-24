using System;

namespace HBSIS.SpaUserControl.Domain.Core
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        
        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}