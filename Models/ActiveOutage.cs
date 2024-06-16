using NetTopologySuite.Geometries;
using System;

namespace ActiveOutageApi.Models
{
    public class ActiveOutage
    {
        public string CaseNumber { get; set; }
        public string ElementType { get; set; }
        public string Phase { get; set; }
        public string Status { get; set; }
        public DateTime StartedOn { get; set; }
        public string? Cause { get; set; }
        public string? Region { get; set; }
        public string? MessageToCustomers { get; set; }
        public int? AffectedCustomers { get; set; }
        public decimal? TotalImpactedCustomers { get; set; }
        public DateTime? Etor { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? Boundary { get; set; }
        public string? Weather { get; set; }
        public string? Failure { get; set; }
        public string? OtherReason { get; set; }
        public string? County { get; set; }
        public string? State { get; set; }
        public bool? IsCrewAssigned { get; set; }
    }
}
