using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public class Storage
    {
        /// <summary>
        /// Порядковый номер выбранного текста в массиве
        /// </summary>
        public int numberSelectText { get; set; } = 0;

        /// <summary>
        /// Количество ошибок
        /// </summary>
        public int countError { get; set; } = 0;

        /// <summary>
        /// Время печати (интервал)
        /// </summary>
        public TimeSpan timeWriting { get; set; } = new TimeSpan(0);

    }
}
