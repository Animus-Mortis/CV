using System.Collections.Generic;
using UnityEngine;

namespace Game.Localization
{
    public class Translator : MonoBehaviour
    {
        private static int LanguageID;

        private static List<TranslatableText> listID = new List<TranslatableText>();

        private static string welcomeMessage;

        #region All text
        private static string[,] LineText =
        {
            #region English
            {
                "Play",
                "Setting",
                "Read resume",
                "Mouse sensitive",
                "Speed Clipboard",
                "\n   On the wall in front of you there are posters that refer to my game:\n\n  <Simple RPG: The Lich's Legacy>.\n\n" +
                    "This mobile role-playing game is available on Google Play. You can download and play it completely free.\n\n" +
                    "In the mobile RPG <The Lich's Legacy> you help a lich become invincible. Strengthen the lich, develop it through " +
                    "leveling up its skills, equip powerful weapons and summon minions to your team. Focused on real-time auto combat, " +
                    "the game features exciting 3D dark fantasy combat.\n\nYou can find the link in your resume in the my projects section, or by searching by title.",
                "\n   On the wall in front of you there are posters that refer to my game project:" +
                    "\n\n   <Magic Mirror of Answers>." +
                    "\n\n   In this mobile application you can ask any question that concerns you and get an answer." +
                    "\n\n   The answers were written by a qualified psychologist to make it easier for you to decide and understand what you really want." +
                    "\n\n   At the moment, the game has been downloaded by 5+ thousand users. " +
                    "You can also try it by downloading from Google Play using the link in the resume or by searching by name",
                "\n   Here is a gameplay video:\n\n   <Simple RPG: The Lich's Legacy>." +
                    "\n\n   This mobile role-playing game is available on Google Play. You can download and play it completely free." +
                    "\n\n   In the mobile RPG <The Lich's Legacy> you help a lich become invincible. " +
                    "Strengthen the lich, develop it through leveling up its skills, equip powerful weapons and summon minions to your team. " +
                    "Focused on real-time auto combat, the game features exciting 3D dark fantasy combat." +
                    "\n\n   You can find the link in your resume in the my projects section, or by searching by title.",
                "\n\n   Here is a gameplay video:\n\n       <Garbage Man>" +
                    "\n\n   This mobile game is available on Google Play." +
                    "\n\n   This game uses a lot of physics, but it is optimized so that it can be played on weak mobile devices.",
                "\n\n   Here is a gameplay video of a small addition to the game." +
                    "\n\n   This is a PC game in which you need to control a wyvern." +
                    "\n\n\n This project implements control of a flying creature with the peculiarities of cornering and landing on an uneven surface. " +
                    "In this case, no physics was used all calculations were done manually for optimization.",
                "\n\n\n Here is a gameplay video:\n\n       <Bow Rush>" +
                    "\n\n   This is a mobile game in the hypercausal genre. " +
                    "To help the player, assistants have been developed that can completely replace the player in those tasks that he does not have time to solve: " +
                    "destroying enemies, capturing treasures, delivering treasures to the base, selecting weapons.",
                "\n\n\n     Here is a gameplay video of the killer game\n\n   Vampire Survivors" +
                    "\n\n\n     This is a mobile game in the hypercausal genre. " +
                    "A clone of Vampire Survivors with a change in setting and more causality. " +
                    "It has the logic of upgrading random perks to choose from and a balance of increasing the difficulty of opponents depending on the player’s " +
                    "leveling up and time at the level.",
                "\n\n\n     Here is a gameplay video of the game:\n\n   <Robot Run>" +
                    "\n\n\n     This is a mobile game in the hypercausal genre. " +
                    "In which the player controls a running man and the robot reacts depending on what the runner has collected. " +
                    "The level is completely random and the sequence of appearance of new bonuses/buttons depended on the state of the robot and the enemy. " +
                    "Thus, the replay value of the project was created.",
                "Just as gold has disappeared, so our opportunities disappear while we hesitate...\n\nDon't miss your treasure!",
                "			My skills:\n·        C#, OOP, SOLID\n·        Knowledge of basic patterns\n         design\n·        SQL, MySQL" +
                    "\n·        WinForms and WPF\n         Unity\n·        API connections\n·        Setting up a multiplayer server\n·        SDK connection" +
                    "\n·        Git\n\nUnity:\n·        Development of 2D and 3D projects\n·        Development of AR and VR projects" +
                    "\n·        Development on Android, IOS, Desktop,\n         WebGL\n·        Publishing applications on Google Play" +
                    "\n·        Animation development\n·        VFX and ShaderGraph\n·        Zenject\n·        Addressables" +
                    "\n\nLanguages:\n·        Russian – native language\n·        English – intermediate",
                "		My experience:\n\n  Freelancing (07.2022)\nUnity Developer\nDeveloped and finalized games and helped in the implementation of customer features" +
                    "\n\n   Syazan OU (10.2021 – 06.2022)\nUnity Developer\nDeveloped 2D and 3D GC games for the company and the customer" +
                    "\n\n   Simcoe Lab (10.2020 – 10.2021)" +
                    "\nLead Unity Developer" +
                    "\nDeveloped products from scratch to order and modified existing ones for mobile platforms and WebGL" +
                    "\n\n   Freelancing (03.2020 – 10.2020)\nUnity Developer",
            },
            #endregion

            #region Russian
            {
                "Играть",                  // 0
                "Настройки",               // 1
                "Резюме",                  // 2
                "Чувствительность мыши",   // 3
                "Скорость планшета",       // 4
                "	На стене перед вами расположены плакаты которые отсылают к моей игре:" +
                    "\n\n    <Simple RPG: The Lich's Legacy>.\n\n    Это мобильная ролевая игра выложена на Google Play. " +
                    "Вы можете её скачать и поиграть совершенно бесплатно." +
                    "\n\n    В мобильной RPG <The Lich's Legacy> вы помогаете личу стать непобедимым. Усиливайте лича, " +
                    "развивайте его через прокачку умений, снаряжайте мощное оружие и призывайте миньонов в свою команду. " +
                    "Ориентированная на автобой в реальном времени, игра включает в себя захватывающие 3D-бои в жанре темного фэнтези." +
                    "\n\n    Найти ссылку можно в резюме в разделе мои проекты, либо через поиск по названию.", // 5
                "	На стене перед вами расположены плакаты которые отсылают к моему игровому проекту:" +
                    "\n\n    <Magic Mirror of Answers>." +
                    "\n\n   В этом мобильном приложении Вы можете задать любой волнующий Вас вопрос и получить на него ответ." +
                    "\n\n    Ответы писал квалифицированный психолог, чтобы Вам было легче определиться и понять, чего же Вы на самом деле хотите." +
                    "\n\n    На данный момент игру скачало 5+ тысяч пользователей. " +
                    "Вы можете так же опробовать скачав из Google Play по ссылке в резюме или по поиску по названию", // 6
                "	Перед Вами видео геймплея:\n\n    <Simple RPG: The Lich's Legacy>." +
                    "\n\n    Это мобильная ролевая игра выложена на Google Play. Вы можете её скачать и поиграть совершенно бесплатно." +
                    "\n\n    В мобильной RPG <The Lich's Legacy> вы помогаете личу стать непобедимым. Усиливайте лича, развивайте его через прокачку умений, " +
                    "снаряжайте мощное оружие и призывайте миньонов в свою команду. Ориентированная на автобой в реальном времени, игра включает в себя " +
                    "захватывающие 3D-бои в жанре темного фэнтези." +
                    "\n\n    Найти ссылку можно в резюме в разделе мои проекты, либо через поиск по названию.", // 7
                "\n\n	Перед Вами видео геймплея:\n\n      <Garbage Man>" +
                    "\n\n    Это мобильная игра выложена на Google Play." +
                    "\n\n    В этой игре используется много физики, при этом она оптимизирована, что бы можно было играть на слабых мобильных устройствах.", // 8
                "\n\n    Перед Вами видео геймплея небольшого дополнения к игре." +
                    "\n\n    Это PC игра, в которой необходимо управлять виверной." +
                    "\n\n\n    В данном проекте реализовано управление летающим существом с особенностями накрона на поворотах и приземления на неровную поверхность. " +
                    "При это не было испольовано физики, все расчёты были сделаны в ручную для оптимизации.", // 9
                "\n\n\n    Перед Вами видео геймплея:\n\n       <Bow Rush>" +
                    "\n\n\n    Это мобильная игра в жанре гиперкаузал. " +
                    "В помощь игроку были разработаны помощники, которые могут полностью заменить игрока в тех задачах которые он не успевает решить: " +
                    "уничтожение врагов, захват сокровищ, доставка сокровищ до базы, подбор оружия.", //10
                "\n\n\n    Перед Вами видео геймплея \n     <игры-убийцы>\n\n    Vampire Survivors" +
                    "\n\n\n    Это мобильная игра в жанре гиперкаузал. " +
                    "Клон VampireSurvivors с изменением сеттинга и более каузальна. " +
                    "В ней есть логика прокачки рандомных перков на выбор и баланс усложнения противников в зависимости о тпрокачки игрока и времени на уровне.", //11
                "\n\n\n    Перед Вами видео геймплея игры:\n\n    <Robot Run>" +
                    "\n\n\n    Это мобильная игра в жанре гиперкаузал. " +
                    "В которой игрокй управляет бегущим человечком и робот реагировал в зависимости от того что было собрано бегуном. " +
                    "Уровень полностью рандомный и локига последовательности появления новых бонусов/кнопок зависила от состояния робота и противника. " +
                    "Таким образом была создана реиграбельность проекта.", // 12
                "Как исчезло злато, так и исчезают наши возможности, пока мы медлим...\n\nНе упускай свой клад!", // 13
                "			Мои навыки:\n·        C#, ООП, SOLID\n·        Знание основных паттернов" +
                    "\n         проектирования\n·        SQL, MySQL\n·        WinForms и WPF\n·        Unity" +
                    "\n·        Подключений API\n·        Настройка сервера мультиплеера\n·        Подключение SDK" +
                    "\n·        Git\n\n        Unity:\n·         Разработка 2D и 3D проектов\n·         Разработка AR и VR проектов" +
                    "\n·         Разработка на Android, IOS, Desktop,\n         WebGL\n·         Публикация приложений в Google Play" +
                    "\n·         Разработка анимации\n·         VFX и ShaderGraph\n·         Zenject\n·         Addressables" +
                    "\n\n        Языки:\n·         Русский – родной язык\n·         Английский – средний", // 14
                "		Мой опыт:\n\n    Фриланс (07.2022)\n\n    Unity Developer\nРазрабатывал, дорабатывал игры и помогал в реализации фич заказчика" +
                    "\n\n\n    Syazan OU (10.2021 – 06.2022)\n\n    Unity Developer" +
                    "\nРазрабатывал 2D и 3D ГК игры для компании и заказчика" +
                    "\n\n\n    Simcoe Lab (10.2020 – 10.2021)" +
                    "\n\n    Lead Unity Developer" +
                    "\nРазрабатывал продукты с нуля на заказ и дорабатывал имеющиеся для мобильных платформ и WebGL" +
                    "\n\n    Фриланс (03.2020 – 10.2020)\n\n    Unity Developer", // 15
            }
            #endregion
        };
        #endregion

        public static void SelectLanguage(int id)
        {
            LanguageID = id;
            UpdateTexts();
        }

        public static string GetText(int textKey)
        {
            return LineText[LanguageID, textKey];
        }

        public static void Add(TranslatableText idText)
        {
            listID.Add(idText);
        }

        public static void Delete(TranslatableText idText)
        {
            listID.Remove(idText);
        }

        public static void UpdateTexts()
        {
            for (int i = 0; i < listID.Count; i++)
            {
                listID[i].GetText(LineText[LanguageID, listID[i].textID]);
            }
        }

        public static void AddName(string name, int count)
        {
            for (int i = 0; i < LineText.GetLength(0); i++)
            {
                welcomeMessage = LineText[i, count];
                LineText[i, count] = $"{LineText[i, count]}{name}";
            }
        }

        public static void RemoveName(int count)
        {
            for (int i = 0; i < LineText.GetLength(0); i++)
                LineText[i, count] = welcomeMessage;
        }
    }
}