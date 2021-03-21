using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.DrawProcess.Painters;
using DweepConstcoh.Game.Processors.DrawProcess.Painters.GroundPainters;
using DweepConstcoh.Game.Processors.DrawProcess.Painters.ToolsetPainters;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.DrawProcess.Map
{
    public class DrawMapProcessor
    {
        private readonly Bitmap _bufferBitmap;

        private readonly DrawSettings _drawSettings;

        private readonly IMap _map;

        private readonly MapLayer[] _mapLayerOrder;

        private readonly IEnumerable<IPainter> _painters;

        public DrawMapProcessor(IMap map)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();

            this._drawSettings = new DrawSettings();
            this._bufferBitmap = new Bitmap(
                this._drawSettings.PointSize * map.Width,
                this._drawSettings.PointSize * map.Height);

            this._map = map;
            this._mapLayerOrder = new[]
            {
                MapLayer.Ground,
                MapLayer.PlayerBody,
                MapLayer.Air
            };

            this._painters = new IPainter []
            {
                new GroundPainter(this._drawSettings),
                new WallPainter(this._drawSettings),
                new FinishPainter(this._drawSettings),

                new PlayerPainter(this._drawSettings),

                new PlayerMoverPainter(this._drawSettings),
                new ToolsetSelectorPainter(this._drawSettings)
            };
        }

        public void Draw(Graphics graphics, int gameTime)
        {
            // Update common draw settings:
            this._drawSettings.GameTime = gameTime;

            // Draw entities to buffer:
            using (var bufferGraphics = Graphics.FromImage(this._bufferBitmap))
            {
                bufferGraphics.Clear(this._drawSettings.BackgroundColor);
                var entitiesSortedByLevel = this._map
                    .ListEntities()
                    .OrderByDrawOrder()
                    .ToList();
                
                entitiesSortedByLevel.ForEach(entity =>
                {
                    this._painters.ForEach((IPainter painter) =>
                    {
                        painter.Draw(entity, bufferGraphics);
                    });
                });
            }

            // Draw buffer to target image:
            graphics.DrawImage(this._bufferBitmap, 0, 0);
        }
    }
}
