using DweepConstcoh.Game.Entities;

namespace DweepConstcoh.Game.Tools
{
    public interface IToolset
    {
        int IndexOfSelectedItem { get; }
        EntityType SelectedType { get; }

        void Add(EntityType entityType);
        void FlushSelectedType();
        EntityType Get(int index);
        void RemoveSelected();
        void Select(int index);
    }
}