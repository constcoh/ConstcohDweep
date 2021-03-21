using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;

namespace DweepConstcoh.Game.Processors.TaskProcess.PlayerMoving
{
    public class MovePlayerTask : BaseTask
    {
        private readonly IMap _map;

        private readonly PlayerEntity _player;

        private readonly List<WayPoint> _points;

        public MovePlayerTask(
            IMap map,
            PlayerEntity player,
            List<WayPoint> points)
            : base(delayInMilliseconds: 500, type: TaskType.PlayerMoving)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(player, nameof(player)).IsNotNull();
            Condition.Requires(points, nameof(points)).IsNotNull();

            this._map = map;
            this._player = player;
            this._points = points;
        }

        public override TaskProcessResponse Process()
        {
            if (this._points.Count == 0)
            {
                return new TaskProcessResponse();
            }

            var pointToMove = this.GetPointToMove();
            this.MovePlayer(pointToMove);

            var newTask = new MovePlayerTask(
                this._map,
                this._player,
                this._points);

            return new TaskProcessResponse(newTask);
        }

        private WayPoint GetPointToMove()
        {
            var pointToMove = this._points[0];
            this._points.Remove(pointToMove);
            return pointToMove;
        }

        private void MovePlayer(WayPoint pointToMove)
        {
            this._map
                .At(
                    this._player.X,
                    this._player.Y)
                .RemoveEntity(this._player);

            var mapPointToMove =
            this._map
                .At(
                    pointToMove.X,
                    pointToMove.Y);

            mapPointToMove.AddEntity(this._player);

            this._player.GoTo(mapPointToMove);
        }
    }
}
