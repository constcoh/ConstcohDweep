using System.Collections.Generic;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using MoreLinq;

namespace DweepConstcoh.Game.Tools
{
    public class Toolset
    {
        private const int _size = 10;
        private readonly List<EntityType> _set;

        public Toolset()
        {
            this._set = new List<EntityType>
            {
                EntityType.PlayerMover
            };

            this.SelectedType = EntityType.PlayerMover;
            this.IndexOfSelectedItem = 0;
        }

        public int IndexOfSelectedItem { get; private set; }


        public Toolset(IEnumerable<EntityType> initialEntityTypes)
            : this()
        {
            Condition.Requires(initialEntityTypes, nameof(initialEntityTypes)).IsNotNull();
            initialEntityTypes.ForEach(type => this.Add(type));
        }

        public EntityType SelectedType { get; private set; }

        public void Add(EntityType entityType)
        {
            Condition.Requires(this._set.Count, nameof(this._set)).IsLessThan(_size);

            this._set.Add(entityType);
        }
        
        public EntityType Get(int index)
        {
            Condition.Requires(index, nameof(index)).IsGreaterOrEqual(0);
            return index < this._set.Count
                ? this._set[index]
                : EntityType.None;
        }

        public void FlushSelectedType()
        {
            this.SelectedType = EntityType.PlayerMover;
            this.IndexOfSelectedItem = 0;
        }

        public void RemoveSelected()
        {
            if (this.SelectedType == EntityType.PlayerMover)
            {
                return;
            }

            this._set.RemoveAt(this.IndexOfSelectedItem);
            this.FlushSelectedType();
        }

        public void Select(int index)
        {
            if (index < 0 || index >= this._set.Count)
            {
                this.FlushSelectedType();
                return;
            }

            this.SelectedType = this._set[index];
            this.IndexOfSelectedItem = index;
        }
    }
}
