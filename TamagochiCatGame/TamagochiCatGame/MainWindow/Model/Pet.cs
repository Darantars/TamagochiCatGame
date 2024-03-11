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
        public int Age { get; set; }

        /// <summary>
        /// Отображает текущее здоровье питомца.
        /// </summary>
        public uint Health { get; set; }

        /// <summary>
        /// Отображает текущий уровень голода питомца.
        /// </summary>
        public uint HungerLevel { get; set; }

        /// <summary>
        /// Отображает текущее здоровье питомца.
        /// </summary>
        public uint FatigueLevel { get; set; }

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
                    GameOverEvent();
                }
                else
                {
                    Age += 1;

                    if (HungerLevel < 10)
                    {
                        HungerLevel = HungerLevel + 1;
                    }
                    else
                    {
                        if (HungerLevel == 10)
                        {
                            Health = Health - 1;
                            System.Windows.MessageBox.Show("Ваш питомец голодает. Его здоровье под угрозой.");
                        }
                    }

                    if (Mood >= 1)
                    {
                        Mood = Mood - 1;
                    }
                    else
                    {
                        if(FatigueLevel < 10)
                        {
                            FatigueLevel = FatigueLevel + 1;
                        }
                        System.Windows.MessageBox.Show("Ваш питомец в депрессии. Его силы покидают его.");
                    }

                    if (FatigueLevel < 10)
                    {
                        FatigueLevel = FatigueLevel + 1;
                    }
                    else
                    {
                        if (Health >= 1)
                        {
                            Health = Health - 1;
                            System.Windows.MessageBox.Show("Ваш питомец измотан. Его здоровье под угрозой.");
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
            Health = 10;
            HungerLevel = 0;
            Mood = 8;
            FatigueLevel = 0;
            Age = 0;
        }

        /// <summary>
        /// Метод кормления питомца.
        /// </summary>
        public void Feed()
        {
            if (HungerLevel > 0 && Alive)
            {
                HungerLevel = HungerLevel - 1;
                if (Mood < 10)
                {
                    Mood = Mood + 1;
                }
                else
                {
                    Mood = 10;
                }
            }
            else
            {   
                if (!Alive) 
                {
                    System.Windows.MessageBox.Show("У вас нет питомца.");
                }
                else
                {
                    if(HungerLevel == 0)
                    {
                        System.Windows.MessageBox.Show("Вы перекормили питомца. Переедание вредит его здоровью.");
                        if (Health >= 1)
                        {
                            Health = Health - 1;
                        }
                    }
                        
                }
            }
        }

        /// <summary>
        /// Метод игры с питомцем.
        /// </summary>
        public void Play()
        {
            if (Mood < 10 && FatigueLevel < 10 && Alive)
            {
                Mood = Mood + 1;
                FatigueLevel = FatigueLevel + 1;
            }
            else
            {
                if (!Alive)
                {
                    System.Windows.MessageBox.Show("У вас нет питомца.");
                }
                else
                {
                    if (Mood == 10)
                    {
                        System.Windows.MessageBox.Show("Ваш питомец счастлив!");
                    }
                    if (FatigueLevel == 10)
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
            if (FatigueLevel > 0 && HungerLevel < 10 && Alive)
            {
                FatigueLevel = 0;
                HungerLevel = HungerLevel + 1;
            }
            else
            {
                if (!Alive)
                {
                    System.Windows.MessageBox.Show("У вас нет питомца.");
                }
                else
                {
                    if (HungerLevel == 10)
                    {
                        System.Windows.MessageBox.Show("Ваш питомец не может уснуть от голода.");
                    }
                    if (FatigueLevel == 0)
                    {
                        System.Windows.MessageBox.Show("Ваш питомец абсолютно бодр и не хочет спать.");
                    }
                }
            }
        }

        /// <summary>
        /// Метод лечения питомца.
        /// </summary>
        public void Treat()
        {
            if (Health < 10 && FatigueLevel < 10 && Alive)
            {
                Health = Health + 1;
                FatigueLevel = FatigueLevel + 1;
            }
            else
            {
                if (!Alive)
                {
                    System.Windows.MessageBox.Show("У вас нет питомца.");
                }
                else
                {
                    if (FatigueLevel == 10)
                    {
                        System.Windows.MessageBox.Show("Ваш слишком слаб, чтобы принять лечение.");
                    }
                    if (Health == 10)
                    {
                        System.Windows.MessageBox.Show("Ваш питомец абсолютно здоров, его не нужно лечить.");
                    }
                }
            }
        }


        /// <summary>
        /// Метод вызова события смерти питомца по достижению ее условий.
        /// </summary>
        public void GameOverEvent()
        {
            Alive = false;
            FatigueLevel = 0;
            HungerLevel = 0;
            Mood = 0;
            System.Windows.MessageBox.Show("Вы не справились с ролью хозяина. Ваш питомец заболел. Теперь о нем позаботятся ветеринары, а не вы.");
        }
        #endregion
    }
}
