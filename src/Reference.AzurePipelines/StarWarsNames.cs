using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWars.Names
{
    public class StarWarsNames
    {
        private static readonly IReadOnlyList<string> Characters = new List<string>
        {
            "2-1B",
            "4-LOM",
            "Aayla Secura",
            "Admiral Ackbar",
            "Admiral Thrawn",
            "Ahsoka Tano",
            "Anakin Solo",
            "Asajj Ventress",
            "Aurra Sing",
            "Senator Bail Organa",
            "Baby Yoda",
            "Barriss Offee",
            "Bastila Shan",
            "Ben Skywalker",
            "Bib Fortuna",
            "Biggs Darklighter",
            "Boba Fett",
            "Bossk",
            "Brakiss",
            "C-3PO",
            "Cad Bane",
            "Cade Skywalker",
            "Callista Ming",
            "Captain Rex",
            "Carnor Jax",
            "Chewbacca",
            "Clone Commander Cody",
            "Count Dooku",
            "Darth Bane",
            "Darth Krayt",
            "Darth Maul",
            "Darth Nihilus",
            "Darth Vader",
            "Dash Rendar",
            "Dengar",
            "Durge",
            "Emperor Palpatine",
            "Exar Kun",
            "Galen Marek",
            "General Crix Madine",
            "General Dodonna",
            "General Grievous",
            "General Veers",
            "Gilad Pellaeon",
            "Grand Moff Tarkin",
            "Greedo",
            "Han Solo",
            "Hardcase",
            "IG 88",
            "Jabba The Hutt",
            "Jacen Solo",
            "Jaina Solo",
            "Jango Fett",
            "Jarael",
            "Jerec",
            "Joruus C'Baoth",
            "Ki-Adi-Mundi",
            "Kir Kanos",
            "Kit Fisto",
            "Kyle Katarn",
            "Kyp Durron",
            "Lando Calrissian",
            "Luke Skywalker",
            "Luminara Unduli",
            "Lumiya",
            "Mace Windu",
            "Mara Jade",
            "Mission Vao",
            "Natasi Daala",
            "Nom Anor",
            "Obi-Wan Kenobi",
            "Padmé Amidala",
            "Plo Koon",
            "Pre Vizsla",
            "Prince Xizor",
            "Princess Leia",
            "PROXY",
            "Qui-Gon Jinn",
            "Quinlan Vos",
            "R2-D2",
            "Rahm Kota",
            "Revan",
            "Salacious B. Crumb",
            "Satele Shan",
            "Savage Opress",
            "Sebulba",
            "Shaak Ti",
            "Shmi Skywalker",
            "Sio Bibble",
            "Talon Karrde",
            "Ulic Qel-Droma",
            "Visas Marr",
            "Watto",
            "Wedge Antilles",
            "Wullf Yularen",
            "Yoda",
            "Zam Wesell",
            "Zayne Carrick",
            "Zuckuss"
        }.AsReadOnly();

        public IReadOnlyList<string> All() => Characters;

        public string Random() => Random(1).Single();

        public IReadOnlyList<string> Random(int numberOfCharacters)
        {
            if (numberOfCharacters < 1 || numberOfCharacters > Characters.Count)
                throw new ArgumentOutOfRangeException(
                    nameof(numberOfCharacters),
                    $"{nameof(numberOfCharacters)} must be between 1 and {Characters.Count} inclusive.");

            return All()
                .OrderBy(_ => Guid.NewGuid())
                .Take(numberOfCharacters)
                .ToList()
                .AsReadOnly();
        }
    }
}
