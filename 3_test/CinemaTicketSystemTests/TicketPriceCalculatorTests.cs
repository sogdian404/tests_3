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
        
        const int normalPrice = 300;
        const int kidsPrice = (int)(normalPrice - (normalPrice * 0.4));
        const int childsPrice = 0;
        const int wednesdayPrice = (int)(normalPrice - (normalPrice * 0.3));
        const int morningPrice = (int)(normalPrice - (normalPrice * 0.15));
        const int studentsPrice = (int)(normalPrice - (normalPrice * 0.2));
        const int oldPrice =(int) (normalPrice - (normalPrice * 0.5));
        const int VipPrice = 600;
        const int VipPriceSubkidsDiscount = (int)(VipPrice - (VipPrice * 0.4));
        const int vipPriceSubWednesdayDiscount = (int)(VipPrice - (VipPrice * 0.3));
        const int VipPriceSubOldPrice =(int) (VipPrice - (VipPrice*0.5));
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
            
            Assert.Equal(childsPrice, result);
        }
        //детские билеты
        [Fact]
        public void CalculatePrice_ShouldReturnKidsPrice_ForAge10()
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

            Assert.Equal(kidsPrice, result);
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

            Assert.Equal(normalPrice, result);
        }
        //студенческая скидка
        [Fact]
        public void CalculatePrice_ShouldReturnStudentsPrice_ForStudents()
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

            Assert.Equal(studentsPrice, result);
        }
        //30 летний студент
        [Fact]
        public void CalculatePrice_ShouldReturnStudentsPrice_ForStudentAge30()
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

            Assert.Equal(normalPrice, result);
        }
        //скидка по средам
        [Fact]
        public void CalculatePrice_ShouldReturnWednesdayPrice_InWednesday()
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

            Assert.Equal(wednesdayPrice, result);
        }
        //утренняя скидка
        [Fact]
        public void CalculatePrice_ShouldReturnMorningPrice_InMorning()
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

            Assert.Equal(morningPrice, result);
        }
        //VIP-билет
        [Fact]
        public void CalculatePrice_ShouldReturnVipPrice_ForVip()
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

            Assert.Equal(VipPrice, result);
        }
        //VIP-билет со временной скидкой
        [Fact]
        public void CalculatePrice_ShouldReturnVipPriceSubWednesdayDiscount_ForVipInWednesday()
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

            Assert.Equal(vipPriceSubWednesdayDiscount, result);
        }
        //VIP-билет пенсионер
        [Fact]
        public void CalculatePrice_ShouldReturnVipPriceSubOldPrice_ForVipAge70()
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

            Assert.Equal(VipPriceSubOldPrice, result);
        }
        //VIP-билет ребенок
        [Fact]
        public void CalculatePrice_ShouldReturnVipPriceSubkidsDiscount_ForVipAndAge10()
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

            Assert.Equal(VipPriceSubkidsDiscount, result);
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

            Assert.Equal(childsPrice, result);
        }

        [Fact]
        public void CalculatePrice_ShouldReturnOldsPrice_ForOld70()
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

            Assert.Equal(oldPrice, result);
        }
        //применение максимальной скидки
        [Fact]
        public void CalculatePrice_ShouldReturnStudentsPrice_ForStudentInMorning()
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

            Assert.Equal(studentsPrice, result);
        }

        /////////////////////////////////ГРАНИЧНЫЕ/////////////////////////////////
        //Возраст 0
        [Fact]
        public void CalculatePrice_ShouldReturnChildPrice_ForAge0()
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

            Assert.Equal(childsPrice, result);
        }
        //Возраст 120
        [Fact]
        public void CalculatePrice_ShouldReturnOldPrice_ForAge120()
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

            Assert.Equal(oldPrice, result);
        }

        //беслатные билеты
        [Fact]
        public void CalculatePrice_ShouldReturnchildPrice_ForAge5()
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

            Assert.Equal(childsPrice, result);
        }
       
        //детская скидка
        [Fact]
        public void CalculatePrice_ShouldReturnKidsPrice_ForChildsAge17()
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

            Assert.Equal(kidsPrice, result);
        }
        [Fact]
        public void CalculatePrice_ShouldReturnStudentsPrice_ForStudentsAge25()
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

            Assert.Equal(studentsPrice, result);
        }

        [Fact]
        public void CalculatePrice_ShouldReturnNormalPrice_For64()
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

            Assert.Equal(normalPrice, result);
        }
        /////////////////////////////////Исключения/////////////////////////////////
        
        [Fact]
        public void CalculatePrice_ShouldReturnArgumentNullException_ForNull()
        {
            
            TicketPriceCalculator v = new TicketPriceCalculator();

            Assert.Throws<ArgumentNullException>(() => v.CalculatePrice(null));
        }
        //Возраст больше
        [Fact]
        public void CalculatePrice_ShouldReturnArgumentOutOfRangeException_ForAgeOver120()
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
        public void CalculatePrice_ShouldReturnArgumentOutOfRangeException_ForAgeUnder0()
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
