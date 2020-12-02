﻿using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Microsoft.EntityFrameworkCore;

namespace Bot
{
    class Program
    {
        public static ITelegramBotClient bot;
        static void Main(string[] args)
        {
            bot = new TelegramBotClient("1244554441:AAHULJVSMUs-d0DTWaJaTtqmQ1nLggxjcGM") { Timeout = TimeSpan.FromSeconds(10) };

            try
            {
                var me = bot.GetMeAsync().Result;

                Console.WriteLine($"Я бот {me.Id}, меня зовут {me.FirstName}");

                bot.OnMessage += Bot_OnMessage;
                bot.OnCallbackQuery += BotOnCallbackQueeryRecived;

                bot.StartReceiving();
                Console.ReadKey();
            }

            catch
            {
                Console.WriteLine("Нет подключения к серверу");
                Console.ReadKey();
            }
        }


        /// <summary>
        /// Создание и обработка клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static async void BotOnCallbackQueeryRecived(object sender, CallbackQueryEventArgs e)
        {
            string textMessage = e.CallbackQuery.Data;
            textMessage = textMessage.Trim();
            string name = $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName}";

            Console.WriteLine($"{name} выбрал {textMessage}");

            string[] ReadText;
            string TextTopic;
            string path;

            #region Обработка кнопок с клавиатуры
            switch (textMessage)
            {

                #region Ютуб каналы
                #region SimpleCode
                case ("SimpleCode"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Ведущий канала явно знает, о чем говорит. Его канал посвящен только C#, что говорит о том, что автор максимально погружен в тему и не распыляется на другие языки программирования.
Мы считаем, что этот канал является лучшим выбором, если вы хотите глубоко изучит тему и научиться таким вещам, как машинное обучение и прочим сложным проектам.");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://www.youtube.com/channel/UCtLKO1Cb2GVNrbU7Fi0pM0w");
                    break;
                #endregion

                #region BashkaMen Programming
                case ("BashkaMen Programming"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"На этом канале ты найдешь в основном большие видео с разборами крутых програм, тут ты сможешь узнать многое про паттерны, протатипирование. 
Также ведущие этого канала много и качественно рассказывают про WPF, про то, как выполнять сложные, но интересные проекты, как написаить программу для управления чужим компьютером, например.
А еще у них есть разборы программ других программистов, на чьих ошибках ты можешь научиться. Как говорится 
„Дураки учатся на своих ошибках, а умные — на чужих.“");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://www.youtube.com/c/BashkaMen/featured");
                    break;
                #endregion

                #region Гоша Дударь
                case ("Гоша Дударь"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Гоша Дударь - это один из тех авторов, которые разбираются во многих вещах, но не очень глубоко. 
На его канале вы сможете выучиться азам языка программирования не только C# и WPF, но и таких важных на сегодняшний день ЯП, как JavaScript, PHP, C++, Java и других.
В целом, у него очень понятные видео и качественная подача, для новичка - самое то.");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://www.youtube.com/c/gosha_dudar/featured");
                    break;
                #endregion

                #region Сергей Камянецкий
                case ("Сергей Камянецкий"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Сергей - преподаватель с большим стажем, который работает на такой площадке, как GeekBrains.
Он делает большие стримы, на которых разбирает интересные технологии, такие как EntityFramework, которые необходимы для каждого разработчика.
За счет того, что он делает программы в прямом эфире, хорошо нарабатывается опыт и понимание того, что ты пишешь. 
Записи стримов он всегда сохраняет, их у него уже накопилось очень много, каждый найдет для себя что-то полезное!");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://www.youtube.com/c/SergeyK/featured");
                    break;
                #endregion
                #endregion

                #region Статьи
                #region Введение в C#
                case ("Введение в C#"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"  Ты только начинаешь изучать C#? Вот, послушай, несколько интересных моментов:
    На сегодняшний день, язык программирования C# один из самых мощных, быстро развивающихся и востребованных языков в ИТ-отрасли. В настоящий момент на нем пишутся самые различные приложения: от небольших десктопных программ до крупных веб-порталов и веб-сервисов, обслуживающих ежедневно миллионы пользователей.
    По сравнению с другими языками C# достаточно молодой, но в то же время он уже прошел большой путь. Первая версия языка вышла вместе с релизом Microsoft Visual Studio .NET в феврале 2002 года. Текущей версией языка является версия C# 8.0, которая вышла в сентябре 2019 года вместе с релизом .NET Core 3.
    C# является языком с Си-подобным синтаксисом и близок в этом отношении к C++ и Java. Поэтому, если вы знакомы с одним из этих языков, то овладеть C# будет легче.
    C# является объектно-ориентированным и в этом плане много перенял у Java и С++. Например, C# поддерживает полиморфизм, наследование, перегрузку операторов, статическую типизацию. Объектно-ориентированный подход позволяет решить задачи по построению крупных, но в тоже время гибких, масштабируемых и расширяемых приложений. И C# продолжает активно развиваться, и с каждой новой версией появляется все больше интересных функциональностей, как, например, лямбды, динамическое связывание, асинхронные методы и т.д.");
                    break;
                #endregion

                #region Что такое WPF
                case ("Что такое WPF, и с чем его едят"):
                    path = @"PublicComeInWPF.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    break;
                #endregion

                #region Hello World
                case "Hello World":
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Создадим первое приложение: 'Hello World!' в C#. Запустите Visual Studio.В Windows вы увидите следующее изображение.");
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1E6OqPkPc2vPs4Q-8pG7BAocfYmvyaGfJ/view?usp=sharing");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Выберите «Создать проект» в правом нижнем углу изображения. В Visual Studio отображается диалоговое окно Новый проект:");
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/14yaF-27KwUKXk1A6ds5UU1nurho8NstA/view?usp=sharing");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\HelloWorld\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1TujNcX_rUfkwSebFS5oUki4g5Ux2z_7G/view?usp=sharing");
                    break;
                #endregion

