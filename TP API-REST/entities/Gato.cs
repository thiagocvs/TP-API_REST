namespace TP_API_REST;

public class Gato : Mascota
{
    private string color = "";
    private string tipo = "gato";

    public string Tipo { get => tipo; set => tipo = value; }
    public string Color { get => color; set => color = value; }
}
