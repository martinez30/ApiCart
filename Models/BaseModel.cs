using System;
using Newtonsoft.Json;
namespace ApiCart.Models
{
    public class BaseModel
    {
        [JsonIgnore]
        public long Id { get; set; }
    }
}
