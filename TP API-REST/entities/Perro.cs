namespace TP_API_REST;

public class Perro : Mascota
{
    private string raza = "";
    private string tipo = "perro";

    public string Tipo { get => tipo; set => tipo = value; }
    public string Raza { get => raza; set => raza = value; }
}
