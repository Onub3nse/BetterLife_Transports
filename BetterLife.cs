using BetterLife.Prototypes;
using HarmonyLib;
using Mafi;
using Mafi.Base;
using Mafi.Collections;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Game;
using Mafi.Core.Input;
using Mafi.Core.Mods;
using Mafi.Core.PathFinding;
using Mafi.Core.Ports.Io;
using Mafi.Core.Prototypes;
using Mafi.Localization;
using Mafi.Numerics;
using Mafi.Unity.InputControl;
using Mafi.Unity.InputControl.Factory;
using Mafi.Unity.Ui;
using Mafi.Unity.Ui.Controllers.LayoutEntityPlacing;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
//using static UnityEngine.UI.Image;
namespace BetterLife_Transports
{
    public sealed class BetterLife : IDisposable, IMod, IModConfig
    {
        public readonly Harmony HarmonyInstance;
        private ModManifest manifest;

        public ModManifest Manifest
        {
            get
            {
                return this.manifest;
            }
        }
        public void ChangeConfigs(Lyst<IConfig> configs)
        {
        }
        public void EarlyInit(DependencyResolver resolver)
        {
        }


        public void Dispose()
        {
        }
        public void MigrateJsonConfig(VersionSlim savedVersion, Dict<string, object> savedValues)
        {
        }
        public Option<IConfig> ModConfig { get; }

