using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Context.Entities
{
    public class JsonEntity
    {
        public int Id { get; set; }
        public string StringField { get; set; }
        [Column(TypeName = "jsonb")]
        public JsonField JsonValField { get; set; }
        [Column(TypeName = "jsonb")]
        public string TestJsonColumn { get; set; }
    }
}
