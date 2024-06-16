using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public class Statistics
    {

        /// <summary>
        /// Количество попыток
        /// </summary>
        public int countAttempts { get; private set; } = 0;


        /// <summary>
        /// Лучшая скорость
        /// </summary>
        public double bestSpeed { get; set; } = Double.MinValue;

        /// <summary>
        /// Средняя скорость
        /// </summary>
        public double averageSpeed { get; set; } = 0;

        /// <summary>
        /// Худшая скорость
        /// </summary>
        public double worstSpeed { get; set; } = Double.MaxValue;

        public void incrementCountAttemp() { countAttempts++; }

        public void updateSpeed(double newSpeed)
        {
            if (newSpeed > bestSpeed) bestSpeed = newSpeed;
            if (newSpeed < worstSpeed) worstSpeed = newSpeed;

            if (countAttempts == 1) averageSpeed = newSpeed;
            else averageSpeed = (averageSpeed + newSpeed) / 2.0;
        }
    }
}
