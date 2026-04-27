
using Mafi;
using Mafi.Base;
using Mafi.Base.Prototypes.Buildings;
using Mafi.Base.Prototypes.Trains;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Machines;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Mods;
using Mafi.Core.Ports.Io;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Core.Trains;
using Mafi.Curves;
using Mafi.Localization;
using System;
using System.Reflection;
//using static BetterLife.Prototypes.blRoadEntity;
using static BetterLife.Prototypes.CustomEntity;

namespace BetterLife_Transports;

internal class RoadsAndSignsData : IModData
{
    public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();
    public static EntityCosts RoadCosts => new EntityCosts();
     
    public static CubicBezierCurve2f CreateCurve((double, double) start, (double, double) c1, (double, double) c2, (double, double) end)
    {
        return new CubicBezierCurve2f(ImmutableArray.Create(new Vector2f(start.Item1.ToFix32(), start.Item2.ToFix32()), new Vector2f(c1.Item1.ToFix32(), c1.Item2.ToFix32()), new Vector2f(c2.Item1.ToFix32(), c2.Item2.ToFix32()), new Vector2f(end.Item1.ToFix32(), end.Item2.ToFix32())));
    }
    double NearHalf(double value)
    {
        return Math.Max(1, Math.Round(value * 2) / 2.0);
        //(value + multiple - 1) / multiple * multiple
    }
    public CustomEntityPrototype CreateProto(ProtoRegistrator registrato, StaticEntityProto.ID id, string coment, string[] el, EntityCostsTpl ecTpl, string asp, string ico, Proto.ID cat, Fix32 nX, Fix32 nY, Fix32 nZ, ImmutableArray<AnimationParams> ap)
    {
        //Predicate<LayoutTile> predicate = null;
        CustomLayoutToken[] array = new CustomLayoutToken[6];
        array[0] = new CustomLayoutToken("=0=", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int? maxTerrainHeight3 = new int?(h - 1);
            Fix32? vehicleHeight2 = new Fix32?(h - 1);
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse, 0, null, maxTerrainHeight3, vehicleHeight2, null, null, false, false, 0);
        });
        array[1] = new CustomLayoutToken("(W)", delegate (EntityLayoutParams p0, int p1)
        {
            int? minTerrainHeight = new int?(-10);
            int? maxTerrainHeight = new int?(3);
            int num = -9;
            int num2 = 3;
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse;
            int? num3 = minTerrainHeight;
            int? num4 = maxTerrainHeight;
            return new LayoutTokenSpec(num, num2, layoutTileConstraint, null, num3, num4, null, null, null, false, false, 0);
        });
        array[2] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p0, int h)
        {
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            return new LayoutTokenSpec(0, h, layoutTileConstraint, null, null, new int?(h-1), null, null, null, false, false, 0);
        });
        array[3] = new CustomLayoutToken("_0=", delegate (EntityLayoutParams p, int h)
        {
            int heightFrom = h - 1;
            int? maxTerrainHeight3 = new int?(h - 1);
            Fix32? vehicleHeight2 = new Fix32?(h - 1);
            return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.UsingPillar, null, null, maxTerrainHeight3, vehicleHeight2, null, null, false, false, 0);
        });

        array[4] = new CustomLayoutToken("|0|", (param, height) =>
        {
            return new LayoutTokenSpec(
                constraint: LayoutTileConstraint.UsingPillar,
                heightFrom: 0,
                heightToExcl: height,
                maxTerrainHeight: 0,
                minTerrainHeight: 0
            );
        });
        array[5] = new CustomLayoutToken("h0.", delegate (EntityLayoutParams p, int h)
        {
            return new LayoutTokenSpec(h-1, h, LayoutTileConstraint.None, null, null, h-1,h-1, null, null, false, false, 0);
        });



        EntityLayoutParams entityLayoutParams = new EntityLayoutParams(
            customPlacementRange: new ThicknessIRange(0, TransportPillarProto.MAX_PILLAR_HEIGHT.Value - 1),
            customTokens: array
            );

        //EntityLayoutParams entityLayoutParams = new EntityLayoutParams(null, null, false, Ids.TerrainTileSurfaces.Metal1, null, null, null, null, default(Option<IEnumerable<KeyValuePair<char, int>>>), false);


        string[] initLayoutString = el;
        EntityLayout ltemp = registrato.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, el);

        ImmutableArray<ToolbarEntryData> categories = ImmutableArray<ToolbarEntryData>.Empty;
        if (cat != BetterLIDs.ToolBars.HiddenProto)
        {
            categories = ImmutableArray.Create(registrato.GetCategory(cat));
        }


        Proto.Str ps = Proto.CreateStr(id, coment);
        EntityCosts ec = ecTpl.MapToEntityCosts(registrato);
        LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(
            prefabPath: asp,
            prefabOrigin: new RelTile3f(nX, nY, nZ),
            customIconPath: ico,
            categories: categories



            );
        //LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx(asp, default(RelTile3f), ico, default(ColorRgba), false, null, new ImmutableArray<ToolbarCategoryProto>?(registrato.GetCategoriesProtos(cat)), false, false, null, null, default(ImmutableArray<string>), int.MaxValue, false);

        //registrato.PrototypesDb.Add<CustomEntityPrototype>(new CustomEntityPrototype(id, ps, ltemp, ec, lg, ap));
        return new CustomEntityPrototype(id, ps, ltemp, ec, lg, ap);
    }

    public void RegisterData(ProtoRegistrator registrator)
    {
        EntityCostsTpl entityRoadCosts = Build.MaintenanceT1(0).Priority(8).Workers(0);
        ImmutableArray<AnimationParams> noLoop2 = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
        });

        IoPortShapeProto shapeFlat = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.FlatConveyor);
        IoPortShapeProto shapeLoose = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.LooseMaterialConveyor);
        IoPortShapeProto shapePipe = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Pipe);
        IoPortShapeProto shapeMolten = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.MoltenMetalChannel);
        IoPortShapeProto shapeShaft = registrator.PrototypesDb.GetOrThrow<IoPortShapeProto>(Mafi.Base.Ids.IoPortShapes.Shaft);

        ProtosDb prototypesDb = registrator.PrototypesDb;


        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myFlatShape, Proto.Str.Empty, '#', CountableProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/ConveyorUnit/Port-Lod3.prefab", false, shapeFlat.Graphics.DisconnectedPortPrefabPath, shapeFlat.Graphics.DisconnectedPortPrefabPathLod3), null), false);
        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myLooseShape, Proto.Str.Empty, '~', LooseProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/ConveyorUnit/Port-Lod3.prefab", false, shapeLoose.Graphics.DisconnectedPortPrefabPath, shapeLoose.Graphics.DisconnectedPortPrefabPathLod3), null), false);
        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myPipeShape, Proto.Str.Empty, '@', FluidProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/Pipes/Port-Lod3.prefab", showWhenTwoTransportsConnect: true)));
        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myMoltenShape, Proto.Str.Empty, '\'', MoltenProductProto.ProductType, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/MoltenChannel/Port-Lod3.prefab", showWhenTwoTransportsConnect: false, shapeMolten.Graphics.DisconnectedPortPrefabPath, shapeMolten.Graphics.DisconnectedPortPrefabPathLod3)));
        //prototypesDb.Add(new IoPortShapeProto(PortIDs.myShaftShape, Proto.Str.Empty, '|', ProductType.NONE, new IoPortShapeProto.Gfx("Assets/BetterLife/BetterLifes.VisualPatch/ports/port.prefab", "Assets/Base/Transports/Shaft/Port-Lod3.prefab"), new Tag[1] { CoreProtoTags.MechanicalShaft }));





        EntityCostsTpl roadCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(5).CP(10).Product(10, Ids.Products.ConcreteSlab);
        EntityCostsTpl roadCosts2 = Build.MaintenanceT1(0).Priority(8).Workers(5).CP(20).Product(25, Ids.Products.ConcreteSlab);
        EntityCostsTpl wallCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(2).CP(10).Product(15, Ids.Products.ConcreteSlab);
        EntityCostsTpl wallCosts2 = Build.MaintenanceT1(0).Priority(8).Workers(2).CP(20).Product(15, Ids.Products.ConcreteSlab);
        EntityCostsTpl signCosts1 = Build.MaintenanceT1(0).Priority(8).Workers(1).CP(8);
        EntityCostsTpl powerplantCosts1 = Build.MaintenanceT1(8).Priority(8).Workers(12).CP2(100).Product(240, Ids.Products.Iron).Product(80, Ids.Products.Rubber).Product(400, Ids.Products.ConcreteSlab);


        ImmutableArray<AnimationParams> noLoop = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.RepeatAutoTimes(Duration.FromYears(1))
        });
        ImmutableArray<AnimationParams> Loop = ImmutableArray.Create(new AnimationParams[]
        {
            AnimationParams.Loop(100.Percent(),true,"Rotating")
        });



    }




    public void CreateWallProto(ProtoRegistrator registrato, StaticEntityProto.ID staticId, string protoString, string coment, string[] el, string asp, string ico, Proto.ID cat)
    {
        ProtosDb prototypesDb = registrato.PrototypesDb;
        Predicate<LayoutTile> predicate = null;
        CustomLayoutToken[] array = new CustomLayoutToken[1];
        LocStr1 locStr = Loc.Str1(staticId.ToString() + "__desc", coment, "description of Retaining Wall");
        LocStr locStr2 = LocalizationManager.LoadOrCreateLocalizedString0(staticId.ToString() + "_formatted", locStr.Format(5.ToString()).Value);
        Proto.Str str = Proto.CreateStr(staticId, protoString, locStr2, null);
        StaticEntityProto.ID wallId = staticId;
        ImmutableArray<ToolbarEntryData> categoriesProtos = registrato.GetCategoriesProtos(new Proto.ID[] { cat });
        ImmutableArray<ToolbarEntryData>? immutableArray = new ImmutableArray<ToolbarEntryData>?(categoriesProtos);
        ProtosDb protosDb = prototypesDb;
        StaticEntityProto.ID id = wallId;
        Proto.Str str2 = str;
        EntityLayoutParser layoutParser = (EntityLayoutParser)registrato.LayoutParser;
        EntityCosts entityCosts = Costs.Buildings.RetainingWall1.MapToEntityCosts(registrato);


        array[0] = new CustomLayoutToken("(W)", delegate
        {
            int? num = new int?(-14);
            int? num2 = new int?(6);
            int num3 = -13;
            int num4 = 5;
            LayoutTileConstraint layoutTileConstraint = LayoutTileConstraint.None;
            int? num5 = num;
            int? num6 = num2;
            return new LayoutTokenSpec(num3, num4, layoutTileConstraint, null, num5, num6, null, Ids.TerrainMaterials.Slag, null, false, false, 0);
        });

        protosDb.Add<RetainingWallProto>(new RetainingWallProto(id, str2, layoutParser.ParseLayoutOrThrow(new EntityLayoutParams(predicate, array, false, null, null, delegate (TerrainVertexRel v, char c)
        {
            if (c != '#')
            {
                return v;
            }
            return v.WithExtraConstraint(LayoutTileConstraint.DisableTerrainPhysics);

        }, null, null, null, default), el), entityCosts, new LayoutEntityProto.Gfx(asp, new RelTile3f(0, 0, 0), ico, default(ColorRgba), false, null, immutableArray, true, false, null, null, default(ImmutableArray<string>), null, int.MaxValue)), false);
    }
}
internal class MachineDef : IModData
{
    public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();
    public static EntityCosts RoadCosts => new EntityCosts();

