using Enums;

var porridge = new Porridge { Temperature = PorridgeTemperature.JustRight };

switch (porridge.Temperature)
{
case PorridgeTemperature.TooHot:
    GoOutsideForABit();
    break;

case PorridgeTemperature.TooCold:
    MicrowaveMyBreakfast();
    break;

case PorridgeTemperature.JustRight:
    NomNomNom();
    break;
}


static void GoOutsideForABit()
{
}

static void MicrowaveMyBreakfast()
{
}

static void NomNomNom()
{
}

string path = @"C:\temp\file.txt";

var stream = new MemoryStream();

using var rdr = new StreamReader(stream, true);

using var fs = new FileStream(path, FileMode.Append);
