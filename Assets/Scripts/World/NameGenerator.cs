using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class NameGenerator
{
    private static List<String> names = new List<String>()
    {
        "Nhuhneid Bhilad",
        "Bahlun Nanad",
        "Ocror Oceankeeper",
        "Dirkur Brighttrapper",
        "Fabom Dedz",
        "Grer Stenursk",
        "Garbath Hardgrove",
        "Vom Wyvernbrace",
        "Hojeh-Ko Huundinzit",
        "To-Den Vuelret",
        "Fesvaurzod Emonzolmo",
        "Zovet Stirintu",
        "Qung Kua",
        "Iun Ya",
        "Pezulir Bicostos",
        "Vuliz Jescendur",
        "Rabem Cesti",
        "Bahmen Dhanei",
        "Dalum Rapidward",
        "Gao Featherwatcher",
        "Gegrir Man",
        "Bon Stevrarsk",
        "Arduth Clawweaver",
        "Zon Phoenixgem",
        "Mir-Ve-Mek Hahkakrahk",
        "Duhke Finskem",
        "Fethergosk Ridemeva",
        "Kauthoc Muldoko",
        "Thuim Yiem",
        "Liuw Xun",
        "dombuzuz meldisqo",
        "rilbez sirnarnu",
        "Bhurden Rhisha",
        "Neizar Khoste",
        "Grurdem Holyheart",
        "Burdurn Crystalaxe",
        "Hodgon Glersk",
        "Grer Grernersk",
        "Freckem Leafblossom",
        "Blur Riverkiller",
        "Had-Kuzaf Jiltrilrud",
        "Se-Rur Sunkrim",
        "Zisvosles Ganovyelme",
        "Doordok Margilbu",
        "Qiuh Aiy",
        "Chi Shiao",
        "Franerniel Zonzaze",
        "Gratoz Zinduscis",
        "bhuhmar Rinnor",
        "Rhahnan Nedod",
        "Gingad Distantshade",
        "Goe Horseblade",
        "Hodren Stuv",
        "Pen Diviv",
        "Blandur Bladevigor",
        "Zerth Elfbreaker",
        "Zom-Keuchih Fajeltreft",
        "Gohvar Nuunkrifk",
        "Solmasvak Chekebivri",
        "Morlec Trogomzi",
        "Thong Siao",
        "Zuin Cue",
        "Crivirtur Cuscegi"
    };

    private static List<String> characteristics = new List<String>()
    {
        "The Swordbreaker",
        "The Crazy Bear",
        "First Of Xeskeaton",
        "Defender Of Baswistan",
        "The Souleater",
        "Dark Knight",
        "Bravest In The World",
        "Conqueror of Froso",
        "The Berserker",
        "Dragon Winner",
        "The Steel Dragon"
    };

    public static String GenerateName()
    {
        return names[Random.Range(0, names.Count)] + ", " + characteristics[Random.Range(0, characteristics.Count)];
    } 
}