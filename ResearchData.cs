using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace BetterLife_Transports

{
    internal class ResearchDt : IResearchNodesData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {
            ResearchNodeProto nodeProto = registrator.ResearchNodeProtoBuilder

                .Start("TransPORT Balancers", BetterLIDs.Research.Transports, 6)
                .Description("Custom vertical balancers for efficient transport.")
                .AddLayoutEntityToUnlock(BetterLIDs.transPorts.balancer3flat)
                .AddLayoutEntityToUnlock(BetterLIDs.transPorts.balancer3loose)
                .AddLayoutEntityToUnlock(BetterLIDs.transPorts.balancer3pipe)

                .AddRequiredProto(Ids.Research.Cp3Packing)
                .AddRequirementForLifetimeProduction(Ids.Products.ConstructionParts2, 50)

                .BuildAndAdd();

            nodeProto.GridPosition = new Vector2i(0, 0);
            nodeProto.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.CpPacking));

            ResearchNodeProto nodeProto1b = registrator.ResearchNodeProtoBuilder
                .Start("TransPORT Bars, 2 new balancer types.", BetterLIDs.Research.Transports2, 8)
                .Description("TransPORT Bars, 2 new balancer types.")


                .AddRequiredProto(BetterLIDs.Research.Transports)

                .AddRequirementForLifetimeProduction(Ids.Products.ConstructionParts2, 100)
                // The last two balancers
                .AddLayoutEntityToUnlock(BetterLIDs.transPorts.balancer3molten)
                .AddLayoutEntityToUnlock(BetterLIDs.transPorts.balancer3shaft)


                // Transport Bars
                .AddLayoutEntityToUnlock((Mafi.Core.Entities.Static.StaticEntityProto.ID)BetterLIDs.transPorts.Get("transBAR03"))
                .AddLayoutEntityToUnlock((Mafi.Core.Entities.Static.StaticEntityProto.ID)BetterLIDs.transPorts.Get("transBAR03loose"))
                .AddLayoutEntityToUnlock((Mafi.Core.Entities.Static.StaticEntityProto.ID)BetterLIDs.transPorts.Get("transBAR03pipe"))
                .AddLayoutEntityToUnlock((Mafi.Core.Entities.Static.StaticEntityProto.ID)BetterLIDs.transPorts.Get("transBAR03molten"))
                .AddLayoutEntityToUnlock((Mafi.Core.Entities.Static.StaticEntityProto.ID)BetterLIDs.transPorts.Get("transBAR03shaft"))


                .BuildAndAdd();

            nodeProto1b.GridPosition = nodeProto.GridPosition.AddX(4);
            nodeProto1b.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(BetterLIDs.Research.Transports));



        }
    }
}
