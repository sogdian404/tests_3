using CinemaTicketSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CinemaTicketSystemTests
{
    public class TicketPriceCalculatorTests
    {
        //бесплатные билеты
        [Fact]
        public void CalculatePrice_ShouldReturnZero_ForChildUnder6()
        {
            TicketRequest request = new TicketRequest { 
                Age = 3,
                IsStudent = false,
                Day = DayOfWeek.Saturday,
                IsVip = false,
                SessionTime = new TimeSpan(2,0,0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(0, result);
        }
        //детские билеты
        [Fact]
        public void CalculatePrice_ShouldReturn180_ForAge10()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 10,
                IsStudent = false,
                Day = DayOfWeek.Saturday,
                IsVip = false,
                SessionTime = new TimeSpan(13, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(180, result);
        }
        //обычный билет без скидок
        [Fact]
        public void CalculatePrice_ShouldReturn300_ForNormalPrice()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 33,
                IsStudent = false,
                Day = DayOfWeek.Saturday,
                IsVip = false,
                SessionTime = new TimeSpan(15, 30, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(300, result);
        }
        //студенческая скидка
        [Fact]
        public void CalculatePrice_ShouldReturn240_ForStudents()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 20,
                IsStudent = true,
                Day = DayOfWeek.Saturday,
                IsVip = false,
                SessionTime = new TimeSpan(15, 30, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(240, result);
        }
        //30 летний студент
        [Fact]
        public void CalculatePrice_ShouldReturn240_ForStudentAge30()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 30,
                IsStudent = true,
                Day = DayOfWeek.Saturday,
                IsVip = false,
                SessionTime = new TimeSpan(15, 30, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(300, result);
        }
        //скидка по средам
        [Fact]
        public void CalculatePrice_ShouldReturn210_InWednesday()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 30,
                IsStudent = false,
                Day = DayOfWeek.Wednesday,
                IsVip = false,
                SessionTime = new TimeSpan(15, 30, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(210, result);
        }
        //утренняя скидка
        [Fact]
        public void CalculatePrice_ShouldReturn255_InMorning()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 30,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = false,
                SessionTime = new TimeSpan(8, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(255, result);
        }
        //VIP-билет
        [Fact]
        public void CalculatePrice_ShouldReturn600_ForVip()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 30,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = true,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(600, result);
        }
        //VIP-билет со временной скидкой
        [Fact]
        public void CalculatePrice_ShouldReturn420_ForVipInWednesday()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 30,
                IsStudent = false,
                Day = DayOfWeek.Wednesday,
                IsVip = true,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(420, result);
        }
        //VIP-билет пенсионер
        [Fact]
        public void CalculatePrice_ShouldReturn600_ForVipAge70()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 70,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = true,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(300, result);
        }
        //VIP-билет ребенок
        [Fact]
        public void CalculatePrice_ShouldReturn600_ForVipAge10()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 10,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = true,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(360, result);
        }
        //VIP-билет младенец
        [Fact]
        public void CalculatePrice_ShouldReturnZero_ForVipAge4()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 4,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = true,
                SessionTime = new TimeSpan(15, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculatePrice_ShouldReturn150_ForOld70()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 70,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = false,
                SessionTime = new TimeSpan(14, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(150, result);
        }
        //применение максимальной скидки
        [Fact]
        public void CalculatePrice_ShouldReturn240_ForStudentInMorning()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 25,
                IsStudent = true,
                Day = DayOfWeek.Monday,
                IsVip = false,
                SessionTime = new TimeSpan(8, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(240, result);
        }

        /////////////////////////////////ГРАНИЧНЫЕ/////////////////////////////////
        //Возраст 0
        [Fact]
        public void CalculatePrice_ShouldReturnException_ForAge0()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 0,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = false,
                SessionTime = new TimeSpan(13, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();

            var result = v.CalculatePrice(request);

            Assert.Equal(0, result);
        }
        //Возраст 120
        [Fact]
        public void CalculatePrice_ShouldReturnException_ForAge120()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 120,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = false,
                SessionTime = new TimeSpan(13, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(150, result);
        }

        //беслатные билеты
        [Fact]
        public void CalculatePrice_ShouldReturnZero_ForAge5()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 5,
                IsStudent = false,
                Day = DayOfWeek.Saturday,
                IsVip = false,
                SessionTime = new TimeSpan(2, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(0, result);
        }
       
        //детская скидка
        [Fact]
        public void CalculatePrice_ShouldReturn240_ForChildsAge17()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 17,
                IsStudent = false,
                Day = DayOfWeek.Saturday,
                IsVip = false,
                SessionTime = new TimeSpan(15, 30, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(180, result);
        }
        [Fact]
        public void CalculatePrice_ShouldReturn240_ForChildsAge25()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 25,
                IsStudent = true,
                Day = DayOfWeek.Saturday,
                IsVip = false,
                SessionTime = new TimeSpan(15, 30, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(240, result);
        }

        [Fact]
        public void CalculatePrice_ShouldReturn300_For64()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 64,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = false,
                SessionTime = new TimeSpan(13, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();
            var result = v.CalculatePrice(request);

            Assert.Equal(300, result);
        }
        /////////////////////////////////Исключения/////////////////////////////////
        
        [Fact]
        public void CalculatePrice_ShouldReturnException_ForNull()
        {
            
            TicketPriceCalculator v = new TicketPriceCalculator();

            Assert.Throws<ArgumentNullException>(() => v.CalculatePrice(null));
        }
        //Возраст больше
        [Fact]
        public void CalculatePrice_ShouldReturnException_ForAgeOver121()
        {
            TicketRequest request = new TicketRequest
            {
                Age = 121,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = false,
                SessionTime = new TimeSpan(13, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(() => v.CalculatePrice(request));
        }

        [Fact]
        public void CalculatePrice_ShouldReturnException_ForAgeUnder0()
        {
            TicketRequest request = new TicketRequest
            {
                Age = -5,
                IsStudent = false,
                Day = DayOfWeek.Monday,
                IsVip = false,
                SessionTime = new TimeSpan(13, 0, 0)
            };
            TicketPriceCalculator v = new TicketPriceCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(() => v.CalculatePrice(request));
        }
    }
}
