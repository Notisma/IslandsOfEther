using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using Random = System.Random;

namespace Manager
{
    public static class CardsManager
    {
        public static Dictionary<string, CardData> cards;

        static CardsManager()
        {
            cards = new Dictionary<string, CardData>
            {
                {
                    "ange",
                    new CardData("ange", "Ange", 3, 4,
                        "Êtres célestes représentant la force divine la plus présente et la moins puissante. Ils sont les messagers de la divinité suprême et suivent les ordres des archanges.")
                },
                {
                    "archange",
                    new CardData("archange", "Archange", 5, 10,
                        "Les Archanges obéissent directement à la divinité suprême et sont les supérieurs aux anges normaux. De part la responsabilité qu’il les incombe, ils perdent en vitesse mais gagne en force et en durabilité à côté de leurs subalternes.")
                },
                {
                    "divinite-supreme",
                    new CardData("divinite-supreme", "Divinité Suprême", 10, 15,
                        "Cheffe de toutes les divinités et légendes, elle est l’être le plus puissant qui existe. Elle excelle dans tous les domaines et est la mère des êtres les plus puissants tels que le Serpent-Univers et le Bouddha Prodige.")
                },
                {
                    "serpent-univers",
                    new CardData("serpent-univers", "Serpent-Univers", 6, 14,
                        "Il s’agit de la créature la plus grande connue. Il a pour rôle de délimiter l’univers en l’entourant jusqu’à se mordre la queue. Il est dit qu’un simple mouvement de sa part peut créer des catastrophes incommensurables.")
                },
                {
                    "bouddha-prodige",
                    new CardData("bouddha-prodige", "Bouddha Prodige", 6, 15,
                        "Ayant développé une connaissance infinie, le Bouddha Prodige a acquis de multiples facultés comme celle de voler et celle de télépathie. Cependant, ayant fait veux de paix, il n’a que très peu de puissance physique.")
                },
                {
                    "centopus",
                    new CardData("centopus", "Centopus", 4, 5,
                        "Divinité de la pêche et des cumulonimbus, Octentum est connue comme étant la pieuvre aux milles tentacules et le fils du Serpent-Univers. Malgré sa faible résistance, Octentum est dotée d’une agilité et d’une force à ne pas sous-estimer.")
                },
                {
                    "tigre-d-or",
                    new CardData("tigre-d-or", "Tigre d'Or", 5, 4,
                        "Fidèle compagnon du Bouddha Prodige, il l’accompagne dans tous ses combats lui servant de protecteur et d’épée. Il fait cependant une piètre protection au vue de sa faible résistance.")
                },
                {
                    "viviane",
                    new CardData("viviane", "Viviane, Reine des Fées", 5, 11,
                        "Mère de toutes les fées, Viviane vit reclus dans la Foret de Brocéliande avec ses filles. Elle est la fille de la Divinité Suprême est chargée de surveiller les Hommes.")
                },
                {
                    "shinigami",
                    new CardData("shinigami", "Shinigami", 4, 6,
                        "Être spirituel chargé de mettre fin à la vie des Hommes et de les accompagner dans l’au-delà. Ils sont cependant limités par les Archanges qui désignent les personnes devant mourir.")
                },
                {
                    "kitsune",
                    new CardData("kitsune", "Kitsune", 3, 7,
                        "Le kitsune a pour habitude d’aider son prochain et de faire de nouvelle rencontres. Il fait cependant preuve de méfiance et sait se montrer féroce en cas de problème.")
                },
                {
                    "fenrir",
                    new CardData("fenrir", "Fenrir", 6, 11,
                        "Fenrir a pour ambition de rétablir l’ordre dans l’univers. Pour y parvenir, il est près à tout. C’est pour cela qu’il a déjà affronté à plusieurs reprises son ancien fidèle allié, le Kitsune.")
                },
                {
                    "chatoinubis",
                    new CardData("chatoinubis", "Chatoinubis", 7, 13,
                        "Être omniscient, omnipotent et omniprésent veillant à l’équilibre du Résultat. Il a le pouvoir de prendre toutes les formes et d’accomplir n’importe quelles fonctions. Son rôle principal consiste à juger les défunts lors de leur entrée dans l’outre-monde.")
                }
            };
        }

        public static CardData GetRandomCard()
        {
            Random rand = new Random();
            return cards.ElementAt(rand.Next(0, cards.Count)).Value;
        }

        private const string CardsSpritesRoot =
            "/home/notisma/4Projects/GameDev/2Projects/CGJ2024/Assets/Sprites/Cards/CardDetails/";

        public static Sprite GetNameSprite(CardInstData d)
        {
            Sprite adequateSprite = U.GetSpriteFromFile(CardsSpritesRoot + d.baseData.name + "/name.png");
            return adequateSprite ? adequateSprite : U.GetSpriteFromFile(CardsSpritesRoot + "placeholder_name.png");
        }

        public static Sprite GetImageSprite(CardInstData d)
        {
            Sprite adequateSprite = U.GetSpriteFromFile(CardsSpritesRoot + d.baseData.name + "/img.png");
            return adequateSprite ? adequateSprite : U.GetSpriteFromFile(CardsSpritesRoot + "placeholder_img.png");
        }

        public static Sprite GetAtkSprite(CardInstData d)
        {
            Sprite adequateSprite = U.GetSpriteFromFile(CardsSpritesRoot + "numbers/" + d.baseData.attack + ".png");
            return adequateSprite
                ? adequateSprite
                : U.GetSpriteFromFile(CardsSpritesRoot + "numbers/placeholder_atk.png");
        }

        public static Sprite GetHpSprite(CardInstData d)
        {
            Sprite adequateSprite = U.GetSpriteFromFile(CardsSpritesRoot + "numbers/" + d.hp + ".png");
            return adequateSprite
                ? adequateSprite
                : U.GetSpriteFromFile(CardsSpritesRoot + "numbers/placeholder_hp.png");
        }
    }
}