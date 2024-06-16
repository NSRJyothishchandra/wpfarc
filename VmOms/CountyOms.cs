//using NetTopologySuite.Geometries;

//namespace ActiveOutageApi.VmOms
//{
//    public class CountyOms
//    {
//        public int ID { get; set; }
//        public string? Name { get; set; }
//        public long? CustomersServed { get; set; }
//        public int? NoOfOutages { get; set; }
//        public int? TotalCustOut { get; set; }
//        public LineString? Shape { get; set; }
//    }
//}
using NetTopologySuite.Geometries;

namespace ActiveOutageApi.VmOms
{
    public class CountyOms
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public long? CustomersServed { get; set; }
        public int? NoOfOutages { get; set; }
        public int? TotalCustOut { get; set; }
        public Polygon? Shape { get; set; }
    }
}
