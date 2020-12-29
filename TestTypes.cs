using System.Collections.Generic;
using MessagePack;
using ProtoBuf;

namespace SerializationBenchmark
{
    [ProtoContract]
    [MessagePackObject]
    public sealed class ServicePlan
    {
        [ProtoMember(1)]
        [Key(0)]
        public string? ServicePlanId { get; set; }

        [ProtoMember(2)]
        [Key(1)]
        public string? ServicePlanName { get; set; }

        [ProtoMember(3)]
        [Key(2)]
        public string? ProvisioningStatus { get; set; }

        [ProtoMember(4)]
        [Key(3)]
        public string? AppliesTo { get; set; }

        [ProtoMember(5)]
        [Key(6)]
        public int Count { get; set; }
    }

    public enum Color
    {
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
    }

    [ProtoContract]
    [MessagePackObject]
    public sealed class UserLicensesResponse
    {
        [ProtoMember(1)]
        [Key(0)]
        public IList<UserLicense>? Licenses { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]
    public sealed class UserLicense
    {
        [ProtoMember(1)]
        [Key(0)]
        public string? ObjectId { get; set; }

        [ProtoMember(2)]
        [Key(1)]
        public string? SkuId { get; set; }

        [ProtoMember(3)]
        [Key(2)]
        public string? SkuPartNumber { get; set; }

        [ProtoMember(4)]
        [Key(3)]
        public IList<ServicePlan> ServicePlans { get; set; }

        [ProtoMember(5)]
        [Key(4)]
        public IDictionary<string, Color>? FruitColors { get; set; }
    }
}