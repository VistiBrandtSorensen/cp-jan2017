# Introduktion til typer og logik

## Typer

* **Heltal** `int` *(integer)*

  Bruges til tal uden kommaer.

  *Eksempler:*

  `0`, `1`, `5`, `67`, `-1`, `-49`, `-73`

* **Bogstaver** `char` *(character)*

  Enkelte bogstaver.

  *Eksempler:*

  `'a'`, `'b'`, `'c'`, `'d'`, `'e'`, `'æ'`, `'ø'`, `'å'`, `'1'`, `'2'`, `'3'`, `'"'`, `'#'`, `'€'`

* **Tekst** `string`

  Tekststrenge, sammensat af bogstaver.

  *Eksempler:*

  `"CodingPirates i Helsingør"`, `"Avanceret programmering"`

* **Sandt/Falsk** `bool`

  Værdier som enten er sande eller falske.  Resultat af sammenligning.

  *Eksempler:*
  `true`, `false`, `3>2` (`true`), `'a'=='b'` (`false`)

* **Lister** `Array`

  Lister af samme type.  Hvert enkelt element kan bruges, så det første hedder `0` det andet hedder `1` osv.  Det er måske lidt forvirrende, men det er til at lære :)

  *Eksempler:*
  `[1, 2, 3, 4]`, `['a', 'b', 'c']`

## Variable

Variable er værdier med som har fået et navn.  Hvis en variabel har typen `int` (heltal) kan den *aldrig* komme til at indeholde andet.

Variable skal altid *erklæres* (oprettes) inden de kan bruges.

*Eksempler:*

```csharp
int x;
int y = 1;
char inputKey;
string name = "Coding Pirates";
bool isStudent = true;
```

Hvis det er tydeligt hvilken type en variabel har, kan den også erklæres med `var`:

```charp
var x; // FEJL!
var y = 1; // int
var inputKey = 'a'; // char
var name = "CodingPirates" // string
var isStudent = true; // bool
```

Som I kan se ovenfor, kan man skrive kommentarer på en linje ved at bruge `//`, som betyder at resten af linjen ignoreres.



## Udtryk

* **Hvis...ellers** `if...else`

  *Eksempler:*

```csharp
if (2 > 1)
{
    // Gør noget
}
```

```csharp
if (x < 5)
{
    // Gør noget
}
else
{
    // Gør noget andet
}
```

## Blokke og logiske linjer

I C# skal alle logiske linjer afsluttes med `;` (semikolon).  Ligeledes skal alle `if`s afgrænses med blokke angivet med `{` og `}` (tuborgklammer).

## Metoder og funktioner

Vi kigger nærmere på metoder og funktioner senere, men kort fortalt, kan man pakke kode der gør bestemte ting ind i metoder eller funktioner, så de kan bruges flere gange - og så det er lettere at læse koden.

### Metode

En metode returnerer ikke en værdi - den gør kun noget.

*Eksempel:*

```charp
void PrintHelloName(string name)
{
    Console.WriteLine("Hej {0}", name);
}
```

### Funktion

En funktion returnerer (beregner en værdi).

*Eksempel:*

```charp
int Sum(int x, int y)
{
    return x + y;
}
```