using System.ComponentModel.Design;

string folderPath = @"C:\DataMänguJaoks\";
string heroFile = "Heroes.txt";
string villainFile = "Villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "püssiga", "noaga", "mõõgaga", "rusikatega", "granaadiga" };


//string[] heroes = {"Tule Taltsutaja", "Viiking", "Politsei", "Naljamees"};
//string[] villains = { "Pätt", "Surmakutsar", "Kõrilõikaja", "Hull Vana", "Vanapagan" };
//Random rnd = new Random();
//int randomIndex = rnd.Next(0, heroes.Length);

string hero = GetRandomValueFromArray(heroes); //heroes[randomIndex];
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Täna {hero} ({heroHP} HP) koos {heroWeapon} üritab päästa päeva päevavalgel!");

//randomIndex = rnd.Next(0, villains.Length);

string villain = GetRandomValueFromArray(villains); //villains[randomIndex];
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Täna {villain} ({villainHP} HP) soovib {villainWeapon} röövida panka ööpimeduses! UUuuh sellest tuleb jube öööö...");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}
Console.WriteLine($"Kangelase {hero} elupunktid: {heroHP}");
Console.WriteLine($"Kurikaela {villain} elupunktid: {villainHP}");

if(heroHP > 0)
{
    Console.WriteLine($"{hero} päästis päeva!");
}
else if (villainHP > 0)
{ Console.WriteLine($"Kurikaelad võitsid!"); }
else
{
    Console.WriteLine("Kumbki ei ole enam elus!");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    { return characterName.Length; }

}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} ei tabanud vastast");
    }
    else if(strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} tegi tugeva löögi!");
    }
    else
    {
        Console.WriteLine($"{characterName} tabas vastast ja eemaldas temalt {strike} elupunkti!");
    }
    return strike;
}


