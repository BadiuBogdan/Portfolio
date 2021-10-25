package selling.system;

/**
 *
 * @author Gabi
 */
public class Stoc {

    private int idStoc;
    private int idProdus;
    private int cantitate;
    private String furnizor;
    private float pretAchizitieBucata;

    public Stoc(int idStoc, int idProdus, int cantitate, String furnizor, float pretAchizitieBucata) {
        this.idStoc = idStoc;
        this.idProdus = idProdus;
        this.cantitate = cantitate;
        this.furnizor = furnizor;
        this.pretAchizitieBucata = pretAchizitieBucata;
    }

    public int getIdStoc() {
        return idStoc;
    }

    public void setIdStoc(int idStoc) {
        this.idStoc = idStoc;
    }

    public int getIdProdus() {
        return idProdus;
    }

    public void setIdProdus(int idProdus) {
        this.idProdus = idProdus;
    }

    public int getCantitate() {
        return cantitate;
    }

    public void setCantitate(int cantitate) {
        this.cantitate = cantitate;
    }

    public String getFurnizor() {
        return furnizor;
    }

    public void setFurnizor(String furnizor) {
        this.furnizor = furnizor;
    }

    public float getPretAchizitieBucata() {
        return pretAchizitieBucata;
    }

    public void setPretAchizitieBucata(float pretAchizitieBucata) {
        this.pretAchizitieBucata = pretAchizitieBucata;
    }

}
