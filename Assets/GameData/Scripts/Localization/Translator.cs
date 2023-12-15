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
                    "It has the logic of upgrading random perks to choose from and a balance of increasing the difficulty of opponents depending on the player�s " +
                    "leveling up and time at the level.",
                "\n\n\n     Here is a gameplay video of the game:\n\n   <Robot Run>" +
                    "\n\n\n     This is a mobile game in the hypercausal genre. " +
                    "In which the player controls a running man and the robot reacts depending on what the runner has collected. " +
                    "The level is completely random and the sequence of appearance of new bonuses/buttons depended on the state of the robot and the enemy. " +
                    "Thus, the replay value of the project was created.",
                "Just as gold has disappeared, so our opportunities disappear while we hesitate...\n\nDon't miss your treasure!",
                "			My skills:\n�        C#, OOP, SOLID\n�        Knowledge of basic patterns\n         design\n�        SQL, MySQL" +
                    "\n�        WinForms and WPF\n         Unity\n�        API connections\n�        Setting up a multiplayer server\n�        SDK connection" +
                    "\n�        Git\n\nUnity:\n�        Development of 2D and 3D projects\n�        Development of AR and VR projects" +
                    "\n�        Development on Android, IOS, Desktop,\n         WebGL\n�        Publishing applications on Google Play" +
                    "\n�        Animation development\n�        VFX and ShaderGraph\n�        Zenject\n�        Addressables" +
                    "\n\nLanguages:\n�        Russian � native language\n�        English � intermediate",
                "		My experience:\n\n  Freelancing (07.2022)\nUnity Developer\nDeveloped and finalized games and helped in the implementation of customer features" +
                    "\n\n   Syazan OU (10.2021 � 06.2022)\nUnity Developer\nDeveloped 2D and 3D GC games for the company and the customer" +
                    "\n\n   Simcoe Lab (10.2020 � 10.2021)" +
                    "\nLead Unity Developer" +
                    "\nDeveloped products from scratch to order and modified existing ones for mobile platforms and WebGL" +
                    "\n\n   Freelancing (03.2020 � 10.2020)\nUnity Developer",
            },
            #endregion

            #region Russian
            {
                "������",                  // 0
                "���������",               // 1
                "������",                  // 2
                "���������������� ����",   // 3
                "�������� ��������",       // 4
                "	�� ����� ����� ���� ����������� ������� ������� �������� � ���� ����:" +
                    "\n\n    <Simple RPG: The Lich's Legacy>.\n\n    ��� ��������� ������� ���� �������� �� Google Play. " +
                    "�� ������ � ������� � �������� ���������� ���������." +
                    "\n\n    � ��������� RPG <The Lich's Legacy> �� ��������� ���� ����� �����������. ���������� ����, " +
                    "���������� ��� ����� �������� ������, ���������� ������ ������ � ���������� �������� � ���� �������. " +
                    "��������������� �� ������� � �������� �������, ���� �������� � ���� ������������� 3D-��� � ����� ������� �������." +
                    "\n\n    ����� ������ ����� � ������ � ������� ��� �������, ���� ����� ����� �� ��������.", // 5
                "	�� ����� ����� ���� ����������� ������� ������� �������� � ����� �������� �������:" +
                    "\n\n    <Magic Mirror of Answers>." +
                    "\n\n   � ���� ��������� ���������� �� ������ ������ ����� ��������� ��� ������ � �������� �� ���� �����." +
                    "\n\n    ������ ����� ����������������� ��������, ����� ��� ���� ����� ������������ � ������, ���� �� �� �� ����� ���� ������." +
                    "\n\n    �� ������ ������ ���� ������� 5+ ����� �������������. " +
                    "�� ������ ��� �� ���������� ������ �� Google Play �� ������ � ������ ��� �� ������ �� ��������", // 6
                "	����� ���� ����� ��������:\n\n    <Simple RPG: The Lich's Legacy>." +
                    "\n\n    ��� ��������� ������� ���� �������� �� Google Play. �� ������ � ������� � �������� ���������� ���������." +
                    "\n\n    � ��������� RPG <The Lich's Legacy> �� ��������� ���� ����� �����������. ���������� ����, ���������� ��� ����� �������� ������, " +
                    "���������� ������ ������ � ���������� �������� � ���� �������. ��������������� �� ������� � �������� �������, ���� �������� � ���� " +
                    "������������� 3D-��� � ����� ������� �������." +
                    "\n\n    ����� ������ ����� � ������ � ������� ��� �������, ���� ����� ����� �� ��������.", // 7
                "\n\n	����� ���� ����� ��������:\n\n      <Garbage Man>" +
                    "\n\n    ��� ��������� ���� �������� �� Google Play." +
                    "\n\n    � ���� ���� ������������ ����� ������, ��� ���� ��� ��������������, ��� �� ����� ���� ������ �� ������ ��������� �����������.", // 8
                "\n\n    ����� ���� ����� �������� ���������� ���������� � ����." +
                    "\n\n    ��� PC ����, � ������� ���������� ��������� ��������." +
                    "\n\n\n    � ������ ������� ����������� ���������� �������� ��������� � ������������� ������� �� ��������� � ����������� �� �������� �����������. " +
                    "��� ��� �� ���� ����������� ������, ��� ������� ���� ������� � ������ ��� �����������.", // 9
                "\n\n\n    ����� ���� ����� ��������:\n\n       <Bow Rush>" +
                    "\n\n\n    ��� ��������� ���� � ����� �����������. " +
                    "� ������ ������ ���� ����������� ���������, ������� ����� ��������� �������� ������ � ��� ������� ������� �� �� �������� ������: " +
                    "����������� ������, ������ ��������, �������� �������� �� ����, ������ ������.", //10
                "\n\n\n    ����� ���� ����� �������� \n     <����-������>\n\n    Vampire Survivors" +
                    "\n\n\n    ��� ��������� ���� � ����� �����������. " +
                    "���� VampireSurvivors � ���������� �������� � ����� ���������. " +
                    "� ��� ���� ������ �������� ��������� ������ �� ����� � ������ ���������� ����������� � ����������� � ��������� ������ � ������� �� ������.", //11
                "\n\n\n    ����� ���� ����� �������� ����:\n\n    <Robot Run>" +
                    "\n\n\n    ��� ��������� ���� � ����� �����������. " +
                    "� ������� ������ ��������� ������� ���������� � ����� ���������� � ����������� �� ���� ��� ���� ������� �������. " +
                    "������� ��������� ��������� � ������ ������������������ ��������� ����� �������/������ �������� �� ��������� ������ � ����������. " +
                    "����� ������� ���� ������� ��������������� �������.", // 12
                "��� ������� �����, ��� � �������� ���� �����������, ���� �� ������...\n\n�� ������� ���� ����!", // 13
                "			��� ������:\n�        C#, ���, SOLID\n�        ������ �������� ���������" +
                    "\n         ��������������\n�        SQL, MySQL\n�        WinForms � WPF\n�        Unity" +
                    "\n�        ����������� API\n�        ��������� ������� ������������\n�        ����������� SDK" +
                    "\n�        Git\n\n        Unity:\n�         ���������� 2D � 3D ��������\n�         ���������� AR � VR ��������" +
                    "\n�         ���������� �� Android, IOS, Desktop,\n         WebGL\n�         ���������� ���������� � Google Play" +
                    "\n�         ���������� ��������\n�         VFX � ShaderGraph\n�         Zenject\n�         Addressables" +
                    "\n\n        �����:\n�         ������� � ������ ����\n�         ���������� � �������", // 14
                "		��� ����:\n\n    ������� (07.2022)\n\n    Unity Developer\n������������, ����������� ���� � ������� � ���������� ��� ���������" +
                    "\n\n\n    Syazan OU (10.2021 � 06.2022)\n\n    Unity Developer" +
                    "\n������������ 2D � 3D �� ���� ��� �������� � ���������" +
                    "\n\n\n    Simcoe Lab (10.2020 � 10.2021)" +
                    "\n\n    Lead Unity Developer" +
                    "\n������������ �������� � ���� �� ����� � ����������� ��������� ��� ��������� �������� � WebGL" +
                    "\n\n    ������� (03.2020 � 10.2020)\n\n    Unity Developer", // 15
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