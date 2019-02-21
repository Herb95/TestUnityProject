using System;


namespace Test2
{
    [Serializable] 
    public class ItemDate
    {
        public int id { get; set;}
        public string Name { get; set;}
        public ItemDate(){}
        public ItemDate(int id,string n){
            this.id = id;
            this.Name = n;
        }
    }
}