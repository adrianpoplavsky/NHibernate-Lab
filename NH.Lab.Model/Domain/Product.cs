using System;

namespace NH.Lab.Model.Domain
{
    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
   
        public virtual Market Market { get; set; }
    }
}