        public static Version ModVersion
        {
            get
            {
                return typeof(BetterLife).Assembly.GetName().Version;
            }
        }
        public string Name
        {
            get
            {
                return typeof(BetterLife).Assembly.GetName().Name;
            }
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600000E RID: 14 RVA: 0x00002240 File Offset: 0x00000440
        public int Version
        {
            get
            {
                return typeof(BetterLife).Assembly.GetName().Version.Major * 100 + typeof(BetterLife).Assembly.GetName().Version.Minor * 10 + typeof(BetterLife).Assembly.GetName().Version.Build;
            }
        }


        public ModJsonConfig JsonConfig
        {
            get
            {
                return new ModJsonConfig(this);
            }
        }

        public BetterLife(ModManifest modManifest)

        {
            this.manifest = modManifest;
            //Log.Info($"BetterLife: Applying harmony patch...");
            //HarmonyInstance = new Harmony("BetterLife Transports Harmony Patch");
            //HarmonyInstance.PatchCategory("ClearancePatch");
            //HarmonyInstance.PatchCategory("IoPortPatchCategory");
            //Log.Info($"BetterLife: Harmony patch finished...");
        }
          
        public bool IsUiOnly => false;
         
        public void RegisterPrototypes(ProtoRegistrator registrator)
        {
            ProtosDb prototypesDb = registrator.PrototypesDb;

            ToolbarCategoryProto transPortsParent = new ToolbarCategoryProto(BetterLIDs.ToolBars.TransPORTparent, Proto.CreateStr(BetterLIDs.ToolBars.TransPORT, "transPORT", null, null), 110f, "Assets/BetterLife/Icons/TransportIcons/transPORT.png", false, "TRANSPORTS", null, null, null);
            ToolbarCategoryProto balancersParent = new ToolbarCategoryProto(BetterLIDs.ToolBars.Balancers, Proto.CreateStr(BetterLIDs.ToolBars.Balancers, "Balancers", null, null), 110f, "Assets/BetterLife/Icons/TransportIcons/balancers/balancer3.png", false, "tBALANCERS", null, null, transPortsParent);
            ToolbarCategoryProto balancersFlat = new ToolbarCategoryProto(BetterLIDs.ToolBars.Balancers_Flat, Proto.CreateStr(BetterLIDs.ToolBars.Balancers_Flat, "Flat", null, null), 110f, "Assets/BetterLife/Icons/Toolbar/toolbar_small_flat.png", false, "tBALANCERSFLAT", null, null, transPortsParent);
            ToolbarCategoryProto balancersLoose = new ToolbarCategoryProto(BetterLIDs.ToolBars.Balancers_Loose, Proto.CreateStr(BetterLIDs.ToolBars.Balancers_Loose, "Loose", null, null), 110f, "Assets/BetterLife/Icons/Toolbar/toolbar_small_loose.png", false, "tBALANCERSLOOSE", null, null, transPortsParent);
            ToolbarCategoryProto balancerspipe = new ToolbarCategoryProto(BetterLIDs.ToolBars.Balancers_Pipe, Proto.CreateStr(BetterLIDs.ToolBars.Balancers_Pipe, "Pipe", null, null), 110f, "Assets/BetterLife/Icons/Toolbar/toolbar_small_pipe.png", false, "tBALANCERSPIPE", null, null, transPortsParent);
            ToolbarCategoryProto balancersmolten = new ToolbarCategoryProto(BetterLIDs.ToolBars.Balancers_Molten, Proto.CreateStr(BetterLIDs.ToolBars.Balancers_Molten, "Molten", null, null), 110f, "Assets/BetterLife/Icons/Toolbar/toolbar_small_molten.png", false, "tBALANCERSMOLTEN", null, null, transPortsParent);
            ToolbarCategoryProto balancersshaft = new ToolbarCategoryProto(BetterLIDs.ToolBars.Balancers_Shaft, Proto.CreateStr(BetterLIDs.ToolBars.Balancers_Shaft, "Shaft", null, null), 110f, "Assets/BetterLife/Icons/Toolbar/toolbar_small_shaft.png", false, "tBALANCERSSHSAFT", null, null, transPortsParent);
            ToolbarCategoryProto transBars = new ToolbarCategoryProto(BetterLIDs.ToolBars.TransBars, Proto.CreateStr(BetterLIDs.ToolBars.Balancers_Shaft, "Transport BARS", null, null), 110f, "Assets/BetterLife/Icons/TransportIcons/balancers/balancer3.png", false, "transPortBars", null, null, transPortsParent);
            prototypesDb.Add<ToolbarCategoryProto>(transPortsParent, false);
            prototypesDb.Add<ToolbarCategoryProto>(balancersParent, false);
            prototypesDb.Add<ToolbarCategoryProto>(balancersFlat, false);
            prototypesDb.Add<ToolbarCategoryProto>(balancersLoose, false);
            prototypesDb.Add<ToolbarCategoryProto>(balancerspipe, false);
            prototypesDb.Add<ToolbarCategoryProto>(balancersmolten, false);
            prototypesDb.Add<ToolbarCategoryProto>(balancersshaft, false);
            prototypesDb.Add<ToolbarCategoryProto>(transBars, false);

            //registrator.RegisterData<productData>();

            registrator.RegisterData<transTeleport>();

            //registrator.RegisterData<Bridges>();

            registrator.RegisterDataWithInterface<IResearchNodesData>();

        }
        public bool GameWasLoaded;
        private bool disposedValue;

        public void RegisterDependencies(DependencyResolverBuilder depBuilder, ProtosDb protosDb, bool gameWasLoaded)

        {




        }

        public void Initialize(DependencyResolver resolver, bool gameWasLoaded)
        {
            GameWasLoaded = gameWasLoaded;
            //Option<InputScheduler> isc = resolver.GetResolvedInstance<InputScheduler>();
            //if (isc.HasValue)
            //{
            //    //isc.Value.ScheduleInputCmd<GameConsoleCmd>(new GameConsoleCmd("also_log_to_console"));
            //}
            //Option<ProtosDb> protosDb = resolver.GetResolvedInstance<ProtosDb>();

            ////IEnumerable<blZipperProto> myProtos = protosDb.Value.All<blZipperProto>();
            //IEnumerable<blZipperProto> myProtos = protosDb.Value.All<blZipperProto>();

            //foreach (blZipperProto proto in myProtos)
            //{
            //    if (proto.Strings.Name.ToString().Contains("Balancer"))
            //    {
            //        ImmutableArray<IoPortTemplate> ioPortTemplate = proto.Ports;
            //        foreach (IoPortTemplate port in ioPortTemplate)
            //        {
            //            var disconnectedField1 = port.Shape.Graphics.GetType().GetField("DisconnectedPortPrefabPath", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //            var connectedField1 = port.Shape.Graphics.GetType().GetField("ConnectedPortPrefabPath", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //            var disconnectedField2 = port.Shape.Graphics.GetType().GetField("DisconnectedPortPrefabPathLod3", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //            var connectedField2 = port.Shape.Graphics.GetType().GetField("ConnectedPortPrefabPathLod3", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //            var graphics1 = port.Shape.Graphics;
            //            disconnectedField1.SetValue(graphics1, "Assets/BetterLife/Transports/ports/port.prefab");
            //            connectedField1.SetValue(graphics1, "Assets/BetterLife/Transports/ports/port.prefab");
            //            disconnectedField2.SetValue(graphics1, "Assets/BetterLife/Transports/ports/port.prefab");
            //            connectedField2.SetValue(graphics1, "Assets/BetterLife/Transports/ports/port.prefab");

            //        }

            //    }

            //}
        }


        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }


        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}