                #region Что нужно знать о платформе
                case ("Что нужно знать о платформе"):
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\2.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\3.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\4.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\5.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\6.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\7.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\8.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\9.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\10.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\11.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\12.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\13.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\14.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\15.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\16.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\17.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\18.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\AboutDotNet\19.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    break;
                #endregion

                #region Массивы
                case "Массивы":
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Array\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/16zLkqI6tPtd7H2L4AUrqUMU08vdk20No/view?usp=sharing");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Array\2.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "Инициализация массива");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Array\3.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/14AX2KcSgrSTENi3gK_nr_8Kiv-NV2onQ/view?usp=sharing");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Array\4.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "Неявно типизированные массивы");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Array\5.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1QvKruCBQOLIrMXMYQ05K2wrh4z16ZDm-/view?usp=sharing");

                
                    break;
                #endregion

                #region Классы 
                case "Классы":
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Class\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Array\2.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    break;
                #endregion

                #region Методы
                case "Методы":
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Method\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1ky7VWjCxERyp-raRTCEEuiDxjeHsdhtc/view?usp=sharing");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Method\2.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Method\3.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "Возврат из метода и возврат значения");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Method\4.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1qqzTirl6CzB7vkJ19InsBslpwz0mUkt9/view?usp=sharing");
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1MbdcwjmUyJQth0WdHkSFFmN9at2aUBm3/view?usp=sharing");
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1E6AIobDm_G0aFTCErcJ9Lj5LsXMoSzrp/view?usp=sharing");

                    break;
                #endregion

                #region Переменные
                case "Переменные":
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "Тут будет статья про переменные");
                    break;
                #endregion

                #region Наследование
                case "Наследование":
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "Тут будет статья про наследование");
                    break;
                #endregion

                #region Полиморфизм
                case "Полиморфизм":
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "Тут будет статья про полиморфизм");
                    break;
                #endregion

                #region Как установить Visual Studio
                case "Как установить Visual Studio":
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\InstallVS\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://www.visualstudio.com/ru/vs/");

                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1FXntQHWeysGgrmy3tVDhja7YZMb-ZBC8/view?usp=sharing");
                    break;
                #endregion

                #region Как устроена среда разработки
                case "Как устроена среда разработки":
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\2.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\3.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\4.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\5.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\6.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\7.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\8.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\9.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\10.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\11.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Tree\12.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    break;

                #endregion

                #region Программа сортировки массива
                case ("Программа сортировки массива"):
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\ArraySort\Text1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://sun9-42.userapi.com/cMDp6XLNBXLIZG1n2QcWsV8Q9-dGyME6iinbXg/IQx2hiatTTY.jpg");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\ArraySort\Text2.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://sun9-4.userapi.com/Ie3FxJLyOCB7EurEE4iwKErWGraOXtyeL1fu5A/7r8-4xGlryA.jpg");
                    break;
                #endregion

                #region Вывод случайного числа
                case ("Вывод случайного числа"):
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\RandomNum\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/167LjUjfezMykkYQRRciUSSFXPAMaZD5P/view?usp=sharing");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\RandomNum\2.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1Vz0fi6heoFlqk1HrEQyawC5L7KtcHtiZ/view?usp=sharing");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\RandomNum\3.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1w0a7mCUGNhEck2IQKp6sHKxy4GEk03rE/view?usp=sharing");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\RandomNum\4.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/16v9ZyHRSjaQHDr50S7t_Om44VuA1vXqf/view?usp=sharing");

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\RandomNum\5.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1iNs23-uqxPK0GKMolu2Kj8bEEoPlwg2C/view?usp=sharing");
                    break;
                #endregion

                #region Как создать приложение WPF
                case ("Как создать приложение WPF"):
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\HowToCreateApp\HowToCreatApp.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://metanit.com/sharp/wpf/pics/1.1.png");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "Укажем проекту какое - нибудь имя и нажмем кнопку OK. И Visual Studio создаст нам новый проект");
                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://metanit.com/sharp/wpf/pics/1.2.png");
                    break;
                #endregion

                #region Как работает дизайн
                case ("Как работает дизайн"):
                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Design\1.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Design\2.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Design\3.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Design\4.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Design\5.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    path = @"C:\Users\Никита\source\repos\Bot\Bot\Resource\Design\6.txt";
                    ReadText = System.IO.File.ReadAllLines(path);
                    TextTopic = string.Concat(ReadText);
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, TextTopic);

                    await bot.SendPhotoAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1uUhGvtj_DXEisoTuNzxc9EXq4aX9QmyR/view?usp=sharing");
                    break;
                #endregion


                #endregion

                #region Книги

                #region Изучение C#
                case ("Изучение C#"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://www.combook.ru/imgrab/0057/11867331_nviss_0.jpg");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Погружаясь в книгу «Язык программирования C# 7 для платформы .NET и .NET Core» Вы выясните, почему на
протяжении более 15 лет она была лидером у разработчиков по всему миру. Сформируете прочный фундамент в виде знаний приемов 
объектно-ориентированной обработки, атрибутов и рефлексии, обобщений и коллекций, а также множества более сложных тем, которые 
не раскрываются в других книгах (коды операций CIL, выпуск динамических сборок и т.д.). 
С помощью настоящей книги вы сможете уверенно использовать язык C# на практике и хорошо ориентироваться в мире .NET");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://shorturl.at/kuNQ7");
                    break;
                #endregion

                #region Изучение WPF
                case ("Изучение WPF"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "http://padabum.com/pics/17450.jpg");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Данное издание представляет собой углубленное руководство по WPF для профессиональных разработчиков, 
знакомых с платформой .NET, языком С# и средой разработки Visual Studio. Книга предлагает полное описание каждого из основных средств WPF - от XAML 
(языка разметки, используемого для определения пользовательских интерфейсов WPF) до трехмерного рисования и анимации.");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://shorturl.at/iv247");
                    break;
                #endregion

                #region CLR Via C# 
                case ("Настольная книга C# разработчика"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://img3.labirint.ru/rc/7a81633559b9ce3bfd7991c901f043ff/220x340/books41/401209/cover.jpg?1598869507");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Эта книга, выходящая в четвертом издании и уже ставшая классическим 
учебником по программированию, подробно описывает внутреннее устройство и функционирование общеязыковой исполняющей среды (CLR) 
Microsoft .NET Framework версии 4.5. Написанная признанным экспертом в области программирования Джеффри Рихтером, много лет являющимся 
консультантом команды разработчиков .NET Framework компании Microsoft, книга научит вас создавать по-настоящему надежные приложения 
любого вида, в том числе с использованием Microsoft Silverlight, ASP.NET, Windows Presentation Foundation и т.д. Четвертое издание полностью
обновлено в соответствии со спецификацией платформы .NET Framework 4.5, а также среды Visual Studio 2012 и C# 5.0");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://drive.google.com/file/d/1zNk561-XvxGgluaPp0bNmpGk3Z-XiQcK/view?usp=sharing");
                    break;
                #endregion

                #region Изучение EntityFramework
                case ("Изучение EntityFramework"):
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://www.kodges.ru/uploads/posts/2019-03/1552840982_cov350m.jpg.pagespeed.ce.jq1FqyvEti.jpg");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, @"Автор объясняет, как извлечь максимальную пользу из Entity Framework Core 2 в проектах MVC. 
Сначала он описывает различные способы моделирования данных посредством инфраструктуры Entity Framework Core 2 и разнообразные типы баз данных, которые могут применяться.
Далее он показывает, каким образом использовать Entity Framework Core 2 в собственных проектах MVC, начиная с основных элементов и заканчивая наиболее сложными и развитыми
функциональными возможностями, и в ходе изложения предоставляет вам все необходимые знания.");
                    await bot.SendTextMessageAsync(e.CallbackQuery.From.Id, "https://shorturl.at/agBDM");
                    break;
                    #endregion
                    #endregion

            }
            #endregion
        }

        /// <summary>
        /// сообщения, которые присылает юзер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            #region обработка неиспользуемых типов информации
            var message = e.Message; //переменная, где хранится сообщение юзера
            string text;
            string nameOfUser = $"{message.From.FirstName} {message.From.LastName}";

            if (message.Type != MessageType.Text)
            {
                Console.WriteLine($"{nameOfUser} неопознанный объект");
                await bot.SendTextMessageAsync(message.From.Id, "Я пока маленький бот, который не умеет работать с этим типом данных :(");
            }
            #endregion

            Console.WriteLine($"{nameOfUser} сообщение: '{message.Text}'");
            //BotEntities modelDB = new BotEntities();

            #region Обработка команд и введенного текста
            switch (message.Text)
            {
                #region Старт
                case "/start":
                    await bot.SendPhotoAsync(message.From.Id, "http://katia.mitsisv.gr/wp-content/uploads/2018/11/frazi.png");

                    text = $@"Рад приветствовать тебя, {nameOfUser}!

Представляю твоему вниманию всего навсего лучшее руководство по разработке на WPF!
Наш бот поможет тебе начать ориентировться в языке программирования C#, научит, как делать дизайн на платформе WPF, как подключать базы данных и многому другому.
Если тебе это интересно, то пиши команду /help, чтобы ознакомиться с тем, на что я способен 😉";
                    //await bot.SendStickerAsync(message.From.Id, "file:///C:/Users/%D0%9D%D0%B8%D0%BA%D0%B8%D1%82%D0%B0/Desktop/sticker.webp");
                    await bot.SendTextMessageAsync(message.From.Id, text);

                    //modelDB.UserInfo.Add(new UserInfo()
                    //{
                    //    UserName = e.Message.Chat.FirstName,
                    //    UserID = e.Message.From.Id,
                    //    Message = e.Message.Text
                    //});
                    //modelDB.SaveChanges();

                    break;
                #endregion

                #region Стоп
                case "/stop":
                    text = "Очень жаль, конечно, что ты нас бросаешь, но я очень надеюсь, что тебе было интересно!";
                    await bot.SendTextMessageAsync(message.From.Id, text);
                    await bot.SendPhotoAsync(message.From.Id, "https://www.ivi.ru/titr/uploads/2016/09/02/da11cf8201ebe0d66e8178c4c5a34e4d.jpg/1400x0");
                    //modelDB.UserInfo.Add(new UserInfo()
                    //{
                    //    UserName = e.Message.Chat.FirstName,
                    //    UserID = e.Message.From.Id,
                    //    Message = e.Message.Text
                    //});
                    //modelDB.SaveChanges();
                    break;
                #endregion

                #region Топ на ютубе 
                case "/youtube":
                    var youtubeBlogers = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("SimpleCode")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Гоша Дударь")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("BashkaMen Programming")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Сергей Камянецкий")
                        }

                    });
                    await bot.SendPhotoAsync(message.From.Id, "https://i2.wp.com/lalupadesherlock.com/wp-content/uploads/2017/05/YouTube_logo-the-lab-media1.png?w=1920&ssl=1");
                    await bot.SendTextMessageAsync(message.From.Id, "Держи список лучших русскоязычных блогеров-C#-программистов, которые научат тебя писать качественный код!", replyMarkup: youtubeBlogers);
                    //modelDB.UserInfo.Add(new UserInfo()
                    //{
                    //    UserName = e.Message.Chat.FirstName,
                    //    UserID = e.Message.From.Id,
                    //    Message = e.Message.Text
                    //});
                    //modelDB.SaveChanges();
                    break;
                #endregion

                #region Список тем
                case "/topic":
                    var menuOfTopics = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Введение в C#")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Что нужно знать о платформе")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Как установить Visual Studio"),
                            InlineKeyboardButton.WithCallbackData("Как устроена среда разработки")
                        },
                        new[]
                        {
                              InlineKeyboardButton.WithCallbackData("Hello World"),
                              InlineKeyboardButton.WithCallbackData("Переменные в C#")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Переменные"),
                            InlineKeyboardButton.WithCallbackData("Массивы")
                        },
                        new[]
                        {
                              InlineKeyboardButton.WithCallbackData("Методы"),
                              InlineKeyboardButton.WithCallbackData("Классы")
                        },
                        new[]
                        {
                              InlineKeyboardButton.WithCallbackData("Наследование"),
                              InlineKeyboardButton.WithCallbackData("Полиморфизм")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Вывод случайного числа"),
                            InlineKeyboardButton.WithCallbackData("Программа сортировки массива")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Что такое WPF, и с чем его едят")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Как создать приложение WPF"),
                            InlineKeyboardButton.WithCallbackData("Как работает дизайн")
                        }
                    }
                    );

                    await bot.SendTextMessageAsync(message.From.Id, "Надеюсь, ниже ты найдешь что-то, что будет для тебя полезно!", replyMarkup: menuOfTopics);
                    await bot.SendTextMessageAsync(message.From.Id, "Данные для статей были взяты с ресурса metanit.com.");
                    //modelDB.UserInfo.Add(new UserInfo()
                    //{
                    //    UserName = e.Message.Chat.FirstName,
                    //    UserID = e.Message.From.Id,
                    //    Message = e.Message.Text
                    //});
                    //modelDB.SaveChanges();
                    break;
                #endregion

                #region О нас
                case "/about":
                    text = $@"Этот бот родился, как проект для Колледжа Предпринимательства №11 🏛
