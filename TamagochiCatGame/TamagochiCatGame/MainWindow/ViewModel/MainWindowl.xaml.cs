using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TamagochiCatGame.PetCreateWindow.View;
using static System.Collections.Specialized.BitVector32;




namespace TamagochiCatGame
{


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Обьект текущего питомца пользователя.
        /// </summary>
        Pet CurrentPet = new  Pet();

        /// <summary>
        /// Таймер события уменьшения голода и настроения со временем
        /// </summary>
        public static System.Timers.Timer DecimalTimer;

        public MainWindow()
        {
            InitializeComponent();
            PetInishalyze();
            PetDecimalingTimer();
            PetViewModalSynq();
        }




        /// <summary>
        /// Создание или загрузка из файла питомца со стартавыми/сохраненными свойствами
        /// </summary>
        public void PetInishalyze()
        {
            //Вариант запуска не из сохранения
            CurrentPet.Name = string.Empty;
            CurrentPet.Age = "0 лет, 0 дней, 0 часов";
            CurrentPet.Stamina = 0;
            CurrentPet.Health = 0;
            CurrentPet.Hunger = 0;
            CurrentPet.Mood = 0;
            

            //Синхронизация с View
            Health_Bar.Value = CurrentPet.Health;
            Health_Status_TextBlock.Text = CurrentPet.Health.ToString();
            Hunger_Bar.Value = CurrentPet.Hunger;
            Hunger_Status_TextBlock.Text = CurrentPet.Hunger.ToString();
            Mood_Bar.Value = CurrentPet.Mood;
            Mood_Status_TextBlock.Text = CurrentPet.Mood.ToString();
            Stamina_Bar.Value = CurrentPet.Stamina;
            Stamina_Status_TextBlock.Text =CurrentPet.Stamina.ToString();

        }

        /// <summary>
        /// Инициализация события уменьшения голода и настроения со временем
        /// </summary>
        public void PetDecimalingTimer()
        {
            DecimalTimer = new System.Timers.Timer(2000);
            DecimalTimer.Elapsed += TimedDecimalEvent;
            DecimalTimer.AutoReset = true;
            DecimalTimer.Enabled = true;
        }

        /// <summary>
        /// Обработка события таймера
        /// </summary>
        public void TimedDecimalEvent(Object source, ElapsedEventArgs e)
        {
            CurrentPet.DecimalEvent();
            
        }

        /// <summary>
        /// Метод синхронизации MVVM для класса питомца. В случае необходимости развития проекта лучше заменять на INotifyPropertyChanged.
        /// </summary>
        public void PetViewModalSynq()
        {
            Health_Bar.Value = CurrentPet.Health;
            Health_Status_TextBlock.Text = CurrentPet.Health.ToString();
            Hunger_Bar.Value = CurrentPet.Hunger;
            Hunger_Status_TextBlock.Text = CurrentPet.Hunger.ToString();
            Mood_Bar.Value = CurrentPet.Mood;
            Mood_Status_TextBlock.Text = CurrentPet.Mood.ToString();
            Stamina_Bar.Value = CurrentPet.Stamina;
            Stamina_Status_TextBlock.Text = CurrentPet.Stamina.ToString();
            if (CurrentPet.Name == null || CurrentPet.Name == string.Empty)
            {
                Pet_Name_Button.Content = "Создать питомца";
            }
            else
            {
                Pet_Name_Button.Content = CurrentPet.Name;
            }
        }

        public void Pet_Name_Button_Click(object sender, EventArgs e)
        {
            if (CurrentPet.Name == null || CurrentPet.Name == string.Empty)
            {
                PetCreateWindow.View.PetCreateWindow PetCreateWindow = new PetCreateWindow.View.PetCreateWindow();
                

                if (PetCreateWindow.ShowDialog() == true)
                {
                    CurrentPet.Create(PetCreateWindow.name);
                }
                else
                {
                    System.Windows.MessageBox.Show("Похоже у вас уже есть питомец.");
                }

            }
            PetViewModalSynq();
        }

        public void Feed_Pet_Button_Click(object sender, EventArgs e)
        {
            if(CurrentPet != null)
            {
                CurrentPet.Feed();
            }
            PetViewModalSynq();
        }

        public void Play_Pet_Button_Click(object sender, EventArgs e)
        {
            if (CurrentPet != null)
            {
                CurrentPet.Play();
            }
            PetViewModalSynq();
        }
        public void Lul_Pet_Button_Click(object sender, EventArgs e)
        {
            if (CurrentPet != null)
            {
                CurrentPet.Lul();
            }
            PetViewModalSynq();
        }
        public void Treat_Pet_Button_Click(object sender, EventArgs e)
        {
            if (CurrentPet != null)
            {
                CurrentPet.Treat();
            }
            PetViewModalSynq();
        }





    }
}
