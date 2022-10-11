using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCapacityBalance.Classes
{
    internal class Model
    { 
        Workstation ws1 { get; set; } //Рабочая станция изготовления полуфабрикатов
        Workstation ws2 { get; set; } //Рабочая станция изготовления готового продукта
        int workingHours { get; set; }
        public List<double> halfStuffEachHourAvg { get; }
        public List<int> halfStuffEachHour { get; }
        public Model(int min1, int min2, int max1, int max2, Random rnd,int hours) 
        {
            //Рабочие станции не меняются от розыгрыша к розыгрышу по этому создаём их один раз и работаем с нимим
            ws1=new Workstation(max1,min1,rnd);
            ws2=new Workstation(max2,min2,rnd);
            workingHours= hours;
            halfStuffEachHourAvg = new List<double>();
            halfStuffEachHour = new List<int>();
        }
        //Моделирует один розыгрыш
        public void MakeOneDraw() 
        {
            halfStuffEachHourAvg.Clear();
            halfStuffEachHour.Clear();
            int generalHalfStuff = 0;//Общее количество полуфабриката на складе после одного рабочего цикла
            int halfStuffCount = 0;//Переменная для хранения количества полуфабриката на складе
            int predictionFinalOutcome = 0;
            //Моделируем работу в течении заданого количества часов workingHours
            for (int i = 1; i <= workingHours; i++)
            {
                //Первая станция производит полуфабрикат независимо, так как поток ресурсов не ограничен
                halfStuffCount += ws1.predictOutcome();
                //Вторая станция может произвести либо исходя из своей производственной мощи, либо из остатка полуфабрикатов на складе
                predictionFinalOutcome = ws2.predictOutcome();
                halfStuffCount -= Math.Min(halfStuffCount, predictionFinalOutcome); //Необходиое количество полуфабриката берется со склада
                generalHalfStuff += halfStuffCount;
                //Добавляем в массвы количество полуфабриката в конце этого часа и среднее количество полуфабриката за прошедшие часы работы
                halfStuffEachHour.Add(halfStuffCount);
                halfStuffEachHourAvg.Add((double)generalHalfStuff / i);
            }
        }   
    }
}