Над созданием данного продукта информационнай деятельности работали: Мазус Никита, Похиленко Александр, Хлыстова Дарья и Мовила Лидия. Рыды познакомиться с тобой, {nameOfUser}!
По любым вопросом и предложениям пиши, буду рад: @Mazus_nikita";
                    await bot.SendTextMessageAsync(message.From.Id, text);
                    await bot.SendStickerAsync(message.From.Id, "https://kickerock.github.io/let-s-Talk/img/avatr2.png");
                    //modelDB.UserInfo.Add(new UserInfo()
                    //{
                    //    UserName = e.Message.Chat.FirstName,
                    //    UserID = e.Message.From.Id,
                    //    Message = e.Message.Text
                    //});
                    //modelDB.SaveChanges();
                    break;
                #endregion

                #region Список книг
                case "/book":
                    text = "Если ты хочешь изучить C# и WPF по книгам, что вот, у меня есть немного :)";
                    var listOfBooks = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Изучение C#")
                        },

                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Изучение WPF")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Изучение EntityFramework")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Настольная книга C# разработчика")
                        }
                    }
                    );
                    await bot.SendTextMessageAsync(message.From.Id, $"{text} \n Надеюсь, ниже ты найдешь что-то, что будет для тебя полезно!", replyMarkup: listOfBooks);
                    //modelDB.UserInfo.Add(new UserInfo()
                    //{
                    //    UserName = e.Message.Chat.FirstName,
                    //    UserID = e.Message.From.Id,
                    //    Message = e.Message.Text
                    //});
                    //modelDB.SaveChanges();
                    break;
                #endregion

                #region Помощь
                case "/help":
                    text = @"Для того, чтобы взаимодействовать с ботом, ты можешь использовать следующие команды:
