namespace LG_Assignment.Core.Entity
{
    public class DevicePropertyValue
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public int PropertyItemId { get; set; }
        public PropertyItem PropertyItem { get; set; }

        public string Value { get; set; }
    }
}
