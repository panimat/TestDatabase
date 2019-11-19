using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Context.Entities
{
    public class JsonEntity
    {
        public int Id { get; set; }
        public string StringField { get; set; }
        public JsonField JsonVal { get; set; }

        [Column(TypeName = "jsonb")]
        public JsonField JsonValField { get; set; }
        
        [Column(TypeName = "json")]
        public JsonField TestJsonColumn { get; set; }
    }
}
