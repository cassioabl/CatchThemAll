using CatchThemAll.Application.Interfaces;
using CatchThemAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatchThemAll.Application.Services
{
    public class CaptureAppService : ICaptureAppService
    {
        public int Capture(string moves)
        {
            var directions = GetDirectionsFromMoves(moves);
            var positions = new List<Position>() { new Position(0, 0) };

            int xAxis = 0, yAxis = 0;
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case Direction.North:
                        xAxis++;
                        AddPositionIfNotExist(positions, new Position(xAxis, yAxis));
                        break;
                    case Direction.South:
                        xAxis--;
                        AddPositionIfNotExist(positions, new Position(xAxis, yAxis));
                        break;
                    case Direction.East:
                        yAxis--;
                        AddPositionIfNotExist(positions, new Position(xAxis, yAxis));
                        break;
                    case Direction.West:
                        yAxis++;
                        AddPositionIfNotExist(positions, new Position(xAxis, yAxis));
                        break;
                }
            }

            return positions.Count;
        }

        private static void AddPositionIfNotExist(IList<Position> positions, Position position)
        {
            if (!positions.Any(p => p.XAxis == position.XAxis && p.YAxis == position.YAxis))
            {
                positions.Add(position);
            }
        }

        private static IEnumerable<Direction> GetDirectionsFromMoves(string moves)
        {
            foreach (var move in moves.ToUpper())
            {
                Direction direction = move switch
                {
                    'N' => Direction.North,
                    'S' => Direction.South,
                    'E' => Direction.East,
                    'O' => Direction.West,
                    _ => throw new ArgumentException("Informe um input válido", moves),
                };

                yield return direction;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
