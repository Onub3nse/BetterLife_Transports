//using static BetterLife.Prototypes.blRoadEntity;
using BetterLife.RoadsAndSigns;
using Mafi;
using Mafi.Base;
using Mafi.Core.Entities.Static;
using Mafi.Core.Factory.Transports;
using Mafi.Core.Ports.Io;
using Mafi.Core.Roads;
using Mafi.Core.Trains;
using System;
using System.Collections.Generic;
using static BetterLife.Prototypes.CustomEntity;
using MachineID = Mafi.Core.Factory.Machines.MachineProto.ID;

namespace BetterLife_Transports
{
    public partial class BetterLIDs
    {
        public partial class dPath
        {
            public dPath(string v1, string v2)
            {
                asset = v1;
                icon = v2;
            }

            public string asset { get; set; }
            public string icon { get; set; }
             
            public static dPath balancer0_flat = new dPath("Assets/BetterLife/Transports/balancer0/balancer0Flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer0flat.png");
            public static dPath balancer1_flat = new dPath("Assets/BetterLife/Transports/balancer1/balancer1flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer0flat.png");
            public static dPath balancer2_flat = new dPath("Assets/BetterLife/Transports/balancer2/balancer2flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer0flat.png");
            public static dPath balancer3_flat = new dPath("Assets/BetterLife/Transports/balancer3/balancer3flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer0flat.png");
            public static dPath balancer4_flat = new dPath("Assets/BetterLife/Transports/balancer4/balancer4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer0flat.png");
            public static dPath balancer5_flat = new dPath("Assets/BetterLife/Transports/balancer5/balancer5flat.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerflat/balancer0flat.png");

            public static dPath balancer0_loose = new dPath("Assets/BetterLife/Transports/balancer0/balancer0loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer0loose.png");
            public static dPath balancer1_loose = new dPath("Assets/BetterLife/Transports/balancer1/balancer1loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer1loose.png");
            public static dPath balancer2_loose = new dPath("Assets/BetterLife/Transports/balancer2/balancer2loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer2loose.png");
            public static dPath balancer3_loose = new dPath("Assets/BetterLife/Transports/balancer3/balancer3loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer3loose.png");
            public static dPath balancer4_loose = new dPath("Assets/BetterLife/Transports/balancer4/balancer4loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer4loose.png");
            public static dPath balancer5_loose = new dPath("Assets/BetterLife/Transports/balancer5/balancer5loose.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerloose/balancer5loose.png");

