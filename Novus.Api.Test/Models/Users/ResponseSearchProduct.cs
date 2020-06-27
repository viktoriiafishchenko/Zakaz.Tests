using System.Collections.Generic;
using Newtonsoft.Json;

namespace Novus.Api.Test.Models.Users
{
    public class ResponseSearchProduct
    {
        [JsonProperty("categories")]
        public List<CategoriesData> CategoriesData { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("filters")]
        public List<FiltersData> FiltersData { get; set; }
        
        [JsonProperty("results")]
        public List<Results> Results { get; set; }
    }
    
    public class CategoriesData
    {
        [JsonProperty("children")]
        public List<ChildrenData> Children { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class ChildrenData
    {
        [JsonProperty("children")] 
        public List<Children> Children { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class Children
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
    }
    
    public class FiltersData
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("options")]
        public List<Options> Options { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Options
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty ("query")]
        public string Query { get; set; }
    }

    public class Results
    {
        [JsonProperty("bundle")]
        public int Bundle { get; set; }
        
        [JsonProperty("category_id")]
        public string CategoryId { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("discount")]
        public Discount Discounts { get; set; }
        
        [JsonProperty("ean")]
        public string Ean { get; set; }
        
        [JsonProperty("excisable")]
        public bool Excisable { get; set; }
        
        [JsonProperty("fat")]
        public string Fat { get; set; }
        
        [JsonProperty("horeca_only")]
        public bool HorecaOnly { get; set; }
        
        [JsonProperty("in_stock")]
        public bool InStock { get; set; }
        
        [JsonProperty("is_hit")]
        public bool IsHit { get; set; }
        
        [JsonProperty("price")]
        public int Price { get; set; }
        
        [JsonProperty("producer")]
        public Producer Producer { get; set; }
        
        [JsonProperty("shelf_life")]
        public string ShelfLife { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("unit")]
        public string Unit { get; set; }
        
        [JsonProperty("weight")]
        public float Weight { get; set; }
    }

    public class Discount
    {
        [JsonProperty("due_date")]
        public string DueDate { get; set; }
        
        [JsonProperty("old_price")]
        public int OldPrice { get; set; }
        
        [JsonProperty("status")]
        public bool Status { get; set; }
        
        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class Producer
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("trademark")]
        public string Trademark { get; set; }
    }
}