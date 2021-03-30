using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors.DrawProcess.Painters;
using DweepConstcoh.Game.Processors.DrawProcess.Painters.BombPainters;
using DweepConstcoh.Game.Processors.DrawProcess.Painters.GroundPainters;
using DweepConstcoh.Game.Processors.DrawProcess.Painters.LazerEntities;
using DweepConstcoh.Game.Processors.DrawProcess.Painters.ToolsetPainters;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.DrawProcess.Map
{
    public class DrawMapProcessor : IDrawMapProcessor
    {
        private readonly Bitmap _bufferBitmap;

        private readonly IDrawSettings _drawSettings;

        private readonly IGameState _gameState;

        private readonly IMap _map;

        private readonly MapLayer[] _mapLayerOrder;

        private readonly IEnumerable<IPainter> _painters;

        public DrawMapProcessor(
            IDrawSettings drawSettings,
            IGameState gameState,
            IMap map)
        {
            Condition.Requires(drawSettings, nameof(drawSettings)).IsNotNull();
            Condition.Requires(gameState, nameof(gameState)).IsNotNull();
            Condition.Requires(map, nameof(map)).IsNotNull();

            this._drawSettings = drawSettings;
            this._gameState = gameState;
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

            this._painters = new IPainter[]
            {
                new GroundPainter(this._drawSettings),
                new WallPainter(this._drawSettings),
                new FinishPainter(this._drawSettings),

                new PlayerPainter(this._drawSettings, this._gameState),

                new PlayerMoverPainter(this._drawSettings),
                new ToolsetSelectorPainter(this._drawSettings),

                new LazerPainter(this._drawSettings),
                new LazerRayPainter(this._drawSettings),
                new MirrorPainter(this._drawSettings),

                new BombPainter(this._drawSettings),
                new FirePainter(this._drawSettings),
                new TorchPainter(this._drawSettings)
            };
        }

        public void Draw(Graphics graphics)
        {
            // Update common draw settings:

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