            public static dPath balancer0_pipe = new dPath("Assets/BetterLife/Transports/balancer0/balancer0pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer1_pipe = new dPath("Assets/BetterLife/Transports/balancer1/balancer1pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer2_pipe = new dPath("Assets/BetterLife/Transports/balancer2/balancer2pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer3_pipe = new dPath("Assets/BetterLife/Transports/balancer3/balancer3pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer4_pipe = new dPath("Assets/BetterLife/Transports/balancer4/balancer4pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");
            public static dPath balancer5_pipe = new dPath("Assets/BetterLife/Transports/balancer5/balancer5pipe.prefab", "Assets/BetterLife/Icons/TransportIcons/balancerPipe.png");


            public static dPath balancer0_molten = new dPath("Assets/BetterLife/Transports/balancer0/balancer0molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer1_molten = new dPath("Assets/BetterLife/Transports/balancer1/balancer1molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer2_molten = new dPath("Assets/BetterLife/Transports/balancer2/balancer2molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer3_molten = new dPath("Assets/BetterLife/Transports/balancer3/balancer3molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer4_molten = new dPath("Assets/BetterLife/Transports/balancer4/balancer4molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");
            public static dPath balancer5_molten = new dPath("Assets/BetterLife/Transports/balancer5/balancer5molten.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0_molten.png");

            public static dPath balancer0_shaft = new dPath("Assets/BetterLife/Transports/balancer0/balancer0shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer1_shaft = new dPath("Assets/BetterLife/Transports/balancer1/balancer1shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer2_shaft = new dPath("Assets/BetterLife/Transports/balancer2/balancer2shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer3_shaft = new dPath("Assets/BetterLife/Transports/balancer3/balancer3shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer4_shaft = new dPath("Assets/BetterLife/Transports/balancer4/balancer4shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");
            public static dPath balancer5_shaft = new dPath("Assets/BetterLife/Transports/balancer5/balancer5shaft.prefab", "Assets/BetterLife/Icons/TransportIcons/balancer0shaft.png");

            public static dPath loader1_flat = new dPath("Assets/BetterLife/Transports/loader1/loader1Flat.prefab", "Assets/BetterLife/Icons/TransportIcons/loader1Flat.png");
            public static dPath loader1_loose = new dPath("Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/TransportIcons/loader_loose.png");
            public static dPath loader1_pipe = new dPath("Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/TransportIcons/loader_pipe.png");
            public static dPath loader1_molten = new dPath("Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/TransportIcons/loader_molten.png");
            public static dPath loader1_shaft = new dPath("Assets/BetterLife/Transports/loader1/loader1.prefab", "Assets/BetterLife/Icons/TransportIcons/loader_shaft.png");

            public static dPath transBar4flat = new dPath("Assets/BetterLife/Transports/transportbars/bar4m/tbar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4flat.png");
            public static dPath transBar4loose = new dPath("Assets/BetterLife/Transports/transportbars/bar4m/tbar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4loose.png");
            public static dPath transBar4pipe = new dPath("Assets/BetterLife/Transports/transportbars/bar10m/transportBar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4pipe.png");
            public static dPath transBar4molten = new dPath("Assets/BetterLife/Transports/transportbars/bar10m/transportBar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4molten.png");
            public static dPath transBar4shaft = new dPath("Assets/BetterLife/Transports/transportbars/bar10m/transportBar4flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4shaft.png");
            public static dPath transBar10flat = new dPath("Assets/BetterLife/Transports/transportbars/bar10m/transportBar10flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transbar4flat.png");

            public static dPath meter1 = new dPath("Assets/BetterLife/Misc/Meter/meter1.prefab", "Assets/BetterLife/Icons/Misc/meter1.png");
            public static dPath meter2 = new dPath("Assets/BetterLife/Misc/Meter/meter2.prefab", "Assets/BetterLife/Icons/Misc/meter2.png");
            public static dPath meter3 = new dPath("Assets/BetterLife/Misc/Meter/meter3.prefab", "Assets/BetterLife/Icons/Misc/meter3.png");
            public static dPath meter4 = new dPath("Assets/BetterLife/Misc/Meter/meter4.prefab", "Assets/BetterLife/Icons/Misc/meter4.png");

            public static dPath sign_coi1 = new dPath("Assets/BetterLife/Signs/signcoi1.prefab", "Assets/BetterLife/Icons/Signs/coisign1.png");
            public static dPath ind_light1 = new dPath("Assets/BetterLife/Misc/IndusLight1/IndLight1.prefab", "Assets/BetterLife/Icons/Misc/indLight1.png");

            public static dPath sign_wrongWay = new dPath("Assets/BetterLife/Signs/Sign_WrongWay.prefab", "Assets/BetterLife/Icons/Signs/prohibidoelpaso.png");
            public static dPath sign_directional1 = new dPath("Assets/BetterLife/Signs/Sign_BiDirectional.prefab", "Assets/BetterLife/Icons/Signs/DobleSentido2.png");

            public static dPath transPORT20_flat = new dPath("Assets/BetterLife/Transports/transport20/transport20.prefab", "Assets/BetterLife/Icons/TransportIcons/transport20_flat.png");
            public static dPath transPORT20_loose = new dPath("", "");
            public static dPath transPORT20_pipe = new dPath("", "");
            public static dPath transPORT20_molten = new dPath("", "");
            public static dPath transPORT20_shaft = new dPath("", "");

            public static dPath transPORT40_flat = new dPath("Assets/BetterLife/Transports/transport40/transport40_flat.prefab", "Assets/BetterLife/Icons/TransportIcons/transport40_flat.png");
            public static dPath transPORT40_loose = new dPath("", "");
            public static dPath transPORT40_pipe = new dPath("", "");
            public static dPath transPORT40_molten = new dPath("", "");
            public static dPath transPORT40_shaft = new dPath("", "");

            public static dPath transPORT100_flat = new dPath("", "");
            public static dPath transPORT100_loose = new dPath("", "");
            public static dPath transPORT100_pipe = new dPath("", "");
            public static dPath transPORT100_molten = new dPath("", "");
            public static dPath transPORT100_shaft = new dPath("", "");

            public static dPath wall1type1 = new dPath("Assets/BetterLife/Walls/WallA/straight1.prefab", "Assets/BetterLife/Icons/Walls/WallA_Straight.png");
            public static dPath wall1crosstype1 = new dPath("Assets/BetterLife/Walls/WallA/cross1.prefab", "Assets/BetterLife/Icons/Walls/WalLA_Cross.png");
            public static dPath wall1teetype1 = new dPath("Assets/BetterLife/Walls/WallA/tee1.prefab", "Assets/BetterLife/Icons/Walls/WallA_Tee.png");
            public static dPath wall1cornertype1 = new dPath("Assets/BetterLife/Walls/WallA/corner1.prefab", "Assets/BetterLife/Icons/Walls/WallA_Corner.png");
        }


        public partial class PortShapes
        {
            public static readonly IoPortShapeProto.ID mFlat = new IoPortShapeProto.ID("mFlat");
            public static readonly IoPortShapeProto.ID mLoose = new IoPortShapeProto.ID("mLoose");
            public static readonly IoPortShapeProto.ID mPipe = new IoPortShapeProto.ID("mPipe");
            public static readonly IoPortShapeProto.ID mMolten = new IoPortShapeProto.ID("mMolten");
            public static readonly IoPortShapeProto.ID mShaft = new IoPortShapeProto.ID("mShaft");
        }
           
        public partial class newTransports
        {
            public static readonly TransportProto.ID newtransFlat = new TransportProto.ID("transportFlat");
        }
         
        public partial class Storages
        {
            public static readonly CustomEntityPrototype.ID indStorage1 = new CustomEntityPrototype.ID("indStorage1");
        }

        public partial class Machines
        {
            public static readonly MachineID AssemblyBlt1 = Ids.Machines.CreateId("AssemblyBlt1");
            public static readonly MachineID AssemblyBlt2 = Ids.Machines.CreateId("AssemblyBlt2");
            //            public static readonly MachineID AssemblyBlt3 = Ids.Machines.CreateId("AssemblyBlt3");
        }
        public void AddTransBar(StaticEntityProto.ID id)
        {
            
        }

        public partial class transPorts
        {
            private static readonly Dictionary<string, StaticEntityProto.ID> _allIds = new();

            private static StaticEntityProto.ID Register(string name)
            {
                var id = new StaticEntityProto.ID(name);
                _allIds[name] = id;        // Only stored in transPorts collection
                return id;
            }

            /// <summary>
            /// Adds a new StaticEntityProto.ID to the transPorts collection
            /// </summary>
            public static void AddTransBar(StaticEntityProto.ID id)
            {

                // Use the string representation as key (adjust if your ID has a .Value or .Name property)
                string key = id.ToString();

                if (_allIds.ContainsKey(key))
                    return;                    // already exists in transPorts

                _allIds[key] = id;
                Log.Info($"Registered new transPort ID: {id}");
            }

            // Optional but very useful helpers
            public static StaticEntityProto.ID? Get(string name)
            {
                _allIds.TryGetValue(name, out var id);
                Log.Info($"Get transPort ID for '{name}': {id}");
                return id;
            }
             
            //public static bool TryGet(string name, out StaticEntityProto.ID? id)
            //{
            //    return _allIds.TryGetValue(name, out id);
            //}

            // Returns only the IDs that belong to transPorts
            public static IReadOnlyCollection<StaticEntityProto.ID> All => _allIds.Values;

            public static readonly StaticEntityProto.ID balancer0flat = new StaticEntityProto.ID("balancer0flat");
            public static readonly StaticEntityProto.ID balancer1flat = new StaticEntityProto.ID("balancer1flat");
            public static readonly StaticEntityProto.ID balancer2flat = new StaticEntityProto.ID("balancer2flat");
            public static readonly StaticEntityProto.ID balancer3flat = new StaticEntityProto.ID("balancer3flat");
            public static readonly StaticEntityProto.ID balancer4flat = new StaticEntityProto.ID("balancer4flat");
            public static readonly StaticEntityProto.ID balancer5flat = new StaticEntityProto.ID("balancer5flat");

            public static readonly StaticEntityProto.ID balancer0loose = new StaticEntityProto.ID("balancer0loose");
            public static readonly StaticEntityProto.ID balancer1loose = new StaticEntityProto.ID("balancer1loose");
            public static readonly StaticEntityProto.ID balancer2loose = new StaticEntityProto.ID("balancer2loose");
            public static readonly StaticEntityProto.ID balancer3loose = new StaticEntityProto.ID("balancer3loose");
            public static readonly StaticEntityProto.ID balancer4loose = new StaticEntityProto.ID("balancer4loose");
            public static readonly StaticEntityProto.ID balancer5loose = new StaticEntityProto.ID("balancer5loose");

            public static readonly StaticEntityProto.ID balancer0pipe = new StaticEntityProto.ID("balancer0pipe");
            public static readonly StaticEntityProto.ID balancer1pipe = new StaticEntityProto.ID("balancer1pipe");
            public static readonly StaticEntityProto.ID balancer2pipe = new StaticEntityProto.ID("balancer2pipe");
            public static readonly StaticEntityProto.ID balancer3pipe = new StaticEntityProto.ID("balancer3pipe");
            public static readonly StaticEntityProto.ID balancer4pipe = new StaticEntityProto.ID("balancer4pipe");
            public static readonly StaticEntityProto.ID balancer5pipe = new StaticEntityProto.ID("balancer5pipe");

            public static readonly StaticEntityProto.ID balancer0molten = new StaticEntityProto.ID("balancer0molten");
            public static readonly StaticEntityProto.ID balancer1molten = new StaticEntityProto.ID("balancer1molten");
            public static readonly StaticEntityProto.ID balancer2molten = new StaticEntityProto.ID("balancer2molten");
            public static readonly StaticEntityProto.ID balancer3molten = new StaticEntityProto.ID("balancer3molten");
            public static readonly StaticEntityProto.ID balancer4molten = new StaticEntityProto.ID("balancer4molten");
            public static readonly StaticEntityProto.ID balancer5molten = new StaticEntityProto.ID("balancer5molten");

            public static readonly StaticEntityProto.ID balancer0shaft = new StaticEntityProto.ID("balancer0shaft");
            public static readonly StaticEntityProto.ID balancer1shaft = new StaticEntityProto.ID("balancer1shaft");
            public static readonly StaticEntityProto.ID balancer2shaft = new StaticEntityProto.ID("balancer2shaft");
            public static readonly StaticEntityProto.ID balancer3shaft = new StaticEntityProto.ID("balancer3shaft");
            public static readonly StaticEntityProto.ID balancer4shaft = new StaticEntityProto.ID("balancer4shaft");
            public static readonly StaticEntityProto.ID balancer5shaft = new StaticEntityProto.ID("balancer5shaft");
        }
        public partial class Buildings
        {
            public static readonly CustomEntityPrototype.ID MineTowerDecor = new CustomEntityPrototype.ID("eMineTowerDecor");
            public static readonly CustomEntityPrototype.ID BillBoard1 = new CustomEntityPrototype.ID("eBillBoard1");
            public static readonly MachineID FuelStation1 = Ids.Machines.CreateId("FuelStation1");
            public static readonly CustomEntityPrototype.ID VehDepot1 = new CustomEntityPrototype.ID("vehicleDepot");
            //public static readonly CustomEntityPrototype.ID RadioTower1 = new CustomEntityPrototype.ID("radiotower");
        }

        public partial class Tools
        {
            //       public static readonly CustomEntityPrototype.ID Tool1 = new CustomEntityPrototype.ID("eTool1");
        }

        public partial class Signs
        {
            public static readonly CustomEntityPrototype.ID Sign_Stop = new CustomEntityPrototype.ID("eStop");
            public static readonly CustomEntityPrototype.ID Sign_Fwd = new CustomEntityPrototype.ID("eSignFwd");
            public static readonly CustomEntityPrototype.ID Sign_Lft = new CustomEntityPrototype.ID("eSignLft");
            public static readonly CustomEntityPrototype.ID Sign_Rocks = new CustomEntityPrototype.ID("eSignRocks");
            public static readonly CustomEntityPrototype.ID Sign_Drop = new CustomEntityPrototype.ID("eSignDrop");
            public static readonly CustomEntityPrototype.ID Sign_Highway = new CustomEntityPrototype.ID("eSignHighway");
            public static readonly CustomEntityPrototype.ID Sign_Limit50 = new CustomEntityPrototype.ID("eSignLimit50");
            public static readonly CustomEntityPrototype.ID Sign_Limit80 = new CustomEntityPrototype.ID("eSignLimit80");
            public static readonly CustomEntityPrototype.ID Sign_Limit100 = new CustomEntityPrototype.ID("eSignLimit100");
            public static readonly CustomEntityPrototype.ID Sign_Limit120 = new CustomEntityPrototype.ID("eSignLimit120");
            public static readonly CustomEntityPrototype.ID Sign_Pedestian = new CustomEntityPrototype.ID("eSignPedestian");
            public static readonly CustomEntityPrototype.ID Sign_Train = new CustomEntityPrototype.ID("eSignTrain");
            public static readonly CustomEntityPrototype.ID Sign_Tunnel = new CustomEntityPrototype.ID("eSignTunnel");
            public static readonly CustomEntityPrototype.ID Sign_Workers = new CustomEntityPrototype.ID("eSignWorkers");
            public static readonly CustomEntityPrototype.ID Sign_Display = new CustomEntityPrototype.ID("eSignDisplay");
            public static readonly CustomEntityPrototype.ID Sign_COI1 = new CustomEntityPrototype.ID("eSigncoi1");
            public static readonly CustomEntityPrototype.ID Sign_WrongWay = new CustomEntityPrototype.ID("eWrongWay");
            public static readonly CustomEntityPrototype.ID Sign_Directional1 = new CustomEntityPrototype.ID("eDirectional1");


        }


    }
}