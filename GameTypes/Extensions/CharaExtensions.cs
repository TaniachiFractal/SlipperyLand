using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTypes.Cells;

namespace GameTypes.Extensions
{
    /// <summary>
    /// Extensions for Charas
    /// </summary>
    public static class CharaExtensions
    {
        /// <summary>
        /// Change chara position
        /// </summary>
        public static void ChangePosition(this CharaCellGroup cellGroup, int X, int Y)
        {
            cellGroup.X = X;
            cellGroup.Y = Y;
        }
    }
}