    public void RegisterData(ProtoRegistrator registrator)
    {

        //MachineProto cpAssembly = registrator.PrototypesDb.GetOrThrow<MachineProto>(Ids.Machines.AssemblyManual);

        //ProtosDb protosDb = registrator.PrototypesDb;

        //EntityCostsTpl costs = Build.CP(5).MaintenanceT1(0).Priority(8).Workers(0);

        //EntityCostsTpl costsFuelStation = Build.CP(5).MaintenanceT1(5).Priority(8).Workers(4);

        //registrator.FuelStationProtoBuilder
        //    .Start("Better Fuel Station", BetterLIDs.Buildings.FuelStation1)
        //    .Description("Fuel Station T1")
        //    .SetCost(costsFuelStation)
        //    .SetCapacity(500)
        //    .SetFuelProto(Ids.Products.Diesel)
        //    .SetMaxTransferQuantityPerVehicle(80)
        //    .SetCategories(Ids.ToolbarCategories.Vehicles)

        //    .SetLayout
        //        (
        //        "   (1)(1)(1)(1)(1)",
        //        "@A>(1)(1)(1)(1)(1)",
        //        "   (1)(1)(1)(1)(1)",
        //        "   (1)(1)(1)(1)(1)",
        //        "   (1)(1)(1)(1)(1)",
        //        "   (1)(1)(1)(1)(1)",
        //        "   (1)(1)(1)(1)(1)",
        //        "   (1)(1)(1)(1)(1)"
        //        )
        //    .SetPrefabPath("Assets/BetterLife/Buildings/FuelStation.prefab")
        //    .SetCustomIconPath("Assets/BetterLife/Icons/Buildings/FuelStation.png")

        //    .BuildAndAdd()
        //    .AddParam(new DrawArrowWileBuildingProtoParam(4f));

        //Log.Info($"BETTERLIFES: Custom Fuelstation added...");

        /*
        ProtosDb prototypesDb = registrator.PrototypesDb;
        ProductProto orThrow = prototypesDb.GetOrThrow<ProductProto>(IdsCore.Products.Electricity);
        ProductProto orThrow2 = registrator.PrototypesDb.GetOrThrow<FluidProductProto>(Ids.Products.FuelGas);
        ProtosDb prototypesDb2 = registrator.PrototypesDb;
        EntityCostsTpl powerplantCosts1 = Build.MaintenanceT1(8).Priority(8).Workers(12).CP2(20).Product(40, Ids.Products.Iron).Product(10, Ids.Products.Rubber).Product(50, Ids.Products.ConcreteSlab);
        ProductProto orThrow3 = prototypesDb.GetOrThrow<ProductProto>(IdsCore.Products.Electricity);
        ProductProto orThrow4 = prototypesDb.GetOrThrow<ProductProto>(Ids.Products.FuelGas);
        ProductProto orThrow5 = prototypesDb.GetOrThrow<ProductProto>(Ids.Products.Water);
        Proto.Str str1 = Proto.CreateStr(BetterLIDs.Machines.ComPowerPlant, "Combined Cyclic Power Plant", "Cyclic Power...", null);

        EntityLayout entityLayout1 = registrator.LayoutParser.ParseLayoutOrThrow(new string[]
        {
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "@F>=1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "@G>=1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=>Y@",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   ",
                "   =1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1==1=   "
        });
        EntityCosts entityCosts = powerplantCosts1.MapToEntityCosts(registrator, false);
        prototypesDb.Add<Prototypes.PowerExchangerProto>(new Prototypes.PowerExchangerProto
            (BetterLIDs.Machines.ComPowerPlant, str1, entityLayout1, entityCosts, 600.Mw(), 10, orThrow4.WithQuantity(20), orThrow5.WithQuantity(15), orThrow, 10, 10.Seconds(), DestroyReason.UsedAsFuel, ImmutableArray.Empty, new Prototypes.PowerExchangerProto.Gfx
            ("Assets/BetterLife/Buildings/PowerPlant.prefab",
            ImmutableArray.Empty,
            "Assets/Base/Machines/PowerPlant/CombustionEngine/CombustionEngine_Sound.prefab",
            registrator.GetCategoriesProtos(new Proto.ID[] { Ids.ToolbarCategories.MachinesElectricity }), "Assets/BetterLife/Icons/Buildings/PowerPlant.png", false)), false);
        */
    }

}
