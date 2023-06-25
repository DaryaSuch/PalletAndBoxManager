using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsoleApp2.Controller;

namespace ConsoleApp2.Model;

public class Box
{
    [Key]
    public int IdBox { get; set; }
    public int BoxHeight { get; set; }
    public int BoxWidth { get; set; }
    public int BoxDepth { get; set; }
    public int BoxVolume { get; set; }
    public int BoxWeight { get; set; }
    public DateOnly ManufDate { get; set; }
    public DateOnly BestBefore { get; set; }
    public int IdPallet { get; set; }
    [ForeignKey("IdPallet")]

    public Pallet Pallet { get; set; }
    
    public Box(){}
    
    DBContext context = new DBContext();
    
    public Box(int boxHeight, int boxWidth, int boxDepth, int boxWeight, string manufDate = "", string bestBefore = "", int idPallet=0)
    {
        PalletController palletController = new PalletController();
        BoxController boxController = new BoxController();
        this.BoxHeight = boxHeight;
        this.BoxWidth = boxWidth;
        this.BoxDepth = boxDepth;
        this.BoxWeight = boxWeight;
        this.BoxVolume = boxHeight * boxWidth * boxDepth;
        if (!string.IsNullOrEmpty(manufDate))
        {
            this.ManufDate = DateOnly.Parse(manufDate);
            this.BestBefore = this.ManufDate.AddDays(100);
        }
        else
        {
            this.BestBefore = DateOnly.Parse(bestBefore);
            this.ManufDate = this.BestBefore.AddDays(-100);
        }

        if (idPallet != 0)
        {
            Pallet pallet = palletController.GetPalletById(idPallet);
            if (boxController.IsBoxMatchesToPallet(this, pallet))
            {
                this.IdPallet = idPallet;
            }
        }
        context.Boxes.Add(this);
        context.SaveChanges();
    }
}