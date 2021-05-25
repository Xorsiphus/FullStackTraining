using System;
using System.Collections.Generic;

namespace FirstApp.Models
{
    public class Category
    {
        public int Id { set; get; }
        
        public string Name { set; get; }
        
        public string Desc { set; get; }
        
        public virtual ICollection<Item> Items { set; get; }
    }
}