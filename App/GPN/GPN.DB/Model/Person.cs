using GPN.DB.Attributes;

namespace GPN.DB.Model
{
    [TableName("person")]
    public class Person : Entity
    {
        [ColumnName("name")]
        public string Name { get; set; }
        [ColumnName("description")]
        public string Description { get; set; }

        [ColumnName("user_id")]
        public string UserId { get; set; }

        [ColumnName("point_id")]
        public string PointId { get; set; }

        [ColumnName("last_enter_date")]
        public DateTimeOffset LastEnterDate { get; set; }
    }
}
