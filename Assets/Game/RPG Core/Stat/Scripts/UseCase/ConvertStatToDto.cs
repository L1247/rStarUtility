#region

using System.Collections.Generic;
using Stat.Entity;

#endregion

namespace Stat.UseCase
{
    public class ConvertStatToDto
    {
    #region Public Variables

        public static List<StatDto> Transform(List<IStat> stats)
        {
            var statDtos = new List<StatDto>();
            foreach (var stat in stats) statDtos.Add(Transform(stat));

            return statDtos;
        }

    #endregion

    #region Private Methods

        private static StatDto Transform(IStat stat)
        {
            var statDto = new StatDto();
            statDto.Id      = stat.GetId();
            statDto.ActorId = stat.ActorId;
            return statDto;
        }

    #endregion
    }
}