using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TamagochiCatGame
{
    internal class Pet
    {
        #region Свойства питомца

        /// <summary>
        /// Имя питомца.
        /// </summary>
        public string Name {  get; set; }

        /// <summary>
        /// Возраст питомца.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Отображает текущее здоровье питомца.
        /// </summary>
        public uint Health { get; set; }

        /// <summary>
        /// Отображает текущее здоровье питомца.
        /// </summary>
        public uint Hunger { get; set; }

        /// <summary>
        /// Отображает текущее здоровье питомца.
        /// </summary>
        public uint Stamina { get; set; }

        /// <summary>
        /// Отображает текущее настроение питомца.
        /// </summary>
        public uint Mood { get; set; }

        /// <summary>
        /// Отображает жив ли ваш питомец.
        /// </summary>
        public bool Alive { get; set; }
        #endregion

        #region Методы питомца


        /// <summary>
        /// Метод таймерного события снижения характеристик.
        /// </summary>
        public void DecimalEvent()
        {
            if (Name != null && Alive) 
            {
                if (Health == 0)
                {
                    DiyEvent();
                }
                else
                {
                    if (Hunger >= 10)
                    {
                        Hunger = Hunger - 10;
                    }
                    else
                    {
                        if (Hunger == 0)
                        {
                            Health = Health - 10;
                            System.Windows.MessageBox.Show("Ваш питомец голодает.");
                        }
                    }

                    if (Mood >= 10)
                    {
                        Mood = Mood - 10;
                    }
                    else
                    {
                        if (Mood == 0)
                        {
                            Stamina = Stamina / 2;
                            System.Windows.MessageBox.Show("Ваш питомец в депрессии.");
                        }
                        else
                        {
                            Mood = 0;
                        }
                    }

                    return;
                }
                
            }
            else { return; }

        }

        /// <summary>
        /// Метод первоначльного создания питомца.
        /// </summary>
        public void Create(string name)
        {
            Name = name;
            Alive = true;
            Health = 100;
            Hunger = 80;
            Mood = 80;
            Stamina = 80;
        }

        /// <summary>
        /// Метод кормления питомца.
        /// </summary>
        public void Feed()
        {
            if (Hunger < 100 && Health > 0) 
            {
                Hunger = Hunger + 10;
                Mood = Mood + 5;
            }
            else
            {   
                if (Health == 0) 
                {
                    System.Windows.MessageBox.Show("У вас нет питомца.");
                }
                else
                {
                    System.Windows.MessageBox.Show("Ваш питомец не голоден.");
                }
            }
        }

        /// <summary>
        /// Метод игры с питомцем.
        /// </summary>
        public void Play()
        {
            if (Mood < 100 && Stamina >= 10 && Health > 0)
            {
                Mood = Mood + 10;
                Stamina = Stamina - 10;
            }
            else
            {
                if (Health == 0)
                {
                    System.Windows.MessageBox.Show("У вас нет питомца.");
                }
                else
                {
                    if (Mood == 100)
                    {
                        System.Windows.MessageBox.Show("Ваш питомец не хочет играть.");
                    }
                    if (Stamina <= 10)
                    {
                        System.Windows.MessageBox.Show("У вашего питомца нет сил играть.");
                    }
                }
            }
        }

        /// <summary>
        /// Метод укачивания питомца.
        /// </summary>
        public void Lul()
        {
            if (Stamina < 100 && Hunger >= 10 && Health > 0)
            {
                Stamina = 100;
                Hunger = Hunger - 10;
            }
            else
            {
                if (Health == 0)
                {
                    System.Windows.MessageBox.Show("У вас нет питомца.");
                }
                else
                {
                    if (Hunger <= 10)
                    {
                        System.Windows.MessageBox.Show("Ваш питомец не может уснуть от голода.");
                    }
                    if (Stamina == 100)
                    {
                        System.Windows.MessageBox.Show("Ваш питомец абсолютно бодр.");
                    }
                }
            }
        }

        /// <summary>
        /// Метод лечения питомца.
        /// </summary>
        public void Treat()
        {
            if (Health < 100 && Stamina >= 10 && Health > 0)
            {
                Health = Health + 10;
                Stamina = Stamina - 10;
            }
            else
            {
                if (Health == 0)
                {
                    System.Windows.MessageBox.Show("У вас нет питомца.");
                }
                else
                {
                    if (Stamina <= 10)
                    {
                        System.Windows.MessageBox.Show("Ваш слишком слаб, чтобы принять лечение.");
                    }
                    if (Health == 100)
                    {
                        System.Windows.MessageBox.Show("Ваш питомец абсолютно здоров.");
                    }
                }
            }
        }


        /// <summary>
        /// Метод вызова события смерти питомца по достижению ее условий.
        /// </summary>
        public void DiyEvent()
        {
            Alive = false;
            Stamina = 0;
            Hunger = 0;
            Mood = 0;
            System.Windows.MessageBox.Show("Ваш питомец мертв. Вы никудышный хозяин.");
        }
        #endregion
    }
}
