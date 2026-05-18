using Mafi;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Bridges;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Population;
using Mafi.Core.Prototypes;
using Mafi.Core.Roads;
using Mafi.Core.Trains;
using Mafi.Serialization;
using System;

namespace BetterLife_Transports
{
    [GenerateSerializer(false, null, 0)]
    public class pillarEntity : LayoutEntity, IStaticEntity

    {
        private pillarEntityProto _proto;
        public enum State
        {
            None,
            Working,
            Paused,
            NotEnoughWorkers,
        }

        public State CurrentState { get; private set; }


        public pillarEntity(EntityId id, pillarEntityProto proto, TileTransform transform, EntityContext context) : base(id, proto, transform, context)

        {
            _proto = proto;
        }
        
        public new pillarEntityProto Prototype
        {
            get
            {
                return _proto;
            }
            protected set
            {
                _proto = value;
                base.Prototype = value;
            }
        }

        public override bool CanBePaused => false;

        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

        public static void Serialize(pillarEntity value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }

        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            writer.WriteGeneric(_proto);
        }

        public static pillarEntity Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out pillarEntity obj, (Func<BlobReader, Type, pillarEntity>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }
            return obj;
        }

        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField(this, "_proto", reader.ReadGenericAs<pillarEntityProto>());
        }

        static pillarEntity()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((pillarEntity)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((pillarEntity)obj).DeserializeData(reader);
            };
        }
    }
    public class pillarEntityProto : LayoutEntityProto, IProto, IProtoWithTiers
    {

        public pillarEntityProto(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics, ImmutableArray<AnimationParams> ap)
             : base(id, strings, layout, costs, graphics)
        {
            this.TierData = new TierData(this);
        }

        public override Type EntityType => typeof(pillarEntity);
        public int actionDuration;
        public ITierData TierData { get; }

    }

}