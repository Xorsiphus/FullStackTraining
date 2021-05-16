using System;

namespace FirstApp.Models
{
    public class Item
    {
        public int Id { set; get; }
        
        public string Name { set; get; }
        
        public string Desc { set; get; }
        
        public string Img { set; get; }
        
        public ushort Price { set; get; }
        
        public bool IsFavorite { set; get; }
        
        public int CategoryId { set; get; }
        
        public virtual Category Category { set; get; }
    }
}