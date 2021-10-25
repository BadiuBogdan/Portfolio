package selling.system;

/**
 *
 * @author Gabi
 */
public class Profit {

    private int idProfit;
    private float profit;
    private float impozitProfit;
   
    public Profit(int idProfit, float profit, float impozitProfit) {
        this.idProfit = idProfit;
        this.profit = profit;
        this.impozitProfit = impozitProfit;
    }
    
    public int getIdProfit() {
        return idProfit;
    }

    public void setIdProfit(int idProfit) {
        this.idProfit = idProfit;
    }

    public float getProfit() {
        return profit;
    }

    public void setProfit(float profit) {
        this.profit = profit;
    }

    public float getImpozitProfit() {
        return impozitProfit;
    }

    public void setImpozitProfit(float impozitProfit) {
        this.impozitProfit = impozitProfit;
    }

}
