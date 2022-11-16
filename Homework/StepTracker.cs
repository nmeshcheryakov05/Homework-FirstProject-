using System;
using System.Collections.Generic;

namespace Homework
{
    public class StepTracker
    {
        Dictionary<int, MothData> monthToData = new Dictionary<int, MothData>();


        public StepTracker()
        {
            for (int i = 0; i < 12; i++)
            {
                monthToData.Add(i, new MothData());
            }
        }
    }

    public class MothData
    {
        //заполните класс
    }
}
