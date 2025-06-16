namespace LojaDeBrinquedos2.Classes;

public class Entrega
{
 public required string Pedido { get; set; }
    public required string Transportadora { get; set; }
    public required string status { get; set; }
    public required string CodigoRastreio { get; set; }
    public required string Datas { get; set; }

    public Entrega (string pedido, string Transportadora, string status, string CodigoRastreio, string Datas)
    {
        Pedido = pedido;
        this.Transportadora = Transportadora;
        this.status = status;
        this.CodigoRastreio = CodigoRastreio;
        this.Datas = Datas;

    }



}