/start - для вызова первого сообщения;
/stop - если я тебе надоел и ты хочешь прекратить общаться со мной;
/topic - тут ты можешь посмотреть все темы которые я знаю по WPF и изучить их вместе со мной!;
/about - если ты захотел узнать о нас, тыкай;
/youtube - каналы, которые помогут в изучении C#;
/help - полный список команд";
                    await bot.SendPhotoAsync(message.From.Id, "https://upload.wikimedia.org/wikipedia/ru/thumb/1/11/Chip%27n_Dale_Rescue_Rangers_logo.jpg/250px-Chip%27n_Dale_Rescue_Rangers_logo.jpg");
                    await bot.SendTextMessageAsync(message.From.Id, text);
                    //modelDB.UserInfo.Add(new UserInfo()
                    //{
                    //    UserName = e.Message.Chat.FirstName,
                    //    UserID = e.Message.From.Id,
                    //    Message = e.Message.Text
                    //});
                    //modelDB.SaveChanges();
                    break;
                #endregion

                #region Все остальное
                default:
                    text = "Прости, я еще молодой бот и мало, чего умею, но я учусь, будь уверен 🤓";
                    await bot.SendTextMessageAsync(message.From.Id, text);

                    #region Добавление всех сообщений в базу данных
                    try
                    {
                        //modelDB.UserInfo.Add(new UserInfo()
                        //{
                        //    UserName = e.Message.Chat.FirstName,
                        //    UserID = e.Message.From.Id,
                        //    Message = e.Message.Text
                        //});
                        //modelDB.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка базы данных. \n {ex}");
                    }
                    #endregion

                    break;
                    #endregion
            }
            #endregion
        }
    }
}
