using System;
using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using DweepConstcoh.Game.MapStructure;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.TaskProcess.PlayerMoving
{
    public class WaySearcher
    {
        private readonly int _infinityWayLength;

        private readonly IMap _map;

        private readonly WayPoint _player;

        private readonly WayPoint[,] _playerCameFrom;

        private readonly WayPoint _target;

        private readonly bool[,] _visitedPoints;

        private readonly int[,] _wayLength;

        public WaySearcher(
            IMap map,
            WayPoint target)
        {
            Condition.Requires(map, nameof(map)).IsNotNull();
            Condition.Requires(target, nameof(target)).IsNotNull();

            this._map = map;
            this._infinityWayLength = map.Width * map.Height * 4;
            this._player = map.GetPlayerPoint();
            this._playerCameFrom = new WayPoint[map.Width, map.Height];
            this._target = target;
            this._visitedPoints = map.CreateBusyPointsMatrix();
            this._wayLength = map.CreateInitialWayLength(this._infinityWayLength);

            this.Search();
        }
        
        public List<WayPoint> ListWayPoints()
        {
            if (_player.Equals(_target) ||
                _wayLength[_target.X, _target.Y] >= this._infinityWayLength)
            {
                return new List<WayPoint>();
            }

            // Restore back way:
            var backway = new List<WayPoint>();
            var currentPoint = _target;
            while(currentPoint != null)
            {
                backway.Add(currentPoint);
                currentPoint = _playerCameFrom[currentPoint.X, currentPoint.Y];
            }

            // Reverse back way and return as way from player to target:
            backway.Reverse();
            return backway;
        }

        private void BuildWayLengths()
        {
            var pointToVisit = this.GetNotVisitedPointWithMinimalWayLength();

            while (pointToVisit != null &&
                this._wayLength[pointToVisit.X, pointToVisit.Y] < this._infinityWayLength)
            {
                var newLength = _wayLength[pointToVisit.X, pointToVisit.Y] + 1;
                var neighbors = pointToVisit.ListNeighbors();
                neighbors.ForEach(point =>
                {
                    if (_visitedPoints[point.X, point.Y] == false &&
                        _wayLength[point.X, point.Y] > newLength)
                    {
                        _wayLength[point.X, point.Y] = newLength;
                        _playerCameFrom[point.X, point.Y] = pointToVisit;
                    }
                });

                this._visitedPoints[pointToVisit.X, pointToVisit.Y] = true;

                pointToVisit = this.GetNotVisitedPointWithMinimalWayLength();
            }
        }

        private WayPoint GetNotVisitedPointWithMinimalWayLength()
        {
            var notVisitedPoints = this.ListNotVisitedPoints();
            if (notVisitedPoints.Any() == false)
            {
                return null;
            }

            var minimumWayLength = notVisitedPoints
                .Min(point => this._wayLength[point.X, point.Y]);

            var pointWithMinimalWayLength = notVisitedPoints
                .FirstOrDefault(point => this._wayLength[point.X, point.Y] == minimumWayLength);

            return pointWithMinimalWayLength;
        }

        private IEnumerable<WayPoint> ListNotVisitedPoints()
        {
            var notVisited = new List<WayPoint>();

            for (int x = 0; x < this._map.Width; ++x)
                for (int y = 0; y < this._map.Height; ++y)
                {
                    if (this._visitedPoints[x, y] == false)
                    {
                        notVisited.Add(new WayPoint(x, y));
                    }
                }

            return notVisited;
        }

        private void LogWayLengths()
        {
            Console.WriteLine("Way Lengths:");
            for (int y = 0; y < _map.Height; ++y)
            {
                for (int x = 0; x < _map.Width; ++x)
                {
                    Console.Write($" {_wayLength[x, y]}\t");
                }
                Console.WriteLine();
            }
        }

        private void PutPlayerOnMap()
        {
            this._playerCameFrom[_player.X, _player.Y] = this._player;
            this._wayLength[_player.X, _player.Y] = 0;

            var playerNeighbors = this._player.ListNeighbors();
            playerNeighbors.ForEach(point =>
            {
                if (_visitedPoints[point.X, point.Y] == false)
                {
                    _wayLength[point.X, point.Y] = 1;
                }
            });
        }

        private void Search()
        {
            this.PutPlayerOnMap();
            this.BuildWayLengths();
            ////this.LogWayLengths();
        }
    }
}
